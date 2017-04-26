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
    public class PurchaseDAL
    {
        public static DataTable GetProductInfoByNameOrCode(Database db, string description, int productcode)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT DISTINCT PR.FPRODUCTID,PR.FCATEGORYID, PR.FPRODUCTNAME, CR.FCATEGORYNAME, CR.FCATEGORYCODE,PR.FSIZE ");
            commandBulider.Append(" ,VI.FVENDORNAME,PS.FRETAILRATE,PR.FVENDORID ");
            commandBulider.Append(" FROM BSM_ProductInfo PR ");
            commandBulider.Append(" INNER JOIN BSM_CategoryInfo CR ON PR.FCATEGORYID=CR.FCATEGORYID ");
            commandBulider.Append(" INNER JOIN BSM_VenderInfo VI ON PR.FVENDORID=VI.FVENDORID ");
            commandBulider.Append(" LEFT OUTER JOIN BSM_ProductStockInfo PS ON PS.FPRODUCTID=PR.FPRODUCTID ");
            
            commandBulider.Append(" WHERE (PR.FPRODUCTNAME LIKE '" + description + "%' OR PR.FPRODUCTID=" + productcode +")");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }

        public static int GetPurchaseID(Database db, DbTransaction transaction)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT SEQUENCE_PURCHASE_ID.NEXT_VAL FROM DUAL ");
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                string purchaseID = db.ExecuteScalar(dbCmd, transaction).ToString();
                return Convert.ToInt32(purchaseID);
            }
        }

        public static Int64 InsertPurchaseHeaderInfo(Database db, DbTransaction transaction, int vendorID, string invoicenum, int invoicedate, int createDate, decimal totalamount)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_PurchaseHeader(FVENDEORID,FINVOICENUM,FINVOICEDATE,FCREATEDATE,FINVOICEAMOUNT) ");
            commandBulider.Append(" VALUES (" + vendorID + ",'" + invoicenum + "'," + invoicedate + "," + createDate + "," + totalamount + "); ");
            commandBulider.Append(" SELECT @@IDENTITY as Identity ");
            Int64 purchaseID = 0;
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(dbCmd, transaction).Tables[0];
                 purchaseID= Convert.ToInt64(dt.Rows[0]["Identity"].ToString());
              
            }
            return purchaseID;
        }

        public static int GetNextPurchaseItemID(Database db, DbTransaction transaction, Int64 purchaseID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT MAX(NVL(FPURCHASEITEMID,0))+1 AS FNEXTPURCHASEITEMID ");
            commandBulider.Append(" FROM BSM_PurchaseItemInfo PR ");
            commandBulider.Append(" WHERE (PR.FPURCHASEID=" + purchaseID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                int nextItemID = Convert.ToInt32(db.ExecuteScalar(objCMD, transaction));
                return nextItemID;
            }
        }
        
        public static bool InsertPurchaseItemInfo(Database db, DbTransaction transaction,Int64 purchaseID, int productID, decimal unitPrice, string unit,decimal qty)
        {

            int nextItemID = GetNextPurchaseItemID(db, transaction, purchaseID);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_PurchaseItemInfo(FPURCHASEITEMID,FPURCHASEID,FITEMID,FUNITPRICE,FUOM,FQTY) ");
            commandBulider.Append(" VALUES (" + nextItemID + "," + purchaseID + ",'" + productID + "'," + unitPrice + "," + unit + "," + qty + ") ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool UpdatePurchaseItemInfo(Database db, DbTransaction transaction,int puchaseItemID, int purchaseID, int productID, decimal unitPrice, string unit, decimal qty)
        {

            int nextItemID = GetNextPurchaseItemID(db, transaction, purchaseID);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_PurchaseItemInfo SET FUNITPRICE=" + unitPrice + ",FUOM=" + unit + ",FQTY=" + qty);
            commandBulider.Append(" WHERE FPURCHASEID=" + purchaseID + " AND FPURCHASEITEMID= " + puchaseItemID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool UpdatePurchaseItemInfo(Database db, DbTransaction transaction, int vendorID, string invoicenum, int invoicedate, decimal totalamount)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_PurchaseHeader SET FPURCHASEID,FVENDEORID,FINVOICENUM,FINVOICEDATE,FCREATEDATE,FINVOICEAMOUNT) ");
            commandBulider.Append(" VALUES (SEQUENCE_PURCHASE_ID.NEXT_VAL," + vendorID + ",'" + invoicenum + "'," + invoicedate + "," + invoicedate + "," + totalamount + ") ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }
    }
}
