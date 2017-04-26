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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public bool ValidatedUserLogin(string userName, string password)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                return UserDAL.ValidateUserInfo(db, userName, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
