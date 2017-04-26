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
    public class MasterDataDAL
    {
        #region SupplierInfo
        public static bool InsertSupplierInfo(Database db, string supplierName,string address, string state,string phone,string pincode,string tin,char isManufacture)
        {
            Int64 supplierID = GetNextSupplierID(db);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_SupplierInfo(FSUPPLIERID,FSUPPLIERNAME,FADDRESS1,FPINCODE,FSTATE,FPHONE1,FTIN,FISMANUFACTURE ) ");
            commandBulider.Append(" VALUES (" + supplierID + ",'" + supplierName.ToUpper() + "','" + address + "','" + pincode + "','" + state + "','" + phone + "','" + tin + "','" + isManufacture + "') ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD);
                return true;
            }
        }

        public static bool UpdateSupplierInfo(Database db, Int64 supplierID, string supplierName, string address, string state, string phone, string pincode, string tin, char isManufacture)
        {
           
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_SupplierInfo SET FSUPPLIERNAME='" + supplierName.ToUpper() + "',FADDRESS1='" + address + "'");
            commandBulider.Append(" ,FPINCODE='" + pincode + "',FSTATE='" + state + "',FPHONE1='" + phone + "',FTIN='" + tin + "',FISMANUFACTURE='" + isManufacture + "'");
            commandBulider.Append(" WHERE FSUPPLIERID=" + supplierID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD);
                return true;
            }
        }

        public static Int64 GetNextSupplierID(Database db)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT IFNULL(MAX(FSUPPLIERID),0)+1 AS FNEXTSUPPLIERID ");
            commandBulider.Append(" FROM BSM_SupplierInfo ");
            
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                Int64 nextItemID = Convert.ToInt64(db.ExecuteScalar(objCMD));
                return nextItemID;
            }
        }

        public static DataTable GetSupplierInfo(Database db,string filter)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FSUPPLIERID,FSUPPLIERNAME,FADDRESS1,FPINCODE,FSTATE,FPHONE1,FTIN,FISMANUFACTURE ");
            commandBulider.Append(" FROM BSM_SupplierInfo ");
            if (filter != null)
            {
                commandBulider.Append(" WHERE FSUPPLIERNAME LIKE '%" + filter.ToUpper() + "%'");
            }
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                return supplierTable;
            }
        }

        public static bool CheckSuppierNameExist(Database db,string supplierName)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FSUPPLIERID ");
            commandBulider.Append(" FROM BSM_SupplierInfo ");
            commandBulider.Append(" WHERE FSUPPLIERNAME='" + supplierName.ToUpper() + "'");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                if (supplierTable.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool DeleteSuppierInfo(Database db, int supplierID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" DELETE FROM BSM_SupplierInfo WHERE FSUPPLIERID=" + supplierID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD);
               
            }
            return true;
        }

        #endregion

        #region ProductInfo

        public static bool InsertProductInfo(Database db, string productName,Int64 manufactureID,int category,decimal startingStock
            ,char isTaxable,char isGiftItem,char isDifferentRateInSize,decimal profitPrecentage)
        {
            Int64 productID = GetNextProductID(db);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_ProductInfo(FPRODUCTID,FPRODUCTNAME,FCATEGORYID,FVENDORID,FISTAXABLE,FSTARINGSTOCK,FISGIFTITEM,FISDIFF_RATEINSIZE,FPROFITPRECETANGE) ");
            commandBulider.Append(" VALUES (" + productID + ",'" + productName.ToUpper() + "'," + manufactureID + "," + category + ",'" + isTaxable + "'," + startingStock  );
            commandBulider.Append(",'" + isGiftItem + "','" + isDifferentRateInSize + "'," + profitPrecentage + ")");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD);
                return true;
            }
        }

        public static bool UpdateProductInfo(Database db, int productID, string productName, Int64 manufactureID, int category, decimal startingStock
            , char isTaxable, char isGiftItem, char isDifferentRateInSize, decimal profitPrecentage)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_ProductInfo SET FPRODUCTNAME='" + productName.ToUpper() + "',FCATEGORYID=" + category);
            commandBulider.Append(" ,FVENDORID=" + manufactureID + ",FISTAXABLE='" + isTaxable + "',FSTARINGSTOCK=" + startingStock + ",FISGIFTITEM='" + isGiftItem + "'");
            commandBulider.Append(" ,FISDIFF_RATEINSIZE='" + isDifferentRateInSize + "',FPROFITPRECETANGE=" + profitPrecentage + " WHERE FPRODUCTID=" + productID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD);
                return true;
            }
        }

        public static Int64 GetNextProductID(Database db)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT IFNULL(MAX(FPRODUCTID),0)+1 AS FPRODUCTID");
            commandBulider.Append(" FROM BSM_ProductInfo ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                Int64 nextItemID = Convert.ToInt64(db.ExecuteScalar(objCMD));
                return nextItemID;
            }
        }

        public static DataTable GetProductInfo(Database db, string filter)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT PR.FPRODUCTID,PR.FPRODUCTNAME,CR.FCATEGORYID,PR.FVENDORID,PR.FISGIFTITEM,FISDIFF_RATEINSIZE,FISTAXABLE");
            commandBulider.Append(" ,CR.FCATEGORYNAME, CR.FCATEGORYCODE,VI.FSUPPLIERNAME ");
            commandBulider.Append(" FROM BSM_ProductInfo PR ");
            commandBulider.Append(" INNER JOIN BSM_GroupCategory GR ON PR.FGROUPCATEGORYID=GR.FGROUPCATEGORYID ");
            commandBulider.Append(" INNER JOIN BSM_CategoryInfo CR ON GR.FCATEGORYID=CR.FCATEGORYID ");
            commandBulider.Append(" INNER JOIN BSM_SupplierInfo VI ON PR.FVENDORID=VI.FSUPPLIERID ");
            if (filter != null)
            {
                commandBulider.Append(" WHERE FPRODUCTNAME LIKE '%" + filter.ToUpper() + "%'");
            }
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                return supplierTable;
            }
        }

        public static bool CheckProductNameExist(Database db, string productName)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FPRODUCTID ");
            commandBulider.Append(" FROM BSM_ProductInfo ");
            commandBulider.Append(" WHERE FPRODUCTNAME='" + productName.ToUpper() + "'");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                if (supplierTable.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }


        #endregion

        
        #region CategoryInfo

        public static DataTable GetCategoryInfo(Database db, string filter)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FCATEGORYID,	FCATEGORYNAME,FCATEGORYCODE ");
            commandBulider.Append(" FROM bsm_categoryinfo ");
            if (filter != null)
            {
                commandBulider.Append(" WHERE FCATEGORYNAME LIKE '%" + filter.ToUpper() + "%' OR FCATEGORYCODE LIKE '%" + filter.ToUpper() + "%'");
            }
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                return supplierTable;
            }
        }

        public static DataTable GetGroupCategoryInfo(Database db, string filter)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FGROUPCATEGORYID AS FCATEGORYID,FGROUPCATEGORYNAME	AS FCATEGORYNAME ");
            commandBulider.Append(" FROM BSM_GroupCategory ");
            if (filter != null)
            {
                commandBulider.Append(" WHERE FGROUPCATEGORYNAME LIKE '%" + filter.ToUpper() + "%'");
            }
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable supplierTable = db.ExecuteDataSet(objCMD).Tables[0];
                return supplierTable;
            }
        }

        #endregion

    }
}
