using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonService" in both code and config file together.
    [ServiceContract]
    public interface ICommonService
    {
         [OperationContract]
        [WebInvoke(UriTemplate = "GetUnitOfMeasure", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        List<UnitOfMeasureInfo> GetUnitOfMeasure();

         [OperationContract]
         [WebInvoke(UriTemplate = "GetVendorInfo?vendorName={vendorName}", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
         List<VendorInfo> GetVendorInfo(string vendorName);

         [OperationContract]
         [WebInvoke(UriTemplate = "GetCompanyInfo", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
         CompanyInfo GetCompanyInfo();
    }

    [DataContract]
    public class CompanyInfo
    {
        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Pincode { get; set; }

        [DataMember]
        public string TinNum { get; set; }

        [DataMember]
        public string Phone1 { get; set; }

        [DataMember]
        public string Phone2 { get; set; }
    }

    [DataContract]
    public class PagerInfo
    {
        private int _pageSize = 0;
        private int _pageIndex = 0;
        private string _filter = string.Empty;

        [DataMember(IsRequired=true)]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        [DataMember(IsRequired=true)]
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        [DataMember]
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }
    }

}
