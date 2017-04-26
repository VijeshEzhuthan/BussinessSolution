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
    public class UserDAL
    {
        public static bool ValidateUserInfo(Database db,string userName,string password)
        {
            using (DbCommand objCMD = db.GetStoredProcCommand("ValidateUserInfo"))
            {
                db.AddInParameter(objCMD, "@UserName", DbType.String, userName);
                db.AddInParameter(objCMD, "@Password", DbType.String, password);
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

       
    }
}
