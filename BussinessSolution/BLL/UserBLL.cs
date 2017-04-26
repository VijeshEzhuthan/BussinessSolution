using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
//using BussinessSolutionDAL;
using BussinessSolution.BS_UserService;

namespace BussinessSolution.BLL
{
    public class UserBLL
    {
        public static bool ValidatedUserLogin(string userName, string password)
        {
            BS_UserService.UserServiceClient service=new BS_UserService.UserServiceClient();
            return service.ValidatedUserLogin(userName, password);

        }
    }
}
