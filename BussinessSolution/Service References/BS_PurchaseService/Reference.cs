﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinessSolution.BS_PurchaseService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StockInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class StockInfo : BussinessSolution.BS_PurchaseService.ProductInfo {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BussinessSolution.BS_PurchaseService.StockPriceInfo[] QtyPriceInfoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BussinessSolution.BS_PurchaseService.StockPriceInfo[] QtyPriceInfo {
            get {
                return this.QtyPriceInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.QtyPriceInfoField, value) != true)) {
                    this.QtyPriceInfoField = value;
                    this.RaisePropertyChanged("QtyPriceInfo");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BussinessSolution.BS_PurchaseService.PurchaseInfo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(BussinessSolution.BS_PurchaseService.StockInfo))]
    public partial class ProductInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DisplayProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char IsDifferentRateInSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char IsGiftItemField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private char IsTaxableItemField;
        
        private BussinessSolution.BS_PurchaseService.CategoryInfo ProductCategoryInfoField;
        
        private int ProductCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BussinessSolution.BS_PurchaseService.SupplierInfo VendorInfoField;
        
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
        public string DisplayProductName {
            get {
                return this.DisplayProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DisplayProductNameField, value) != true)) {
                    this.DisplayProductNameField = value;
                    this.RaisePropertyChanged("DisplayProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char IsDifferentRateInSize {
            get {
                return this.IsDifferentRateInSizeField;
            }
            set {
                if ((this.IsDifferentRateInSizeField.Equals(value) != true)) {
                    this.IsDifferentRateInSizeField = value;
                    this.RaisePropertyChanged("IsDifferentRateInSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char IsGiftItem {
            get {
                return this.IsGiftItemField;
            }
            set {
                if ((this.IsGiftItemField.Equals(value) != true)) {
                    this.IsGiftItemField = value;
                    this.RaisePropertyChanged("IsGiftItem");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public char IsTaxableItem {
            get {
                return this.IsTaxableItemField;
            }
            set {
                if ((this.IsTaxableItemField.Equals(value) != true)) {
                    this.IsTaxableItemField = value;
                    this.RaisePropertyChanged("IsTaxableItem");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public BussinessSolution.BS_PurchaseService.CategoryInfo ProductCategoryInfo {
            get {
                return this.ProductCategoryInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductCategoryInfoField, value) != true)) {
                    this.ProductCategoryInfoField = value;
                    this.RaisePropertyChanged("ProductCategoryInfo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ProductCode {
            get {
                return this.ProductCodeField;
            }
            set {
                if ((this.ProductCodeField.Equals(value) != true)) {
                    this.ProductCodeField = value;
                    this.RaisePropertyChanged("ProductCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductDescription {
            get {
                return this.ProductDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductDescriptionField, value) != true)) {
                    this.ProductDescriptionField = value;
                    this.RaisePropertyChanged("ProductDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BussinessSolution.BS_PurchaseService.SupplierInfo VendorInfo {
            get {
                return this.VendorInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.VendorInfoField, value) != true)) {
                    this.VendorInfoField = value;
                    this.RaisePropertyChanged("VendorInfo");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoryInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class CategoryInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryNameField;
        
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
        public string CategoryCode {
            get {
                return this.CategoryCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryCodeField, value) != true)) {
                    this.CategoryCodeField = value;
                    this.RaisePropertyChanged("CategoryCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CategoryID {
            get {
                return this.CategoryIDField;
            }
            set {
                if ((this.CategoryIDField.Equals(value) != true)) {
                    this.CategoryIDField = value;
                    this.RaisePropertyChanged("CategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CategoryName {
            get {
                return this.CategoryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryNameField, value) != true)) {
                    this.CategoryNameField = value;
                    this.RaisePropertyChanged("CategoryName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplierInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class SupplierInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        private bool IsManufactureField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PincodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        private long SupplierIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SupplierNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TINField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool IsManufacture {
            get {
                return this.IsManufactureField;
            }
            set {
                if ((this.IsManufactureField.Equals(value) != true)) {
                    this.IsManufactureField = value;
                    this.RaisePropertyChanged("IsManufacture");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pincode {
            get {
                return this.PincodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PincodeField, value) != true)) {
                    this.PincodeField = value;
                    this.RaisePropertyChanged("Pincode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public long SupplierID {
            get {
                return this.SupplierIDField;
            }
            set {
                if ((this.SupplierIDField.Equals(value) != true)) {
                    this.SupplierIDField = value;
                    this.RaisePropertyChanged("SupplierID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SupplierName {
            get {
                return this.SupplierNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SupplierNameField, value) != true)) {
                    this.SupplierNameField = value;
                    this.RaisePropertyChanged("SupplierName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TIN {
            get {
                return this.TINField;
            }
            set {
                if ((object.ReferenceEquals(this.TINField, value) != true)) {
                    this.TINField = value;
                    this.RaisePropertyChanged("TIN");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="PurchaseInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class PurchaseInfo : BussinessSolution.BS_PurchaseService.ProductInfo {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal QtyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RetailRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UnitIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UoMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal WholeSaleRateField;
        
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
        public int UnitID {
            get {
                return this.UnitIDField;
            }
            set {
                if ((this.UnitIDField.Equals(value) != true)) {
                    this.UnitIDField = value;
                    this.RaisePropertyChanged("UnitID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UoM {
            get {
                return this.UoMField;
            }
            set {
                if ((object.ReferenceEquals(this.UoMField, value) != true)) {
                    this.UoMField = value;
                    this.RaisePropertyChanged("UoM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal WholeSaleRate {
            get {
                return this.WholeSaleRateField;
            }
            set {
                if ((this.WholeSaleRateField.Equals(value) != true)) {
                    this.WholeSaleRateField = value;
                    this.RaisePropertyChanged("WholeSaleRate");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StockPriceInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class StockPriceInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal RetailRateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UnitIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UoMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal WholeSaleRateField;
        
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
        public int UnitID {
            get {
                return this.UnitIDField;
            }
            set {
                if ((this.UnitIDField.Equals(value) != true)) {
                    this.UnitIDField = value;
                    this.RaisePropertyChanged("UnitID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UoM {
            get {
                return this.UoMField;
            }
            set {
                if ((object.ReferenceEquals(this.UoMField, value) != true)) {
                    this.UoMField = value;
                    this.RaisePropertyChanged("UoM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal WholeSaleRate {
            get {
                return this.WholeSaleRateField;
            }
            set {
                if ((this.WholeSaleRateField.Equals(value) != true)) {
                    this.WholeSaleRateField = value;
                    this.RaisePropertyChanged("WholeSaleRate");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="PurchaseDetaiInfo", Namespace="http://schemas.datacontract.org/2004/07/BussinessSolutionServiceBLL")]
    [System.SerializableAttribute()]
    public partial class PurchaseDetaiInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int CreateDateField;
        
        private int InvoiceDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InvoiceNumField;
        
        private int PurchaseIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BussinessSolution.BS_PurchaseService.PurchaseInfo[] PurchaseitemListField;
        
        private decimal TotalAmountField;
        
        private int VendorIDField;
        
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
        public int CreateDate {
            get {
                return this.CreateDateField;
            }
            set {
                if ((this.CreateDateField.Equals(value) != true)) {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int InvoiceDate {
            get {
                return this.InvoiceDateField;
            }
            set {
                if ((this.InvoiceDateField.Equals(value) != true)) {
                    this.InvoiceDateField = value;
                    this.RaisePropertyChanged("InvoiceDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string InvoiceNum {
            get {
                return this.InvoiceNumField;
            }
            set {
                if ((object.ReferenceEquals(this.InvoiceNumField, value) != true)) {
                    this.InvoiceNumField = value;
                    this.RaisePropertyChanged("InvoiceNum");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int PurchaseID {
            get {
                return this.PurchaseIDField;
            }
            set {
                if ((this.PurchaseIDField.Equals(value) != true)) {
                    this.PurchaseIDField = value;
                    this.RaisePropertyChanged("PurchaseID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public BussinessSolution.BS_PurchaseService.PurchaseInfo[] PurchaseitemList {
            get {
                return this.PurchaseitemListField;
            }
            set {
                if ((object.ReferenceEquals(this.PurchaseitemListField, value) != true)) {
                    this.PurchaseitemListField = value;
                    this.RaisePropertyChanged("PurchaseitemList");
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int VendorID {
            get {
                return this.VendorIDField;
            }
            set {
                if ((this.VendorIDField.Equals(value) != true)) {
                    this.VendorIDField = value;
                    this.RaisePropertyChanged("VendorID");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BS_PurchaseService.IPurchaseService")]
    public interface IPurchaseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchaseService/GetProductInfoByNameOrCode", ReplyAction="http://tempuri.org/IPurchaseService/GetProductInfoByNameOrCodeResponse")]
        BussinessSolution.BS_PurchaseService.StockInfo[] GetProductInfoByNameOrCode(string description, int productcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchaseService/GetProductInfoByNameOrCode", ReplyAction="http://tempuri.org/IPurchaseService/GetProductInfoByNameOrCodeResponse")]
        System.Threading.Tasks.Task<BussinessSolution.BS_PurchaseService.StockInfo[]> GetProductInfoByNameOrCodeAsync(string description, int productcode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchaseService/InsertPurchaseInfo", ReplyAction="http://tempuri.org/IPurchaseService/InsertPurchaseInfoResponse")]
        bool InsertPurchaseInfo(BussinessSolution.BS_PurchaseService.PurchaseDetaiInfo purhcaseDetailInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPurchaseService/InsertPurchaseInfo", ReplyAction="http://tempuri.org/IPurchaseService/InsertPurchaseInfoResponse")]
        System.Threading.Tasks.Task<bool> InsertPurchaseInfoAsync(BussinessSolution.BS_PurchaseService.PurchaseDetaiInfo purhcaseDetailInfo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPurchaseServiceChannel : BussinessSolution.BS_PurchaseService.IPurchaseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PurchaseServiceClient : System.ServiceModel.ClientBase<BussinessSolution.BS_PurchaseService.IPurchaseService>, BussinessSolution.BS_PurchaseService.IPurchaseService {
        
        public PurchaseServiceClient() {
        }
        
        public PurchaseServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PurchaseServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PurchaseServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PurchaseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public BussinessSolution.BS_PurchaseService.StockInfo[] GetProductInfoByNameOrCode(string description, int productcode) {
            return base.Channel.GetProductInfoByNameOrCode(description, productcode);
        }
        
        public System.Threading.Tasks.Task<BussinessSolution.BS_PurchaseService.StockInfo[]> GetProductInfoByNameOrCodeAsync(string description, int productcode) {
            return base.Channel.GetProductInfoByNameOrCodeAsync(description, productcode);
        }
        
        public bool InsertPurchaseInfo(BussinessSolution.BS_PurchaseService.PurchaseDetaiInfo purhcaseDetailInfo) {
            return base.Channel.InsertPurchaseInfo(purhcaseDetailInfo);
        }
        
        public System.Threading.Tasks.Task<bool> InsertPurchaseInfoAsync(BussinessSolution.BS_PurchaseService.PurchaseDetaiInfo purhcaseDetailInfo) {
            return base.Channel.InsertPurchaseInfoAsync(purhcaseDetailInfo);
        }
    }
}