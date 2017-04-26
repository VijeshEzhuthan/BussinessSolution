using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "ValidatedUserLogin?userName={userName}&password={password}", Method = "GET", RequestFormat = WebMessageFormat.Xml)]
        bool ValidatedUserLogin(string userName, string password);
    }

    public class UnitOfMeasureInfo
    {
        private int _unitID;
        private string _unitOfMeasure;

        public int UnitID
        {
            get { return _unitID; }
            set { _unitID = value; }
        }

        public string UnitOfMeasure
        {
            get { return _unitOfMeasure; }
            set { _unitOfMeasure = value; }
        }
    }

    public class VendorInfo
    {
        private int _vendorID;
        private string _vendorName;

        public int VendorID
        {
            get { return _vendorID; }
            set { _vendorID = value; }
        }

        public string VendorName
        {
            get { return _vendorName; }
            set { _vendorName = value; }
        }
    }
}
