using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMasterDataService" in both code and config file together.
    [ServiceContract]
    public interface IMasterDataService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetSupplierInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<SupplierInfo> GetSupplierInfo(PagerInfo pagerInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertSupplierInfo?supplierInfo={supplierInfo}", Method = "SET", RequestFormat = WebMessageFormat.Xml)]
        bool InsertOrUpdateSupplierInfo(SupplierInfo supplierInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetProductInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<ProductInfo> GetProductInfo(PagerInfo pagerInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertOrUpdateProductInfo?productInfo={productInfo}", Method = "SET", RequestFormat = WebMessageFormat.Xml)]
        bool InsertOrUpdateProductInfo(ProductInfo productInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetCategoryInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<CategoryInfo> GetCategoryInfo(PagerInfo pagerInfo);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetGroupCategoryInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<CategoryInfo> GetGroupCategoryInfo(PagerInfo pagerInfo);

    }

    [DataContract]
    public class SupplierInfo
    {
        private Int64 _supplierID = 0;
        private string _supplerName = string.Empty;
        private string _address1 = string.Empty;
        private string _pincode = string.Empty;
        private string _state = string.Empty;
        private string _tin = string.Empty;
        private string _phone = string.Empty;
        private bool _isManufacture = false;

        [DataMember(IsRequired = true)]
        public Int64 SupplierID
        {
            get { return _supplierID; }
            set { _supplierID = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return _supplerName; }
            set { _supplerName = value; }
        }

        [DataMember]
        public string Address
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        [DataMember]
        public string Pincode
        {
            get { return _pincode; }
            set { _pincode = value; }
        }

        [DataMember]
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        [DataMember]
        public string TIN
        {
            get { return _tin; }
            set { _tin = value; }
        }

        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        [DataMember(IsRequired = true)]
        public bool IsManufacture
        {
            get { return _isManufacture; }
            set { _isManufacture = value; }
        }
    }

    [DataContract]
    public class CategoryInfo
    {
        private int _categoryID = 0;
        private string _categoryCode = string.Empty;
        private string _categoryName = string.Empty;

        [DataMember]
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        [DataMember]
        public string CategoryCode
        {
            get { return _categoryCode; }
            set { _categoryCode = value; }
        }

        [DataMember]
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
    }

    [DataContract]
    public class ProductInfo
    {
        private string _displayProductName;
        private string _productDescription;
        private int _productCode;
        private char _isTaxable = 'N';
        private char _isGiftItem = 'N';
        private char _isDifferentRateInSize = 'N';
        private decimal _profitPrecentage = 0;
        private CategoryInfo _categoryInfo = new CategoryInfo();
        private SupplierInfo _supplierInfo = new SupplierInfo();

        [DataMember]
        public string DisplayProductName
        {
            get { return _displayProductName; }
            set { _displayProductName = value; }
        }

        [DataMember]
        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        [DataMember(IsRequired = true)]
        public int ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }


        [DataMember]
        public char IsGiftItem
        {
            get { return _isGiftItem; }
            set { _isGiftItem = value; }
        }

        [DataMember]
        public char IsTaxableItem
        {
            get { return _isTaxable; }
            set { _isTaxable = value; }
        }

        [DataMember]
        public char IsDifferentRateInSize
        {
            get { return _isDifferentRateInSize; }
            set { _isDifferentRateInSize = value; }
        }

        [DataMember(IsRequired = true)]
        public decimal ProfitPrecentage
        {
            get { return _profitPrecentage; }
            set { _profitPrecentage = value; }
        }

        [DataMember]
        public SupplierInfo VendorInfo
        {
            get { return _supplierInfo; }
            set { _supplierInfo = value; }
        }

        [DataMember(IsRequired = true)]
        public CategoryInfo ProductCategoryInfo
        {
            get { return _categoryInfo; }
            set { _categoryInfo = value; }
        }


    }
}
