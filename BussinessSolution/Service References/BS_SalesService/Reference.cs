﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinessSolution.BS_SalesService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NextInvoiceInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class NextInvoiceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int InvoiceNumField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long SalesIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InvoiceNum {
            get {
                return this.InvoiceNumField;
            }
            set {
                if ((this.InvoiceNumField.Equals(value) != true)) {
                    this.InvoiceNumField = value;
                    this.RaisePropertyChanged("InvoiceNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long SalesID {
            get {
                return this.SalesIDField;
            }
            set {
                if ((this.SalesIDField.Equals(value) != true)) {
                    this.SalesIDField = value;
                    this.RaisePropertyChanged("SalesID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SalesInvoiceInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class SalesInvoiceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int InvoiceNumField;
        
        private bool IsHoldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ItemCountField;
        
        private decimal NetAmountField;
        
        private decimal PaidAmountField;
        
        private long SalesIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BussinessSolution.BS_SalesService.SalesItemInfo[] SalesItemListField;
        
        private decimal TotalAmountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int InvoiceNum {
            get {
                return this.InvoiceNumField;
            }
            set {
                if ((this.InvoiceNumField.Equals(value) != true)) {
                    this.InvoiceNumField = value;
                    this.RaisePropertyChanged("InvoiceNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsHold {
            get {
                return this.IsHoldField;
            }
            set {
                if ((this.IsHoldField.Equals(value) != true)) {
                    this.IsHoldField = value;
                    this.RaisePropertyChanged("IsHold");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ItemCount {
            get {
                return this.ItemCountField;
            }
            set {
                if ((this.ItemCountField.Equals(value) != true)) {
                    this.ItemCountField = value;
                    this.RaisePropertyChanged("ItemCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal NetAmount {
            get {
                return this.NetAmountField;
            }
            set {
                if ((this.NetAmountField.Equals(value) != true)) {
                    this.NetAmountField = value;
                    this.RaisePropertyChanged("NetAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal PaidAmount {
            get {
                return this.PaidAmountField;
            }
            set {
                if ((this.PaidAmountField.Equals(value) != true)) {
                    this.PaidAmountField = value;
                    this.RaisePropertyChanged("PaidAmount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long SalesID {
            get {
                return this.SalesIDField;
            }
            set {
                if ((this.SalesIDField.Equals(value) != true)) {
                    this.SalesIDField = value;
                    this.RaisePropertyChanged("SalesID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BussinessSolution.BS_SalesService.SalesItemInfo[] SalesItemList {
            get {
                return this.SalesItemListField;
            }
            set {
                if ((object.ReferenceEquals(this.SalesItemListField, value) != true)) {
                    this.SalesItemListField = value;
                    this.RaisePropertyChanged("SalesItemList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal TotalAmount {
            get {
                return this.TotalAmountField;
            }
            set {
                if ((this.TotalAmountField.Equals(value) != true)) {
                    this.TotalAmountField = value;
                    this.RaisePropertyChanged("TotalAmount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SalesItemInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class SalesItemInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal AmountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal DiscountRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal QtyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RetailRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VendorNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Amount {
            get {
                return this.AmountField;
            }
            set {
                if ((this.AmountField.Equals(value) != true)) {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal DiscountRate {
            get {
                return this.DiscountRateField;
            }
            set {
                if ((this.DiscountRateField.Equals(value) != true)) {
                    this.DiscountRateField = value;
                    this.RaisePropertyChanged("DiscountRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Qty {
            get {
                return this.QtyField;
            }
            set {
                if ((this.QtyField.Equals(value) != true)) {
                    this.QtyField = value;
                    this.RaisePropertyChanged("Qty");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal RetailRate {
            get {
                return this.RetailRateField;
            }
            set {
                if ((this.RetailRateField.Equals(value) != true)) {
                    this.RetailRateField = value;
                    this.RaisePropertyChanged("RetailRate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Unit {
            get {
                return this.UnitField;
            }
            set {
                if ((object.ReferenceEquals(this.UnitField, value) != true)) {
                    this.UnitField = value;
                    this.RaisePropertyChanged("Unit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VendorName {
            get {
                return this.VendorNameField;
            }
            set {
                if ((object.ReferenceEquals(this.VendorNameField, value) != true)) {
                    this.VendorNameField = value;
                    this.RaisePropertyChanged("VendorName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BS_SalesService.ISalesService")]
    public interface ISalesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/GetNextInvoiceInfo", ReplyAction="http://tempuri.org/ISalesService/GetNextInvoiceInfoResponse")]
        BussinessSolution.BS_SalesService.NextInvoiceInfo GetNextInvoiceInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/GetNextInvoiceInfo", ReplyAction="http://tempuri.org/ISalesService/GetNextInvoiceInfoResponse")]
        System.Threading.Tasks.Task<BussinessSolution.BS_SalesService.NextInvoiceInfo> GetNextInvoiceInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/InsertOrUpdateSalesInfo", ReplyAction="http://tempuri.org/ISalesService/InsertOrUpdateSalesInfoResponse")]
        int InsertOrUpdateSalesInfo(BussinessSolution.BS_SalesService.SalesInvoiceInfo salesInvoiceInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/InsertOrUpdateSalesInfo", ReplyAction="http://tempuri.org/ISalesService/InsertOrUpdateSalesInfoResponse")]
        System.Threading.Tasks.Task<int> InsertOrUpdateSalesInfoAsync(BussinessSolution.BS_SalesService.SalesInvoiceInfo salesInvoiceInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/GetSaleHoldList", ReplyAction="http://tempuri.org/ISalesService/GetSaleHoldListResponse")]
        BussinessSolution.BS_SalesService.SalesInvoiceInfo[] GetSaleHoldList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesService/GetSaleHoldList", ReplyAction="http://tempuri.org/ISalesService/GetSaleHoldListResponse")]
        System.Threading.Tasks.Task<BussinessSolution.BS_SalesService.SalesInvoiceInfo[]> GetSaleHoldListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISalesServiceChannel : BussinessSolution.BS_SalesService.ISalesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SalesServiceClient : System.ServiceModel.ClientBase<BussinessSolution.BS_SalesService.ISalesService>, BussinessSolution.BS_SalesService.ISalesService {
        
        public SalesServiceClient() {
        }
        
        public SalesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SalesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BussinessSolution.BS_SalesService.NextInvoiceInfo GetNextInvoiceInfo() {
            return base.Channel.GetNextInvoiceInfo();
        }
        
        public System.Threading.Tasks.Task<BussinessSolution.BS_SalesService.NextInvoiceInfo> GetNextInvoiceInfoAsync() {
            return base.Channel.GetNextInvoiceInfoAsync();
        }
        
        public int InsertOrUpdateSalesInfo(BussinessSolution.BS_SalesService.SalesInvoiceInfo salesInvoiceInfo) {
            return base.Channel.InsertOrUpdateSalesInfo(salesInvoiceInfo);
        }
        
        public System.Threading.Tasks.Task<int> InsertOrUpdateSalesInfoAsync(BussinessSolution.BS_SalesService.SalesInvoiceInfo salesInvoiceInfo) {
            return base.Channel.InsertOrUpdateSalesInfoAsync(salesInvoiceInfo);
        }
        
        public BussinessSolution.BS_SalesService.SalesInvoiceInfo[] GetSaleHoldList() {
            return base.Channel.GetSaleHoldList();
        }
        
        public System.Threading.Tasks.Task<BussinessSolution.BS_SalesService.SalesInvoiceInfo[]> GetSaleHoldListAsync() {
            return base.Channel.GetSaleHoldListAsync();
        }
    }
}