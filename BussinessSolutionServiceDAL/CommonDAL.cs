using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MySql.Data.MySqlClient;


namespace BussinessSolutionServiceDAL
{
    public class CommonDAL
    {
        public static DataTable GetUnitOfMeasure(Database db)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FUOMID,FUOMCODE ");
            commandBulider.Append(" FROM BSM_UnitOfMeasureInfo ");
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }

        public static DataTable GetVendorInfo(Database db, string vendorName)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FSUPPLIERID,UPPER(FSUPPLIERNAME) AS FSUPPLIERNAME ");
            commandBulider.Append(" FROM BSM_SupplierInfo WHERE UPPER (FSUPPLIERNAME) LIKE '" + vendorName.ToUpper() + "%' ORDER BY FSUPPLIERNAME ASC ");
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }

        public static DataTable GetCompanyInfo(Database db)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FCOMPANYNAME,FADDRESS1,FADDRESS2,FSTATE,FPINCODE,FPHONE1,FPHONE2,FTINNUM ");
            commandBulider.Append(" FROM BSM_CompanyInfo  ");
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }
    }
}
