#region -- License Terms --
// 
// MessagePack for CLI
// 
// Copyright (C) 2015-2016 FUJIWARA, Yusuke
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

#if UNITY_5 || UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_WII || UNITY_IPHONE || UNITY_ANDROID || UNITY_PS3 || UNITY_XBOX360 || UNITY_FLASH || UNITY_BKACKBERRY || UNITY_WINRT
#define UNITY
#endif

using System;
#if !UNITY
using System.Collections;
#endif // !UNITY
#if FEATURE_TAP
using System.Threading;
using System.Threading.Tasks;
#endif // FEATURE_TAP

using MsgPack.Serialization.CollectionSerializers;

namespace MsgPack.Serialization.ReflectionSerializers
{
#if !UNITY
	internal sealed class ReflectionNonGenericDictionaryMessagePackSerializer<TDictionary> : NonGenericDictionaryMessagePackSerializer<TDictionary>
		where TDictionary : IDictionary
#else
	internal sealed class ReflectionNonGenericDictionaryMessagePackSerializer : UnityNonGenericDictionaryMessagePackSerializer
#endif // !UNITY
	{
#if !UNITY
		private readonly Func<int, TDictionary> _factory;
#else
		private readonly Func<int, object> _factory;
#endif // !UNITY

		private readonly bool _isPackable;
		private readonly bool _isUnpackable;
#if FEATURE_TAP
		private readonly bool _isAsyncPackable;
		private readonly bool _isAsyncUnpackable;
#endif // FEATURE_TAP

#if !UNITY
		public ReflectionNonGenericDictionaryMessagePackSerializer(
			SerializationContext ownerContext,
			Type targetType,
			PolymorphismSchema itemsSchema
		)
			: base( ownerContext, itemsSchema )
		{
			this._factory = ReflectionSerializerHelper.CreateCollectionInstanceFactory<TDictionary, object>( targetType );
			this._isPackable = typeof( IPackable ).IsAssignableFrom( targetType ?? typeof( TDictionary ) );
			this._isUnpackable = typeof( IUnpackable ).IsAssignableFrom( targetType ?? typeof( TDictionary ) );
#if FEATURE_TAP
			this._isAsyncPackable = typeof( IAsyncPackable ).IsAssignableFrom( targetType ?? typeof( TDictionary ) );
			this._isAsyncUnpackable = typeof( IAsyncUnpackable ).IsAssignableFrom( targetType ?? typeof( TDictionary ) );
#endif // FEATURE_TAP
		}
#else
		public ReflectionNonGenericDictionaryMessagePackSerializer(
			SerializationContext ownerContext,
			Type abstractType,
			Type concreteType,
			PolymorphismSchema itemsSchema 
		)
			: base( ownerContext, abstractType, itemsSchema )
		{
			this._factory = ReflectionSerializerHelper.CreateCollectionInstanceFactory( abstractType, concreteType, typeof( object ) );
			this._isPackable = typeof( IPackable ).IsAssignableFrom( concreteType ?? abstractType );
			this._isUnpackable = typeof( IUnpackable ).IsAssignableFrom( concreteType ?? abstractType );
		}
#endif // !UNITY

#if !UNITY
		protected internal override void PackToCore( Packer packer, TDictionary objectTree )
#else
		protected internal override void PackToCore( Packer packer, object objectTree )
#endif // !UNITY
		{
			if ( this._isPackable )
			{
				( ( IPackable )objectTree ).PackToMessage( packer, null );
				return;
			}

			base.PackToCore( packer, objectTree );
		}

#if !UNITY
		protected internal override TDictionary UnpackFromCore( Unpacker unpacker )
#else
		protected internal override object UnpackFromCore( Unpacker unpacker )
#endif
		{
			if ( this._isUnpackable )
			{
				var result = this.CreateInstance( 0 );
				( ( IUnpackable )result ).UnpackFromMessage( unpacker );
				return result;
			}

			return base.UnpackFromCore( unpacker );
		}

#if FEATURE_TAP

		protected internal override Task PackToAsyncCore( Packer packer, TDictionary objectTree, CancellationToken cancellationToken )
		{
			if ( this._isAsyncPackable )
			{
				return ( ( IAsyncPackable )objectTree ).PackToMessageAsync( packer, null, cancellationToken );
			}

			return base.PackToAsyncCore( packer, objectTree, cancellationToken );
		}

		protected internal override Task<TDictionary> UnpackFromAsyncCore( Unpacker unpacker, CancellationToken cancellationToken )
		{
			if ( this._isAsyncUnpackable )
			{
				return this.UnpackFromMessageAsync( unpacker, cancellationToken );
			}

			return base.UnpackFromAsyncCore( unpacker, cancellationToken );
		}

		private async Task<TDictionary> UnpackFromMessageAsync( Unpacker unpacker, CancellationToken cancellationToken )
		{
			var result = this.CreateInstance( 0 );
			await ( ( IAsyncUnpackable )result ).UnpackFromMessageAsync( unpacker, cancellationToken ).ConfigureAwait( false );
			return result;
		}

#endif // FEATURE_TAP
#if !UNITY
		protected override TDictionary CreateInstance( int initialCapacity )
#else
		protected override object CreateInstance( int initialCapacity )
#endif // !UNITY
		{
			return this._factory( initialCapacity );
		}
	}
}