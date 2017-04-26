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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PurchaseService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PurchaseService.svc or PurchaseService.svc.cs at the Solution Explorer and start debugging.
    public class PurchaseService : IPurchaseService
    {
        public List<StockInfo> GetProductInfoByNameOrCode(string description, int productcode)
        {
            try
            {
                //string connection_String = ConfigurationManager.ConnectionStrings["BSMConnectionString"].ConnectionString;
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable productTable = PurchaseDAL.GetProductInfoByNameOrCode(db, description, productcode);
                List<StockInfo> productList = new List<StockInfo>();
                foreach (DataRow productRow in productTable.Rows)
                {
                    StockInfo prodcutInfo = new StockInfo();
                    prodcutInfo.DisplayProductName = productRow["FPRODUCTID"].ToString() + " - " + productRow["FPRODUCTNAME"].ToString() + " - " + productRow["FSUPPLIERNAME"].ToString();
                    prodcutInfo.ProductCode = Convert.ToInt32(productRow["FPRODUCTID"].ToString());
                    prodcutInfo.ProductDescription = productRow["FPRODUCTNAME"].ToString();
                    SupplierInfo supplierInfo = new SupplierInfo();
                    
                    prodcutInfo.VendorInfo.SupplierName = productRow["FSUPPLIERNAME"].ToString();
                    DataTable priceInfoTable = PurchaseDAL.GetProductRateInfo(db, prodcutInfo.ProductCode);
                    foreach (DataRow priceRow in priceInfoTable.Rows)
                    {
                        StockPriceInfo stockPriceInfo = new StockPriceInfo();
                        stockPriceInfo.RetailRate = Convert.ToDecimal(priceRow["FRETAILRATE"].ToString());
                        stockPriceInfo.WholeSaleRate = Convert.ToDecimal(priceRow["FWHOLESALERATE"].ToString());
                        stockPriceInfo.Qty = Convert.ToDecimal(priceRow["FQTY"].ToString());
                        stockPriceInfo.UoM =priceRow["FUOM"].ToString();
                        if (priceRow["FSIZE"].ToString().Trim().Length > 0)
                        {
                            stockPriceInfo.Size = Convert.ToDecimal(priceRow["FSIZE"].ToString());
                        }
                        prodcutInfo.QtyPriceInfo.Add(stockPriceInfo);
                    }
                                        
                    productList.Add(prodcutInfo);
                }
                return productList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool InsertPurchaseInfo(PurchaseDetaiInfo purhcaseDetailInfo)
        {
            Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
            DbTransaction transaction;
            using (MySqlConnection connection = (MySqlConnection)db.CreateConnection())
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    string datetime = DateTime.Now.ToString("yyyyMMdd");

                    Int64 purchaseID = PurchaseDAL.InsertPurchaseHeaderInfo(db, transaction, purhcaseDetailInfo.VendorID, purhcaseDetailInfo.InvoiceNum
                                                           , purhcaseDetailInfo.InvoiceDate, Convert.ToInt32(datetime), purhcaseDetailInfo.TotalAmount);
                    foreach (PurchaseInfo purchaseItemInfo in purhcaseDetailInfo.PurchaseitemList)
                    {
                        PurchaseDAL.InsertPurchaseItemInfo(db, transaction, purchaseID, purchaseItemInfo.ProductCode, purchaseItemInfo.WholeSaleRate, purchaseItemInfo.UoM, purchaseItemInfo.Qty);

                        if (PurchaseDAL.CheckProductStockExist(db, transaction, purchaseItemInfo.ProductCode, purchaseItemInfo.RetailRate, purchaseItemInfo.WholeSaleRate))
                        {
                            PurchaseDAL.UpdateProductStockInfo(db, transaction, purchaseItemInfo.ProductCode, purchaseItemInfo.RetailRate, purchaseItemInfo.Qty, purchaseItemInfo.WholeSaleRate);
                        }
                        else
                        {
                            string labelNumber=PurchaseDAL.GetNextLabelNumForCategory(db,transaction,purchaseItemInfo.ProductCategoryInfo .CategoryID);
                            PurchaseDAL.InsertProductStockInfo(db, transaction, purchaseItemInfo.ProductCode, purchaseItemInfo.RetailRate, labelNumber, purchaseItemInfo.UoM, purchaseItemInfo.Qty, purchaseItemInfo.WholeSaleRate);
                        }
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
