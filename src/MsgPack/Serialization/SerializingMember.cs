#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010-2016 FUJIWARA, Yusuke
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
#if CORE_CLR || UNITY
using MPContract = MsgPack.MPContract;
#else
using MPContract = System.Diagnostics.Contracts.Contract;
#endif // CORE_CLR || UNITY
using System.Reflection;

namespace MsgPack.Serialization
{
	/// <summary>
	///		Represents serializing member information.
	/// </summary>
#if !UNITY
	internal struct SerializingMember
#else
	internal sealed class SerializingMember
#endif // !UNITY
	{
		public readonly MemberInfo Member;
		public readonly DataMemberContract Contract;
		public readonly string MemberName;

#if UNITY
		public SerializingMember()
		{
			this.Member = null;
			this.Contract = new DataMemberContract ();
		}
#endif // UNITY

		public SerializingMember( MemberInfo member, DataMemberContract contract )
		{
#if DEBUG
			MPContract.Assert( member != null );
#endif // DEBUG
			this.Member = member;
			this.Contract = contract;
			// Use contract name for aliased map serialization.
			this.MemberName = member == null ? null : contract.Name;
		}

#if !NETFX_35
		// For Tuple
		public SerializingMember( string name )
		{
#if DEBUG
			MPContract.Assert( name.StartsWith( "Item" ), name + ".StartsWith(\"Item\")" );
#endif // DEBUG
			this.Member = null;
			this.Contract = default ( DataMemberContract );
			this.MemberName = name;
		}
#endif // !NETFX_35

		public EnumMemberSerializationMethod GetEnumMemberSerializationMethod()
		{
#if NETSTD_11 || NETSTD_13
			var messagePackEnumMemberAttribute = 
				this.Member.GetCustomAttribute<MessagePackEnumMemberAttribute>();
			if ( messagePackEnumMemberAttribute != null)
			{
				return messagePackEnumMemberAttribute.SerializationMethod;
#else
			var messagePackEnumMemberAttributes =
				this.Member.GetCustomAttributes( typeof( MessagePackEnumMemberAttribute ), true );
			if ( messagePackEnumMemberAttributes.Length > 0 )
			{
				return
					// ReSharper disable once PossibleNullReferenceException
					( messagePackEnumMemberAttributes[ 0 ] as MessagePackEnumMemberAttribute ).SerializationMethod;
#endif // NETSTD_11 || NETSTD_13
			}

			return EnumMemberSerializationMethod.Default;
		}

		public DateTimeMemberConversionMethod GetDateTimeMemberConversionMethod()
		{
#if NETSTD_11 || NETSTD_13
			var messagePackDateTimeMemberAttribute = 
				this.Member.GetCustomAttribute<MessagePackDateTimeMemberAttribute>();
			if ( messagePackDateTimeMemberAttribute != null)
			{
				return messagePackDateTimeMemberAttribute.DateTimeConversionMethod;
#else
			var messagePackDateTimeMemberAttribute =
				this.Member.GetCustomAttributes( typeof( MessagePackDateTimeMemberAttribute ), true );
			if ( messagePackDateTimeMemberAttribute.Length > 0 )
			{
				return
					// ReSharper disable once PossibleNullReferenceException
					( messagePackDateTimeMemberAttribute[ 0 ] as MessagePackDateTimeMemberAttribute ).DateTimeConversionMethod;
#endif // NETSTD_11 || NETSTD_13
			}

			return DateTimeMemberConversionMethod.Default;
		}
	}
}
