using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;
using BussinessSolutionServiceDAL;

namespace BussinessSolutionServiceBLL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CommonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CommonService.svc or CommonService.svc.cs at the Solution Explorer and start debugging.
    public class CommonService : ICommonService
    {
        public List<UnitOfMeasureInfo> GetUnitOfMeasure()
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable uomTable = CommonDAL.GetUnitOfMeasure(db);
                List<UnitOfMeasureInfo> uomList = new List<UnitOfMeasureInfo>();
                foreach (DataRow uomRow in uomTable.Rows)
                {
                    UnitOfMeasureInfo uomInfo = new UnitOfMeasureInfo();
                    uomInfo.UnitID = Convert.ToInt32(uomRow["FUOMID"].ToString());
                    uomInfo.UnitOfMeasure = uomRow["FUOMCODE"].ToString();

                    uomList.Add(uomInfo);
                }
                return uomList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VendorInfo> GetVendorInfo(string vendorName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable vendorTable = CommonDAL.GetVendorInfo(db, vendorName);
                List<VendorInfo> vendorList = new List<VendorInfo>();
                foreach (DataRow uomRow in vendorTable.Rows)
                {
                    VendorInfo vendorInfo = new VendorInfo();
                    vendorInfo.VendorID = Convert.ToInt32(uomRow["FSUPPLIERID"].ToString());
                    vendorInfo.VendorName = uomRow["FSUPPLIERNAME"].ToString();

                    vendorList.Add(vendorInfo);
                }
                return vendorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompanyInfo GetCompanyInfo()
        {
            try
            {

                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable companyTable = CommonDAL.GetCompanyInfo(db);
                CompanyInfo companyInfo = new CompanyInfo();
                if (companyTable.Rows.Count>0)
                {
                    companyInfo.Address1 = companyTable.Rows[0]["FADDRESS1"].ToString();
                    companyInfo.Address2 = companyTable.Rows[0]["FADDRESS2"].ToString();
                    companyInfo.CompanyName = companyTable.Rows[0]["FCOMPANYNAME"].ToString();
                    companyInfo.Phone1 = companyTable.Rows[0]["FPHONE1"].ToString();
                    companyInfo.Phone2 = companyTable.Rows[0]["FPHONE2"].ToString();
                    companyInfo.Pincode = companyTable.Rows[0]["FPINCODE"].ToString();
                    companyInfo.State = companyTable.Rows[0]["FSTATE"].ToString();
                    companyInfo.TinNum = companyTable.Rows[0]["FTINNUM"].ToString();

                }
                return companyInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
