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
    public class SalesDAL
    {
        public static bool InsertSalesHeaderInfo(Database db, DbTransaction transaction, Int64 salesID, Int64 invoiceNum, int createdDate, int createdTime, decimal totalAmount, decimal netAmount
            , decimal paidAmount,char isHold)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_SalesHeader(FSALESID,FINVOICENUM ,FCREATEDATE,FCREATEDTIME,FTOTALAMOUNT,FPAIDAMOUNT,FNETAMOUNT,FISHOLD) ");
            commandBulider.Append(" VALUES (" + salesID + "," + invoiceNum + "," + createdDate + "," + createdTime + "," + totalAmount + "," + paidAmount + "," + netAmount + ",'" + isHold + "') ");
           
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool UpdateSalesHeaderInfo(Database db, DbTransaction transaction, Int64 salesID, decimal totalAmount, decimal netAmount, decimal paidAmount, char isHold)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_SalesHeader SET FTOTALAMOUNT=" + totalAmount + ",FPAIDAMOUNT=" + paidAmount + ",FNETAMOUNT=" + netAmount+ ",FISHOLD='" + isHold + "'");
            commandBulider.Append(" WHERE FSALESID=" + salesID);
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static void GetNextInvoiceID(Database db, Int32 year,ref Int64 salesID)
        {
            try
            {
                StringBuilder commandBulider = new StringBuilder();
                commandBulider.Append(" SELECT MAX(FSALESID)+1 AS FNEXTSALESID ");
                commandBulider.Append(" FROM BSM_InvoiceMaster IM WHERE FDOCYEAR=@DOCYEAR");

                DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString());
                db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                dbCmd.CommandType = CommandType.Text;

                DataTable invoiceMaterTable = db.ExecuteDataSet(dbCmd).Tables[0];

                if (invoiceMaterTable.Rows.Count > 0)
                {
                    salesID=Convert.ToInt64(invoiceMaterTable.Rows[0]["FNEXTSALESID"].ToString());
                    string sqlUpdateCmd = "UPDATE BSM_InvoiceMaster SET FSALESID=@SALESID  WHERE FDOCYEAR=@DOCYEAR  ";
                    dbCmd = db.GetSqlStringCommand(sqlUpdateCmd);
                    db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                    db.AddInParameter(dbCmd, "@SALESID", DbType.Int64, salesID);
                   // db.AddInParameter(dbCmd, "@INVOICENUM", DbType.Int32, invoiceNum);
                    dbCmd.CommandType = CommandType.Text;
                    db.ExecuteNonQuery(dbCmd);
                }
                else
                {
                    string sqlUpdateCmd = "INSERT INTO BSM_InvoiceMaster (FINVOICENUM,FSALESID,FDOCYEAR) VALUES(@INVOICENUM,@SALESID,@DOCYEAR) ";
                    dbCmd = db.GetSqlStringCommand(sqlUpdateCmd);
                    db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                    db.AddInParameter(dbCmd, "@SALESID", DbType.Int64, 1);
                    db.AddInParameter(dbCmd, "@INVOICENUM", DbType.Int32, 0);
                    dbCmd.CommandType = CommandType.Text;
                    db.ExecuteNonQuery(dbCmd);
                   
                    salesID = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static void GetNextInvoiceNum(Database db, Int32 year, ref Int32 invoiceNum)
        {
            try
            {
                StringBuilder commandBulider = new StringBuilder();
                commandBulider.Append(" SELECT MAX(FINVOICENUM)+1 AS FNEXTINVOICENUM ");
                commandBulider.Append(" FROM BSM_InvoiceMaster IM WHERE FDOCYEAR=@DOCYEAR");

                DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString());
                db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                dbCmd.CommandType = CommandType.Text;

                DataTable invoiceMaterTable = db.ExecuteDataSet(dbCmd).Tables[0];

                if (invoiceMaterTable.Rows.Count > 0)
                {
                    invoiceNum = Convert.ToInt32(invoiceMaterTable.Rows[0]["FNEXTINVOICENUM"].ToString());
                   
                    string sqlUpdateCmd = "UPDATE BSM_InvoiceMaster SET FINVOICENUM=@INVOICENUM  WHERE FDOCYEAR=@DOCYEAR  ";
                    dbCmd = db.GetSqlStringCommand(sqlUpdateCmd);
                    db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                    db.AddInParameter(dbCmd, "@INVOICENUM", DbType.Int32, invoiceNum);
                    dbCmd.CommandType = CommandType.Text;
                    db.ExecuteNonQuery(dbCmd);
                }
                //else
                //{
                //    string sqlUpdateCmd = "INSERT INTO BSM_InvoiceMaster (FINVOICENUM,FSALESID,FDOCYEAR) VALUES(@INVOICENUM,@SALESID,@DOCYEAR) ";
                //    dbCmd = db.GetSqlStringCommand(sqlUpdateCmd);
                //    db.AddInParameter(dbCmd, "@DOCYEAR", DbType.Int32, year);
                //    db.AddInParameter(dbCmd, "@SALESID", DbType.Int64, 0);
                //    db.AddInParameter(dbCmd, "@INVOICENUM", DbType.Int32, 0);
                //    dbCmd.CommandType = CommandType.Text;
                //    db.ExecuteNonQuery(dbCmd);
                //    invoiceNum = 0;
                //    salesID = 0;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetNextSalesItemID(Database db, DbTransaction transaction, Int64 salesID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT IFNULL(MAX(FSALESITEMID),0)+1 AS FNEXTSALESITEMID ");
            commandBulider.Append(" FROM BSM_SalesItemInfo PR ");
            commandBulider.Append(" WHERE PR.FSALESID=" + salesID);

            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                int nextItemID = Convert.ToInt32(db.ExecuteScalar(objCMD, transaction));
                return nextItemID;
            }
        }
        
        public static bool DeleteSalesItemInfo(Database db, DbTransaction transaction, Int64 salesID)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" DELETE FROM bsm_salesiteminfo  WHERE FSALESID=" + salesID);
            using (DbCommand objCMD = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.ExecuteNonQuery(objCMD, transaction);
                return true;
            }
        }

        public static bool InsertSalesItemInfo(Database db, DbTransaction transaction, Int64 salesID,  int productID, decimal retailRate
                , decimal discountRate, decimal qty,string uom,decimal amount)
        {

            int nextItemID = GetNextSalesItemID(db, transaction, salesID);
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" INSERT INTO BSM_SalesItemInfo(FSALESITEMID ,FSALESID ,FPRODUCTID ,FRETAILRATE,FDISCOUNTRATE,FUOM,FQTY,FAMOUNT) ");
            commandBulider.Append(" VALUES (@SALESITEMID ,@SALESID ,@PRODUCTID ,@RETAILRATE,@DISCOUNTRATE,@UOM,@QTY,@AMOUNT) ");

            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.AddInParameter(dbCmd, "@SALESITEMID", DbType.Int32, nextItemID);
                db.AddInParameter(dbCmd, "@SALESID", DbType.Int64, salesID);
                db.AddInParameter(dbCmd, "@PRODUCTID", DbType.Int32, productID);
                db.AddInParameter(dbCmd, "@RETAILRATE", DbType.Decimal, retailRate);
                db.AddInParameter(dbCmd, "@DISCOUNTRATE", DbType.Decimal, discountRate);
                db.AddInParameter(dbCmd, "@UOM", DbType.String, uom);
                db.AddInParameter(dbCmd, "@QTY", DbType.Decimal, qty);
                db.AddInParameter(dbCmd, "@AMOUNT", DbType.Decimal, amount);

                db.ExecuteNonQuery(dbCmd, transaction);
                return true;
            }
        }

        public static bool ReduceProductStockInfo(Database db, DbTransaction transaction, int productID, decimal retailRate, decimal qty, decimal wholeSaleRate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" UPDATE BSM_PRODUCTSTOCKINFO SET FQTY=FQTY-@QTY ");
            commandBulider.Append(" WHERE FPRODUCTID=@PRODUCTID AND FRETAILRATE=@RETAILRATE AND FWHOLESALERATE=@WHOLESALERATE");

            using (DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString()))
            {
                db.AddInParameter(dbCmd, "@PRODUCTID", DbType.Int32, productID);
                db.AddInParameter(dbCmd, "@RETAILRATE", DbType.Decimal, retailRate);
                db.AddInParameter(dbCmd, "@WHOLESALERATE", DbType.Decimal, wholeSaleRate);
                db.AddInParameter(dbCmd, "@QTY", DbType.Decimal, qty);
                db.ExecuteNonQuery(dbCmd, transaction);
                return true;
            }
        }

        public static DataTable GetStockInfoForProduct(Database db,DbTransaction transaction,int productID,decimal retailRate)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT FRETAILRATE,FQTY, FWHOLESALERATE FROM BSM_PRODUCTSTOCKINFO ");
            commandBulider.Append(" WHERE FPRODUCTID=@PRODUCTID AND FRETAILRATE=@RETAILRATE AND FQTY>0 ");

            DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString());
            db.AddInParameter(dbCmd, "@PRODUCTID", DbType.Int32, productID);
            db.AddInParameter(dbCmd, "@RETAILRATE", DbType.Decimal, retailRate);

            DataTable stockTable = db.ExecuteDataSet(dbCmd, transaction).Tables[0];
            return stockTable;

        }

        public static DataTable GetInvoiceHoldList(Database db)
        {
            StringBuilder commandBulider = new StringBuilder();
            commandBulider.Append(" SELECT H.FSALESID,H.FINVOICENUM,H.FCREATEDATE,H.FCREATEDTIME,H.FTOTALAMOUNT,H.FNETAMOUNT,H.FPAIDAMOUNT ");
            commandBulider.Append(" ,I.FSALESITEMID,I.FPRODUCTID,I.FRETAILRATE,I.FDISCOUNTRATE,I.FUOM,I.FQTY,I.FAMOUNT,P.FPRODUCTNAME,S.FSUPPLIERNAME ");
            commandBulider.Append(" FROM BSM_SalesHeader H  ");
            commandBulider.Append(" INNER JOIN BSM_SalesItemInfo I ON H.FSALESID=I.FSALESID ");
            commandBulider.Append(" INNER JOIN BSM_ProductInfo P ON I.FPRODUCTID=P.FPRODUCTID ");
            commandBulider.Append(" INNER JOIN BSM_SupplierInfo S ON P.FVENDORID=S.FSUPPLIERID ");
            commandBulider.Append(" WHERE FISHOLD='Y' ORDER BY FSALESID ASC ");

            DbCommand dbCmd = db.GetSqlStringCommand(commandBulider.ToString());
            DataTable stockTable = db.ExecuteDataSet(dbCmd).Tables[0];
            return stockTable;

        }

        
    }
}
