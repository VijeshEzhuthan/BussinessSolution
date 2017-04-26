using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISalesService" in both code and config file together.
    [ServiceContract]
    public interface ISalesService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetNextInvoiceInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        NextInvoiceInfo GetNextInvoiceInfo();

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertOrUpdateSalesInfo?InsertOrUpdateSalesInfo={salesInvoiceInfo}", Method = "SET", RequestFormat = WebMessageFormat.Xml)]
        Int32 InsertOrUpdateSalesInfo(SalesInvoiceInfo salesInvoiceInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetSaleHoldList", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<SalesInvoiceInfo> GetSaleHoldList();
    }

    public class NextInvoiceInfo
    {
        public Int64 SalesID{ get; set; }
        public int InvoiceNum { get; set; }

    }

    [DataContract]
    public class SalesInvoiceInfo
    {
        private bool _isHold = false;
        private Int64 _salesID = 0;
        private Int32 _invoiceNum = 0;
        private decimal _totalAmount = 0;
        private decimal _netAmount = 0;
        private decimal _paidAmount = 0;
        private int _itemCount = 0;
        private List<SalesItemInfo> _salesItemList = new List<SalesItemInfo>();

        [DataMember(IsRequired = true)]
        public Int64 SalesID
        {
            get { return _salesID; }
            set { _salesID = value; }
        }

        [DataMember(IsRequired = true)]
        public Int32 InvoiceNum
        {
            get { return _invoiceNum; }
            set { _invoiceNum = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal NetAmount
        {
            get { return _netAmount; }
            set { _netAmount = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal PaidAmount
        {
            get { return _paidAmount; }
            set { _paidAmount = value; }
        }

        [DataMember(IsRequired = true)]
        public bool IsHold
        {
            get { return _isHold; }
            set { _isHold = value; }
        }

        [DataMember]
        public int ItemCount
        {
            get { return _itemCount; }
            set { _itemCount = value; }
        }

        [DataMember]
        public List<SalesItemInfo> SalesItemList
        {
            get { return _salesItemList; }
            set { _salesItemList = value; }
        }
    }

    public class SalesItemInfo
    {
        private int _productID = 0;
        private decimal _retailRate = 0;
        private decimal _discountRate = 0;
        private decimal _qty = 0;
        private string _unit = string.Empty;
        private decimal _amount = 0;

        [DataMember(IsRequired = true)]
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal RetailRate
        {
            get { return _retailRate; }
            set { _retailRate = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        [DataMember]
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public string ProductName { get; set; }
    }
}
