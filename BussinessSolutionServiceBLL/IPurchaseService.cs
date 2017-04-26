using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPurchaseService" in both code and config file together.
    [ServiceContract]
    public interface IPurchaseService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetProductInfoByNameOrCode?description={description}&productcode={productcode}", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<StockInfo> GetProductInfoByNameOrCode(string description, int productcode);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertPurchaseInfo?purhcaseDetailInfo={purhcaseDetailInfo}", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        bool InsertPurchaseInfo(PurchaseDetaiInfo purhcaseDetailInfo);
    }

    [DataContract]
    public class PurchaseDetaiInfo
    {
        private int _purchaseID = 0;
        private int _vendorID = 0;
        private int _invoiceDate = 0;
        private string _invoiceNum = string.Empty;
        private int _createDate = 0;
        private decimal _totalAmount = 0;
        private List<PurchaseInfo> _purchaseItemList = new List<PurchaseInfo>();

        [DataMember(IsRequired = true)]
        public int PurchaseID
        {
            get { return _purchaseID; }
            set { _purchaseID = value; }
        }

        [DataMember(IsRequired = true)]
        public int VendorID
        {
            get { return _vendorID; }
            set { _vendorID = value; }
        }


        [DataMember(IsRequired = true)]
        public int InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; }
        }

        [DataMember]
        public string InvoiceNum
        {
            get { return _invoiceNum; }
            set { _invoiceNum = value; }
        }

        [DataMember(IsRequired = true)]
        public int CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        [DataMember]
        public List<PurchaseInfo> PurchaseitemList
        {
            get { return _purchaseItemList; }
            set { _purchaseItemList = value; }
        }

    }
      
    [DataContract]
    public class StockInfo: ProductInfo
    {
        private List<StockPriceInfo> _stockPriceInfo = new List<StockPriceInfo>();

        [DataMember]
        public List<StockPriceInfo> QtyPriceInfo
        {
            get { return _stockPriceInfo; }
            set { _stockPriceInfo = value; }
        }
    }

    [DataContract]
    public class StockPriceInfo
    {
        private decimal _wholeSaleRate = 0;
        private decimal _retailRate = 0;
        private int _unitID = 0;
        private string _uom = string.Empty;
        private decimal _qty = 0;
        private decimal? _size = null;

        [DataMember]
        public decimal RetailRate
        {
            get { return _retailRate; }
            set { _retailRate = value; }
        }

        [DataMember]
        public decimal WholeSaleRate
        {
            get { return _wholeSaleRate; }
            set { _wholeSaleRate = value; }
        }

        [DataMember]
        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }

        [DataMember]
        public string UoM
        {
            get { return _uom; }
            set { _uom = value; }
        }
        
        [DataMember]
        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        [DataMember]
        public decimal? Size
        {
            get { return _size; }
            set { _size = value; }
        }


    }

    [DataContract]
    public class PurchaseInfo : ProductInfo
    {
        private decimal _wholeSaleRate = 0;
        private decimal _retailRate = 0;
        private int _unitID = 0;
        private string _uom = string.Empty;
        private decimal _qty = 0;

        [DataMember]
        public decimal Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        [DataMember]
        public decimal WholeSaleRate
        {
            get { return _wholeSaleRate; }
            set { _wholeSaleRate = value; }
        }

        [DataMember]
        public decimal RetailRate
        {
            get { return _retailRate; }
            set { _retailRate = value; }
        }
        
        [DataMember]
        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }

        [DataMember]
        public string UoM
        {
            get { return _uom; }
            set { _uom = value; }
        }
    }

    
}
