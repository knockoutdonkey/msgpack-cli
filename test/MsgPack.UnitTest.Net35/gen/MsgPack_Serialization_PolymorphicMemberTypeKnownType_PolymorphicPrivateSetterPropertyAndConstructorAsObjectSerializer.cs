﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:2.0.50727.8689
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.7.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObjectSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject> {
        
        private MsgPack.Serialization.MessagePackSerializer<object> _serializer0;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject> this_PackValueOfPolymorphicDelegate;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>> _packOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>> _packOperationTable;
        
        private System.Reflection.MethodBase _methodBasePolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject_set_Polymorphic0;
        
        private System.Action<MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, object> this_SetUnpackedValueOfPolymorphicDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int> this_UnpackValueOfPolymorphicDelegate;
        
        private System.Collections.Generic.IList<string> _memberNames;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>> _unpackOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>> _unpackOperationTable;
        
        public MsgPack_Serialization_PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObjectSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> typeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            typeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(2);
            typeMap0.Add("0", typeof(MsgPack.Serialization.FileEntry));
            typeMap0.Add("1", typeof(MsgPack.Serialization.DirectoryEntry));
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(object), typeMap0);
            this._serializer0 = context.GetSerializer<object>(schema0);
            this._methodBasePolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject_set_Polymorphic0 = MsgPack.Serialization.ReflectionHelpers.GetMethod(typeof(MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject), "set_Polymorphic", new System.Type[] {
                        typeof(object)});
            System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>[] packOperationList = default(System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>[]);
            packOperationList = new System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>[1];
            packOperationList[0] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>(this.PackValueOfPolymorphic);
            this._packOperationList = packOperationList;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>> packOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>>);
            packOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>>(1);
            packOperationTable["Polymorphic"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>(this.PackValueOfPolymorphic);
            this._packOperationTable = packOperationTable;
            System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>[] unpackOperationList = default(System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>[]);
            unpackOperationList = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>[1];
            unpackOperationList[0] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>(this.UnpackValueOfPolymorphic);
            this._unpackOperationList = unpackOperationList;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>> unpackOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>>);
            unpackOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>>(1);
            unpackOperationTable["Polymorphic"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>(this.UnpackValueOfPolymorphic);
            this._unpackOperationTable = unpackOperationTable;
            this._memberNames = new string[] {
                    "Polymorphic"};
            this.this_PackValueOfPolymorphicDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>(this.PackValueOfPolymorphic);
            this.this_SetUnpackedValueOfPolymorphicDelegate = new System.Action<MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, object>(this.SetUnpackedValueOfPolymorphic);
            this.this_UnpackValueOfPolymorphicDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject, int, int>(this.UnpackValueOfPolymorphic);
        }
        
        private void PackValueOfPolymorphic(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject objectTree) {
            this._serializer0.PackTo(packer, objectTree.Polymorphic);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject objectTree) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                MsgPack.Serialization.PackHelpers.PackToArray(packer, objectTree, this._packOperationList);
            }
            else {
                MsgPack.Serialization.PackHelpers.PackToMap(packer, objectTree, this._packOperationTable);
            }
        }
        
        private void SetUnpackedValueOfPolymorphic(MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject unpackingContext, object unpackedValue) {
            this._methodBasePolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject_set_Polymorphic0.Invoke(unpackingContext, new object[] {
                        unpackedValue});
        }
        
        private void UnpackValueOfPolymorphic(MsgPack.Unpacker unpacker, MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(object), "Polymorphic", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfPolymorphicDelegate);
        }
        
        protected internal override MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject result = default(MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject);
            result = new MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArray(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>(), this._memberNames, this._unpackOperationList);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMap(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.PolymorphicMemberTypeKnownType_PolymorphicPrivateSetterPropertyAndConstructorAsObject>(), this._unpackOperationTable);
            }
        }
    }
}
