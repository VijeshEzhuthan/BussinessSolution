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
    public class PurchaseDAL
    {
        public static DataTable GetProductInfoByNameOrCode(Database db, string description, int productcode)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT DISTINCT PR.FPRODUCTID, PR.FPRODUCTNAME, VI.FSUPPLIERNAME,PR.FVENDORID ,SI.FSIZE ");
            commandBulider.Append(" FROM BSM_ProductInfo PR ");
            //commandBulider.Append(" INNER JOIN BSM_CategoryInfo CR ON PR.FCATEGORYID=CR.FCATEGORYID ");
            commandBulider.Append(" INNER JOIN BSM_SupplierInfo VI ON PR.FVENDORID=VI.FSUPPLIERID ");
            commandBulider.Append(" LEFT OUTER JOIN BSM_ProductStockInfo  SI ON PR.FPRODUCTID=SI.FPRODUCTID AND SI.FQTY>0 ");

            commandBulider.Append(" WHERE (PR.FPRODUCTNAME LIKE '" + description + "%' OR PR.FPRODUCTID=" + productcode + ")");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }

        public static DataTable GetProductRateInfo(Database db, int productcode)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FQTY,IFNULL(FWHOLESALERATE,0) AS FWHOLESALERATE,FSIZE,FRETAILRATE,FUOM ");
            commandBulider.Append(" FROM BSM_ProductStockInfo PR ");
            commandBulider.Append(" WHERE  PR.FPRODUCTID=" + productcode );

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable dt = db.ExecuteDataSet(objCMD).Tables[0];
                return dt;
            }
        }

        public static int GetPurchaseID(Database db, DbTransaction transaction)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT SEQUENCE_PURCHASE_ID.NEXT_VAL AS FNEXTPURCHASEID FROM DUAL ");
            //int purchaseID=0;
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable purchaseIDTable= db.ExecuteDataSet(dbCmd, transaction).Tables[0];
                if(purchaseIDTable.Rows.Count>0)
                    return Convert.ToInt32(purchaseIDTable.Rows[0]["FNEXTPURCHASEID"].ToString());
                else 
                    return 1;
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
                purchaseID = Convert.ToInt64(dt.Rows[0]["Identity"].ToString());

            }
            return purchaseID;
        }

        public static int GetNextPurchaseItemID(Database db, DbTransaction transaction, Int64 purchaseID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT IFNULL(MAX(FPURCHASEITEMID),0)+1 AS FNEXTPURCHASEITEMID ");
            commandBulider.Append(" FROM BSM_PurchaseItemInfo PR ");
            commandBulider.Append(" WHERE PR.FPURCHASEID=" + purchaseID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                int nextItemID = Convert.ToInt32(db.ExecuteScalar(objCMD, transaction));
                return nextItemID;
            }
        }

        public static bool InsertPurchaseItemInfo(Database db, DbTransaction transaction, Int64 purchaseID, int productID, decimal unitPrice, string unit, decimal qty)
        {

            int nextItemID = GetNextPurchaseItemID(db, transaction, purchaseID);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_PurchaseItemInfo(FPURCHASEITEMID,FPURCHASEID,FITEMID,FUNITPRICE,FUOM,FQTY) ");
            commandBulider.Append(" VALUES (" + nextItemID + "," + purchaseID + ",'" + productID + "'," + unitPrice + ",'" + unit + "'," + qty + ") ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool UpdatePurchaseItemInfo(Database db, DbTransaction transaction, int puchaseItemID, int purchaseID, int productID, decimal unitPrice, string unit, decimal qty)
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

        public static bool UpdatePurchaseHeadernfo(Database db, DbTransaction transaction, int purchaseID, int vendorID, string invoicenum, int invoicedate, decimal totalamount, int createDate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_PurchaseHeader SET FINVOICENUM='" + invoicenum + "',FINVOICEDATE=" + invoicedate + ",FCREATEDATE=" + createDate + ",FINVOICEAMOUNT=" + totalamount );
            commandBulider.Append(" WHERE  FPURCHASEID="+ purchaseID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool CheckProductStockExist(Database db, DbTransaction transaction, int productID,decimal retailRate,decimal wholeSaleRate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FPRODUCTID FROM BSM_PRODUCTSTOCKINFO  ");
            commandBulider.Append(" WHERE FPRODUCTID=" + productID + " AND FRETAILRATE=" + retailRate + " AND FWHOLESALERATE=" + wholeSaleRate);
            //int purchaseID=0;
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                DataTable productTable = db.ExecuteDataSet(dbCmd, transaction).Tables[0];
                if (productTable.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public static bool InsertProductStockInfo(Database db,DbTransaction transaction,int productID,decimal retailRate,string labelNumber
                        , string uom, decimal qty, decimal wholeSaleRate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_PRODUCTSTOCKINFO (FLABELNUM,FPRODUCTID,FRETAILRATE,FUOM,FQTY,FWHOLESALERATE) ");
            commandBulider.Append(" VALUES ('" + labelNumber + "'," + productID + "," + retailRate + ",'" + uom + "'," + qty + "," + wholeSaleRate + ") ");

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool UpdateProductStockInfo(Database db, DbTransaction transaction, int productID, decimal retailRate, decimal qty, decimal wholeSaleRate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_PRODUCTSTOCKINFO SET FQTY=FQTY+ " + qty);
            commandBulider.Append(" WHERE FPRODUCTID=" + productID + " AND FRETAILRATE=" + retailRate + " AND FWHOLESALERATE=" + wholeSaleRate);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static string GetNextLabelNumForCategory(Database db, DbTransaction transaction, int categoryID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT CONCAT(RPAD(FCATEGORYCODE,4,'0'),LPAD(FLASTLABELNUM+1,10,'0')) FROM BSM_CATEGORYINFO  WHERE FCATEGORYID=" + categoryID);
            DataTable productTable;
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                productTable = db.ExecuteDataSet(dbCmd, transaction).Tables[0];
                
            }

            commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_CATEGORYINFO SET FLASTLABELNUM=FLASTLABELNUM+1 WHERE FCATEGORYID=" + categoryID);
            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(dbCmd, transaction);
              
            }
            return productTable.Rows[0][0].ToString();
        }
    }
}
