#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2013 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Holds debugging support information.
	/// </summary>
	internal static class SerializerDebugging
	{
		[ThreadStatic]
		private static bool _traceEnabled;

		/// <summary>
		///		Gets or sets a value indicating whether instruction/expression tracing is enabled or not.
		/// </summary>
		/// <value>
		///		<c>true</c> if instruction/expression tracing is enabled; otherwise, <c>false</c>.
		/// </value>
		public static bool TraceEnabled
		{
			get { return _traceEnabled; }
			set { _traceEnabled = value; }
		}

		[ThreadStatic]
		private static bool _dumpEnabled;

		/// <summary>
		///		Gets or sets a value indicating whether IL dump is enabled or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if IL dump is enabled; otherwise, <c>false</c>.
		/// </value>
		public static bool DumpEnabled
		{
			get { return _dumpEnabled; }
			set { _dumpEnabled = value; }
		}

		[ThreadStatic]
		private static StringWriter _ilTraceWriter;

		/// <summary>
		///		Gets the <see cref="TextWriter"/> for IL tracing.
		/// </summary>
		/// <value>
		///		The <see cref="TextWriter"/> for IL tracing.
		///		This value will not be <c>null</c>.
		/// </value>
		public static TextWriter ILTraceWriter
		{
			get
			{
				if ( !_traceEnabled )
				{
					return TextWriter.Null;
				}

				if ( _ilTraceWriter == null )
				{
					_ilTraceWriter = new StringWriter( CultureInfo.InvariantCulture );
				}

				return _ilTraceWriter;
			}
		}

		/// <summary>
		///		Traces the instruction.
		/// </summary>
		/// <param name="format">The format string.</param>
		/// <param name="args">The args for formatting.</param>
		public static void TraceInstruction( string format, params object[] args )
		{
			if ( !_traceEnabled )
			{
				return;
			}

			_ilTraceWriter.WriteLine( format, args );
		}

		/// <summary>
		///		Traces the specific event.
		/// </summary>
		/// <param name="format">The format string.</param>
		/// <param name="args">The args for formatting.</param>
		public static void TraceEvent( string format, params object[] args )
		{
			if ( !_traceEnabled )
			{
				return;
			}

			Tracer.Emit.TraceEvent( Tracer.EventType.DefineType, Tracer.EventId.DefineType, format, args );
		}

		/// <summary>
		///		Flushes the trace data.
		/// </summary>
		public static void FlushTraceData()
		{
			if ( !_traceEnabled )
			{
				return;
			}

			Tracer.Emit.TraceData( Tracer.EventType.DefineType, Tracer.EventId.DefineType, _ilTraceWriter.ToString() );
		}

		[ThreadStatic]
		private static AssemblyBuilder _assemblyBuilder;

		[ThreadStatic]
		private static ModuleBuilder _moduleBuilder;

		/// <summary>
		///		Prepares instruction dump with specified <see cref="AssemblyBuilder"/>.
		/// </summary>
		/// <param name="assemblyBuilder">The assembly builder to hold instructions.</param>
		public static void PrepareDump( AssemblyBuilder assemblyBuilder )
		{
			if ( _dumpEnabled )
			{
#if DEBUG
				Contract.Assert( assemblyBuilder != null );
#endif
				_assemblyBuilder = assemblyBuilder;
			}
		}

		/// <summary>
		///		Prepares the dump with dedicated internal <see cref="AssemblyBuilder"/>.
		/// </summary>
		public static void PrepareDump()
		{
			_assemblyBuilder =
				AppDomain.CurrentDomain.DefineDynamicAssembly(
					new AssemblyName( "ExpressionTreeSerializerLogics" ),
					AssemblyBuilderAccess.Save,
					default( IEnumerable<CustomAttributeBuilder> )
				);
			_moduleBuilder =
				_assemblyBuilder.DefineDynamicModule( "ExpressionTreeSerializerLogics", "ExpressionTreeSerializerLogics.dll", true );
		}

		// TODO: Cleanup %Temp% to delete temp assemblies generated for on the fly code DOM.

		[ThreadStatic]
		private static IList<string> _runtimeAssemblies;

		[ThreadStatic]
		private static IList<string> _compiledCodeDomSerializerAssemblies;

		public static IEnumerable<string> CodeDomSerializerDependentAssemblies
		{
			get
			{
				EnsureDependentAssembliesListsInitialized();
#if DEBUG
				Contract.Assert( _compiledCodeDomSerializerAssemblies != null );
#endif
				// FCL dependencies and msgpack core libs
				foreach ( var runtimeAssembly in _runtimeAssemblies )
				{
					yield return runtimeAssembly;
				}

				// dependents
				foreach ( var compiledAssembly in _compiledCodeDomSerializerAssemblies )
				{
					yield return compiledAssembly;
				}
			}
		}

		public static void AddRuntimeAssembly( string pathToAssembly )
		{
			EnsureDependentAssembliesListsInitialized();
			_runtimeAssemblies.Add( pathToAssembly );
		}

		public static void AddCompiledCodeDomAssembly( string pathToAssembly )
		{
			EnsureDependentAssembliesListsInitialized();
			_compiledCodeDomSerializerAssemblies.Add( pathToAssembly );
		}

		public static void ResetDependentAssemblies()
		{
			EnsureDependentAssembliesListsInitialized();

			File.AppendAllLines( GetHistoryFilePath(), _compiledCodeDomSerializerAssemblies );
			_compiledCodeDomSerializerAssemblies.Clear();
			ResetRuntimeAssemblies();
		}

		private static int _wasDeleted = 0;
		private const string _historyFile = "MsgPack.Serialization.SerializationGenerationDebugging.CodeDOM.History.txt";

		public static void DeletePastTemporaries()
		{
			if ( Interlocked.CompareExchange( ref _wasDeleted, 1, 0 ) != 0 )
			{
				return;
			}

			try
			{
				var historyFilePath = GetHistoryFilePath();
				if ( !File.Exists( historyFilePath ) )
				{
					return;
				}

				foreach ( var pastAssembly in File.ReadLines( historyFilePath ) )
				{
					File.Delete( pastAssembly );
				}

				new FileStream( historyFilePath, FileMode.Truncate ).Close();
			}
			catch ( IOException ) { }
		}

		private static string GetHistoryFilePath()
		{
			return Path.Combine( Path.GetTempPath(), _historyFile );
		}

		private static void EnsureDependentAssembliesListsInitialized()
		{
			if ( _runtimeAssemblies == null )
			{
				_runtimeAssemblies = new List<string>();
				ResetRuntimeAssemblies();
			}

			if ( _compiledCodeDomSerializerAssemblies == null )
			{
				_compiledCodeDomSerializerAssemblies = new List<string>();
			}
		}

		private static void ResetRuntimeAssemblies()
		{
			_runtimeAssemblies.Add( "System.dll" );
			_runtimeAssemblies.Add( "System.Core.dll" );
			_runtimeAssemblies.Add( "System.Numerics.dll" );
			_runtimeAssemblies.Add( typeof( SerializerDebugging ).Assembly.Location );
		}

		[ThreadStatic]
		private static bool _onTheFlyCodeDomEnabled;

		public static bool OnTheFlyCodeDomEnabled
		{
			get { return _onTheFlyCodeDomEnabled; }
			set { _onTheFlyCodeDomEnabled = value; }
		}

		/// <summary>
		///		Creates the new type builder for the serializer.
		/// </summary>
		/// <param name="targetType">The serialization target type.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">PrepareDump() was not called.</exception>
		public static TypeBuilder NewTypeBuilder( Type targetType )
		{
			if ( _moduleBuilder == null )
			{
				throw new InvalidOperationException( "PrepareDump() was not called." );
			}

			return
				_moduleBuilder.DefineType( IdentifierUtility.EscapeTypeName( targetType ) + "SerializerLogics" );
		}

		/// <summary>
		///		Takes dump of instructions.
		/// </summary>
		public static void Dump()
		{
			if ( _assemblyBuilder != null )
			{
				_assemblyBuilder.Save( _assemblyBuilder.GetName().Name + ".dll" );
			}
		}

		/// <summary>
		///		Resets debugging states.
		/// </summary>
		public static void Reset()
		{
			_assemblyBuilder = null;
			_moduleBuilder = null;

			if ( _ilTraceWriter != null )
			{
				_ilTraceWriter.Dispose();
				_ilTraceWriter = null;
			}

			_dumpEnabled = false;
			_traceEnabled = false;
			ResetDependentAssemblies();
		}
	}
}