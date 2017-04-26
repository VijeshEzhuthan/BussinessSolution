using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BussinessSolution.BS_CommonService;

namespace BussinessSolution.BLL
{
    public class CommonBLL
    {
        public static List<UnitOfMeasureInfo> GetUnitOfMeasure()
        {
            try
            {
                CommonServiceClient service = new CommonServiceClient();
                return service.GetUnitOfMeasure().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<VendorInfo> GetVendorInfo(string vendorName)
        {
            try
            {
                CommonServiceClient service = new CommonServiceClient();
                return service.GetVendorInfo(vendorName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CompanyInfo GetCompanyInfo()
        {
            try
            {
                CommonServiceClient service = new CommonServiceClient();
                return service.GetCompanyInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
