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
    public class UserDAL
    {
        public static bool ValidateUserInfo(Database db, string userName, string password)
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.Append("SELECT FFIRSTNAME,FLASTNAME,FROLEID FROM BSM_UserInfo WHERE FUSERNAME = ?UserName AND FPASSWORD = ?Password");
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBuilder.ToString()))
            {
                db.AddInParameter(objCMD, "?UserName", DbType.String, userName);
                db.AddInParameter(objCMD, "?Password", DbType.String, password);
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
