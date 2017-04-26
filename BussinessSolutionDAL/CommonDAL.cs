using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace BussinessSolutionDAL
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

        public static DataTable GetVendorInfo(Database db,string vendorName)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FVENDORID,UPPER(FVENDORNAME) AS FVENDORNAME ");
            commandBulider.Append(" FROM BSM_VenderInfo WHERE UPPER (FVENDORNAME) LIKE '" + vendorName.ToUpper() + "%' ORDER BY FVENDORNAME ASC ");
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }
    }
}
