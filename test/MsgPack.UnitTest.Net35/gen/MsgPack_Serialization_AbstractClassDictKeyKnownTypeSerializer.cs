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
    public class MsgPack_Serialization_AbstractClassDictKeyKnownTypeSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.AbstractClassDictKeyKnownType> {
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>> _serializer0;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType> this_PackValueOfValueDelegate;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>> _packOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>> _packOperationTable;
        
        private System.Action<MsgPack.Serialization.AbstractClassDictKeyKnownType, System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>> this_SetUnpackedValueOfValueDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int> this_UnpackValueOfValueDelegate;
        
        private System.Collections.Generic.IList<string> _memberNames;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>> _unpackOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>> _unpackOperationTable;
        
        public MsgPack_Serialization_AbstractClassDictKeyKnownTypeSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            MsgPack.Serialization.PolymorphismSchema keysSchema0 = default(MsgPack.Serialization.PolymorphismSchema);
            System.Collections.Generic.Dictionary<string, System.Type> keysSchemaTypeMap0 = default(System.Collections.Generic.Dictionary<string, System.Type>);
            keysSchemaTypeMap0 = new System.Collections.Generic.Dictionary<string, System.Type>(1);
            keysSchemaTypeMap0.Add("1", typeof(MsgPack.Serialization.FileEntry));
            keysSchema0 = MsgPack.Serialization.PolymorphismSchema.ForPolymorphicObject(typeof(MsgPack.Serialization.AbstractFileSystemEntry), keysSchemaTypeMap0);
            schema0 = MsgPack.Serialization.PolymorphismSchema.ForContextSpecifiedDictionary(typeof(System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>), keysSchema0, null);
            this._serializer0 = context.GetSerializer<System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>>(schema0);
            System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>[] packOperationList = default(System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>[]);
            packOperationList = new System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>[1];
            packOperationList[0] = new System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>(this.PackValueOfValue);
            this._packOperationList = packOperationList;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>> packOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>>);
            packOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>>(1);
            packOperationTable["Value"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>(this.PackValueOfValue);
            this._packOperationTable = packOperationTable;
            System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>[] unpackOperationList = default(System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>[]);
            unpackOperationList = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>[1];
            unpackOperationList[0] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>(this.UnpackValueOfValue);
            this._unpackOperationList = unpackOperationList;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>> unpackOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>>);
            unpackOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>>(1);
            unpackOperationTable["Value"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>(this.UnpackValueOfValue);
            this._unpackOperationTable = unpackOperationTable;
            this._memberNames = new string[] {
                    "Value"};
            this.this_PackValueOfValueDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.AbstractClassDictKeyKnownType>(this.PackValueOfValue);
            this.this_SetUnpackedValueOfValueDelegate = new System.Action<MsgPack.Serialization.AbstractClassDictKeyKnownType, System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>>(this.SetUnpackedValueOfValue);
            this.this_UnpackValueOfValueDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType, int, int>(this.UnpackValueOfValue);
        }
        
        private void PackValueOfValue(MsgPack.Packer packer, MsgPack.Serialization.AbstractClassDictKeyKnownType objectTree) {
            this._serializer0.PackTo(packer, objectTree.Value);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.AbstractClassDictKeyKnownType objectTree) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                MsgPack.Serialization.PackHelpers.PackToArray(packer, objectTree, this._packOperationList);
            }
            else {
                MsgPack.Serialization.PackHelpers.PackToMap(packer, objectTree, this._packOperationTable);
            }
        }
        
        private void SetUnpackedValueOfValue(MsgPack.Serialization.AbstractClassDictKeyKnownType unpackingContext, System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string> unpackedValue) {
            unpackingContext.Value = unpackedValue;
        }
        
        private void UnpackValueOfValue(MsgPack.Unpacker unpacker, MsgPack.Serialization.AbstractClassDictKeyKnownType unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(System.Collections.Generic.IDictionary<MsgPack.Serialization.AbstractFileSystemEntry, string>), "Value", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfValueDelegate);
        }
        
        protected internal override MsgPack.Serialization.AbstractClassDictKeyKnownType UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.AbstractClassDictKeyKnownType result = default(MsgPack.Serialization.AbstractClassDictKeyKnownType);
            result = new MsgPack.Serialization.AbstractClassDictKeyKnownType();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArray(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.AbstractClassDictKeyKnownType>(), this._memberNames, this._unpackOperationList);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMap(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.AbstractClassDictKeyKnownType>(), this._unpackOperationTable);
            }
        }
    }
}
