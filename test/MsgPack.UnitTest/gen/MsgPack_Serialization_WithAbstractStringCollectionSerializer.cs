﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.7.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_WithAbstractStringCollectionSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.WithAbstractStringCollection> {
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.IList<string>> _serializer0;
        
        private System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection> this_PackValueOfCollectionDelegate;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>> _packOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>> _packOperationTable;
        
        private System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_PackValueOfCollectionAsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _packOperationTableAsync;
        
        private System.Action<MsgPack.Serialization.WithAbstractStringCollection, System.Collections.Generic.IList<string>> this_SetUnpackedValueOfCollectionDelegate;
        
        private System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int> this_UnpackValueOfCollectionDelegate;
        
        private System.Collections.Generic.IList<string> _memberNames;
        
        private System.Collections.Generic.IList<System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>> _unpackOperationList;
        
        private System.Collections.Generic.IDictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>> _unpackOperationTable;
        
        private System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task> this_UnpackValueOfCollectionAsyncDelegate;
        
        private System.Collections.Generic.IList<System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationListAsync;
        
        private System.Collections.Generic.IDictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> _unpackOperationTableAsync;
        
        public MsgPack_Serialization_WithAbstractStringCollectionSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            MsgPack.Serialization.PolymorphismSchema schema0 = default(MsgPack.Serialization.PolymorphismSchema);
            schema0 = null;
            this._serializer0 = context.GetSerializer<System.Collections.Generic.IList<string>>(schema0);
            System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>[] packOperationList = default(System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>[]);
            packOperationList = new System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>[1];
            packOperationList[0] = new System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>(this.PackValueOfCollection);
            this._packOperationList = packOperationList;
            System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] packOperationListAsync = default(System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            packOperationListAsync = new System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>[1];
            packOperationListAsync[0] = new System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionAsync);
            this._packOperationListAsync = packOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>> packOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>>);
            packOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>>(1);
            packOperationTable["Collection"] = new System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>(this.PackValueOfCollection);
            this._packOperationTable = packOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>> packOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            packOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(1);
            packOperationTableAsync["Collection"] = new System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionAsync);
            this._packOperationTableAsync = packOperationTableAsync;
            System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>[] unpackOperationList = default(System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>[]);
            unpackOperationList = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>[1];
            unpackOperationList[0] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>(this.UnpackValueOfCollection);
            this._unpackOperationList = unpackOperationList;
            System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[] unpackOperationListAsync = default(System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[]);
            unpackOperationListAsync = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>[1];
            unpackOperationListAsync[0] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionAsync);
            this._unpackOperationListAsync = unpackOperationListAsync;
            System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>> unpackOperationTable = default(System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>>);
            unpackOperationTable = new System.Collections.Generic.Dictionary<string, System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>>(1);
            unpackOperationTable["Collection"] = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>(this.UnpackValueOfCollection);
            this._unpackOperationTable = unpackOperationTable;
            System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>> unpackOperationTableAsync = default(System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>);
            unpackOperationTableAsync = new System.Collections.Generic.Dictionary<string, System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>>(1);
            unpackOperationTableAsync["Collection"] = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionAsync);
            this._unpackOperationTableAsync = unpackOperationTableAsync;
            this._memberNames = new string[] {
                    "Collection"};
            this.this_PackValueOfCollectionDelegate = new System.Action<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection>(this.PackValueOfCollection);
            this.this_PackValueOfCollectionAsyncDelegate = new System.Func<MsgPack.Packer, MsgPack.Serialization.WithAbstractStringCollection, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.PackValueOfCollectionAsync);
            this.this_SetUnpackedValueOfCollectionDelegate = new System.Action<MsgPack.Serialization.WithAbstractStringCollection, System.Collections.Generic.IList<string>>(this.SetUnpackedValueOfCollection);
            this.this_UnpackValueOfCollectionDelegate = new System.Action<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int>(this.UnpackValueOfCollection);
            this.this_UnpackValueOfCollectionAsyncDelegate = new System.Func<MsgPack.Unpacker, MsgPack.Serialization.WithAbstractStringCollection, int, int, System.Threading.CancellationToken, System.Threading.Tasks.Task>(this.UnpackValueOfCollectionAsync);
        }
        
        private void PackValueOfCollection(MsgPack.Packer packer, MsgPack.Serialization.WithAbstractStringCollection objectTree) {
            this._serializer0.PackTo(packer, objectTree.Collection);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.WithAbstractStringCollection objectTree) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                MsgPack.Serialization.PackHelpers.PackToArray(packer, objectTree, this._packOperationList);
            }
            else {
                MsgPack.Serialization.PackHelpers.PackToMap(packer, objectTree, this._packOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task PackValueOfCollectionAsync(MsgPack.Packer packer, MsgPack.Serialization.WithAbstractStringCollection objectTree, System.Threading.CancellationToken cancellationToken) {
            return this._serializer0.PackToAsync(packer, objectTree.Collection, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task PackToAsyncCore(MsgPack.Packer packer, MsgPack.Serialization.WithAbstractStringCollection objectTree, System.Threading.CancellationToken cancellationToken) {
            if ((this.OwnerContext.SerializationMethod == MsgPack.Serialization.SerializationMethod.Array)) {
                return MsgPack.Serialization.PackHelpers.PackToArrayAsync(packer, objectTree, this._packOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.PackHelpers.PackToMapAsync(packer, objectTree, this._packOperationTableAsync, cancellationToken);
            }
        }
        
        private void SetUnpackedValueOfCollection(MsgPack.Serialization.WithAbstractStringCollection unpackingContext, System.Collections.Generic.IList<string> unpackedValue) {
            unpackingContext.Collection = unpackedValue;
        }
        
        private void UnpackValueOfCollection(MsgPack.Unpacker unpacker, MsgPack.Serialization.WithAbstractStringCollection unpackingContext, int indexOfItem, int itemsCount) {
            MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValue(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(System.Collections.Generic.IList<string>), "Collection", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfCollectionDelegate);
        }
        
        protected internal override MsgPack.Serialization.WithAbstractStringCollection UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.WithAbstractStringCollection result = default(MsgPack.Serialization.WithAbstractStringCollection);
            result = new MsgPack.Serialization.WithAbstractStringCollection();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArray(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.WithAbstractStringCollection>(), this._memberNames, this._unpackOperationList);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMap(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.WithAbstractStringCollection>(), this._unpackOperationTable);
            }
        }
        
        private System.Threading.Tasks.Task UnpackValueOfCollectionAsync(MsgPack.Unpacker unpacker, MsgPack.Serialization.WithAbstractStringCollection unpackingContext, int indexOfItem, int itemsCount, System.Threading.CancellationToken cancellationToken) {
            return MsgPack.Serialization.UnpackHelpers.UnpackReferenceTypeValueAsync(unpacker, unpackingContext, this._serializer0, itemsCount, indexOfItem, typeof(System.Collections.Generic.IList<string>), "Collection", MsgPack.Serialization.NilImplication.MemberDefault, null, this.this_SetUnpackedValueOfCollectionDelegate, cancellationToken);
        }
        
        protected internal override System.Threading.Tasks.Task<MsgPack.Serialization.WithAbstractStringCollection> UnpackFromAsyncCore(MsgPack.Unpacker unpacker, System.Threading.CancellationToken cancellationToken) {
            MsgPack.Serialization.WithAbstractStringCollection result = default(MsgPack.Serialization.WithAbstractStringCollection);
            result = new MsgPack.Serialization.WithAbstractStringCollection();
            if (unpacker.IsArrayHeader) {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromArrayAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.WithAbstractStringCollection>(), this._memberNames, this._unpackOperationListAsync, cancellationToken);
            }
            else {
                return MsgPack.Serialization.UnpackHelpers.UnpackFromMapAsync(unpacker, result, MsgPack.Serialization.UnpackHelpers.GetIdentity<MsgPack.Serialization.WithAbstractStringCollection>(), this._unpackOperationTableAsync, cancellationToken);
            }
        }
    }
}
