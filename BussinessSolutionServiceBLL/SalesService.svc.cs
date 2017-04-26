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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SalesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SalesService.svc or SalesService.svc.cs at the Solution Explorer and start debugging.
    public class SalesService : ISalesService
    {
        public NextInvoiceInfo GetNextInvoiceInfo()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DateTime currentDate = DateTime.Now;
                Int64 nextSalesID = 0;
              
                SalesDAL.GetNextInvoiceID(db, currentDate.Year, ref nextSalesID);
                NextInvoiceInfo nextInvoiceInfo = new NextInvoiceInfo();
                //nextInvoiceInfo.InvoiceNum = invoiceNum;
                nextInvoiceInfo.SalesID = nextSalesID;
                return nextInvoiceInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Int32 InsertOrUpdateSalesInfo(SalesInvoiceInfo salesInvoiceInfo)
        {
            Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
            DbTransaction transaction;
            using (MySqlConnection connection = (MySqlConnection)db.CreateConnection())
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    DateTime datetime = DateTime.Now;
                    Int32 nextInvoiceNum = 0;
                    DateTime currentDate = DateTime.Now;
                    char isHold = salesInvoiceInfo.IsHold == true ? 'Y' : 'N';
                    if (salesInvoiceInfo.InvoiceNum == 0)
                    {
                        SalesDAL.GetNextInvoiceNum(db, currentDate.Year, ref nextInvoiceNum);
                        SalesDAL.InsertSalesHeaderInfo(db, transaction, salesInvoiceInfo.SalesID, nextInvoiceNum
                                                , Convert.ToInt32(datetime.ToString("yyyyMMdd")), Convert.ToInt32(datetime.ToString("HHmmss"))
                                                , salesInvoiceInfo.TotalAmount, salesInvoiceInfo.NetAmount, salesInvoiceInfo.PaidAmount, isHold);
                    }
                    else
                    {
                        nextInvoiceNum = salesInvoiceInfo.InvoiceNum;
                        SalesDAL.UpdateSalesHeaderInfo(db, transaction, salesInvoiceInfo.SalesID, salesInvoiceInfo.TotalAmount, salesInvoiceInfo.NetAmount, salesInvoiceInfo.PaidAmount, isHold);
                        SalesDAL.DeleteSalesItemInfo(db, transaction, salesInvoiceInfo.SalesID);
                    }

                    foreach(SalesItemInfo itemInfo in salesInvoiceInfo.SalesItemList)
                    {
                        SalesDAL.InsertSalesItemInfo(db, transaction, salesInvoiceInfo.SalesID, itemInfo.ProductID, itemInfo.RetailRate
                                                        , itemInfo.DiscountRate, itemInfo.Qty, itemInfo.Unit,itemInfo.Amount);

                        DataTable stockTable = SalesDAL.GetStockInfoForProduct(db,transaction, itemInfo.ProductID,itemInfo.RetailRate);
                        foreach (DataRow stockRow in stockTable.Rows)
                        {
                            decimal stockQty = Convert.ToDecimal(stockRow["FQTY"].ToString());
                            decimal wholeSalRate = Convert.ToDecimal(stockRow["FWHOLESALERATE"].ToString());

                            if (stockQty >= itemInfo.Qty)
                            {
                                SalesDAL.ReduceProductStockInfo(db, transaction, itemInfo.ProductID, itemInfo.RetailRate, itemInfo.Qty, wholeSalRate);
                                break;
                            }
                            else
                            {
                                SalesDAL.ReduceProductStockInfo(db, transaction, itemInfo.ProductID, itemInfo.RetailRate, stockQty, wholeSalRate);
                                itemInfo.Qty = itemInfo.Qty - stockQty;
                            }
                        }
                    }
                    transaction.Commit();
                    return nextInvoiceNum;
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

        public List<SalesInvoiceInfo> GetSaleHoldList()
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable holdInvoiceTable = SalesDAL.GetInvoiceHoldList(db);
                List<SalesInvoiceInfo> holdList = new List<SalesInvoiceInfo>();
                if (holdInvoiceTable.Rows.Count > 0)
                {
                    int prevSalesID = 0;
                    int currentSalesID = 0;
                    int itemCount = 0;
                    SalesInvoiceInfo salesInvoiceInfo =  new SalesInvoiceInfo();
                    foreach(DataRow itemRow in holdInvoiceTable.Rows)
                    {
                        currentSalesID = Convert.ToInt32(itemRow["FSALESID"].ToString());
                        itemCount++;
                        SalesItemInfo salesItem = new SalesItemInfo();
                        salesItem.Amount = Convert.ToDecimal(itemRow["FAMOUNT"].ToString());
                        salesItem.DiscountRate = Convert.ToDecimal(itemRow["FDISCOUNTRATE"].ToString());
                        salesItem.ProductID = Convert.ToInt32(itemRow["FPRODUCTID"].ToString());
                        salesItem.Qty = Convert.ToDecimal(itemRow["FQTY"].ToString());
                        salesItem.RetailRate = Convert.ToDecimal(itemRow["FRETAILRATE"].ToString());
                        salesItem.Unit = itemRow["FUOM"].ToString();
                        salesItem.VendorName = itemRow["FSUPPLIERNAME"].ToString();
                        salesItem.ProductName = itemRow["FPRODUCTNAME"].ToString();
                        

                        if (prevSalesID != 0 && prevSalesID == currentSalesID)
                        {
                            salesInvoiceInfo.SalesItemList.Add(salesItem);
                        }
                        else
                        {
                            if (prevSalesID != 0)
                            {
                                salesInvoiceInfo.ItemCount = itemCount;
                                itemCount = 0;
                                holdList.Add(salesInvoiceInfo);
                            }

                            salesInvoiceInfo = new SalesInvoiceInfo();
                            salesInvoiceInfo.SalesID = currentSalesID;
                            salesInvoiceInfo.InvoiceNum = Convert.ToInt32(itemRow["FINVOICENUM"].ToString());
                            salesInvoiceInfo.NetAmount = Convert.ToDecimal(itemRow["FNETAMOUNT"].ToString());
                            salesInvoiceInfo.PaidAmount = Convert.ToDecimal(itemRow["FPAIDAMOUNT"].ToString()); ;
                            salesInvoiceInfo.TotalAmount = Convert.ToDecimal(itemRow["FTOTALAMOUNT"].ToString());
                            salesInvoiceInfo.SalesItemList.Add(salesItem);

                            
                        }

                        prevSalesID = currentSalesID;
                    }

                    if (prevSalesID != 0)
                    {
                        salesInvoiceInfo.ItemCount = itemCount;
                        holdList.Add(salesInvoiceInfo);
                    }
                }

                return holdList;
            }
            catch(Exception ex)
            {
                throw new FaultException(ex.Message.ToString());
            }
        }
    }
}
