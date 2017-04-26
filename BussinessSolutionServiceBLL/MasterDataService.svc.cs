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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MasterDataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MasterDataService.svc or MasterDataService.svc.cs at the Solution Explorer and start debugging.
    public class MasterDataService : IMasterDataService
    {
        #region SupplierInfo

        public List<SupplierInfo> GetSupplierInfo(PagerInfo pagerInfo)
        {
            try
            {
                //string connection_String = ConfigurationManager.ConnectionStrings["BSMConnectionString"].ConnectionString;
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable supplierTable = MasterDataDAL.GetSupplierInfo(db, pagerInfo.Filter);
                List<SupplierInfo> supplierList = new List<SupplierInfo>();
                foreach (DataRow supplierRow in supplierTable.Rows)
                {
                    SupplierInfo supplierInfo = new SupplierInfo();
                    supplierInfo.Address = supplierRow["FADDRESS1"].ToString();
                    supplierInfo.IsManufacture = supplierRow["FISMANUFACTURE"].ToString() == "Y" ? true : false;
                    supplierInfo.Pincode = supplierRow["FPINCODE"].ToString();
                    supplierInfo.State = supplierRow["FSTATE"].ToString();
                    supplierInfo.SupplierID = Convert.ToInt64(supplierRow["FSUPPLIERID"].ToString());
                    supplierInfo.SupplierName = supplierRow["FSUPPLIERNAME"].ToString();
                    supplierInfo.TIN = supplierRow["FTIN"].ToString();
                    supplierInfo.Phone = supplierRow["FPHONE1"].ToString();
                    supplierList.Add(supplierInfo);
                }
                return supplierList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool InsertOrUpdateSupplierInfo(SupplierInfo supplierInfo)
        {
            Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
            try
            {
                char isManufacture=supplierInfo.IsManufacture==true?'Y':'N';
                if (supplierInfo.SupplierID == 0)
                {
                    if (MasterDataDAL.CheckSuppierNameExist(db, supplierInfo.SupplierName))
                    {
                        throw new FaultException("Supllier Name Already Eixst");

                    }
                    else
                    {
                        MasterDataDAL.InsertSupplierInfo(db, supplierInfo.SupplierName, supplierInfo.Address, supplierInfo.State, supplierInfo.Phone
                            , supplierInfo.Pincode, supplierInfo.TIN, isManufacture);
                    }
                }
                else
                {
                    MasterDataDAL.UpdateSupplierInfo(db,supplierInfo.SupplierID, supplierInfo.SupplierName, supplierInfo.Address, supplierInfo.State, supplierInfo.Phone
                        , supplierInfo.Pincode, supplierInfo.TIN, isManufacture);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

        #region ProductInfo

        public List<ProductInfo> GetProductInfo(PagerInfo pagerInfo)
        {
            try
            {
                //string connection_String = ConfigurationManager.ConnectionStrings["BSMConnectionString"].ConnectionString;
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable productTable = MasterDataDAL.GetProductInfo(db, pagerInfo.Filter);
                List<ProductInfo> productList = new List<ProductInfo>();
                foreach (DataRow productRow in productTable.Rows)
                {
                    ProductInfo productInfo = new ProductInfo();
                    productInfo.DisplayProductName = productRow["FPRODUCTID"].ToString() + " - " + productRow["FPRODUCTNAME"].ToString() + " - " + productRow["FSUPPLIERNAME"].ToString();
                    productInfo.ProductCode = Convert.ToInt32(productRow["FPRODUCTID"].ToString());
                    productInfo.ProductDescription = productRow["FPRODUCTNAME"].ToString();
                    productInfo.IsTaxableItem = Convert.ToChar(productRow["FISTAXABLE"].ToString());
                    productInfo.IsDifferentRateInSize = Convert.ToChar( productRow["FISDIFF_RATEINSIZE"].ToString());
                   
                    productInfo.ProductCategoryInfo.CategoryID = Convert.ToInt32(productRow["FCATEGORYID"].ToString());
                    productInfo.ProductCategoryInfo.CategoryCode = productRow["FCATEGORYCODE"].ToString();
                    productInfo.ProductCategoryInfo.CategoryName = productRow["FCATEGORYNAME"].ToString();
                    productInfo.VendorInfo.SupplierID = Convert.ToInt32(productRow["FVENDORID"].ToString());
                    productInfo.VendorInfo.SupplierName = productRow["FSUPPLIERNAME"].ToString();

                    productList.Add(productInfo);
                   
                }
                return productList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool InsertOrUpdateProductInfo(ProductInfo productInfo)
        {
            Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
            try
            {
                if (productInfo.ProductCode == 0)
                {
                    if (MasterDataDAL.CheckProductNameExist(db, productInfo.ProductDescription))
                    {
                        throw new FaultException("Product Name Already Eixst");

                    }
                    else
                    {
                        MasterDataDAL.InsertProductInfo(db, productInfo.ProductDescription, productInfo.VendorInfo.SupplierID, productInfo.ProductCategoryInfo.CategoryID, 0
                            , productInfo.IsTaxableItem, productInfo.IsGiftItem, productInfo.IsDifferentRateInSize, productInfo.ProfitPrecentage);
                    }
                }
                else
                {
                    MasterDataDAL.UpdateProductInfo(db, productInfo.ProductCode, productInfo.ProductDescription, productInfo.VendorInfo.SupplierID
                        , productInfo.ProductCategoryInfo.CategoryID, 0, productInfo.IsTaxableItem, productInfo.IsGiftItem, productInfo.IsDifferentRateInSize, productInfo.ProfitPrecentage);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region CategoryInfo

        public List<CategoryInfo> GetCategoryInfo(PagerInfo pagerInfo)
        {
            try
            {
                //string connection_String = ConfigurationManager.ConnectionStrings["BSMConnectionString"].ConnectionString;
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable categoryTable = MasterDataDAL.GetCategoryInfo(db, pagerInfo.Filter);
                List<CategoryInfo> categoryList = new List<CategoryInfo>();
                foreach (DataRow categoryRow in categoryTable.Rows)
                {
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryID = Convert.ToInt32(categoryRow["FCATEGORYID"].ToString());
                    categoryInfo.CategoryCode = categoryRow["FCATEGORYCODE"].ToString();
                    categoryInfo.CategoryName = categoryRow["FCATEGORYNAME"].ToString();

                    categoryList.Add(categoryInfo);
                }
                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public List<CategoryInfo> GetGroupCategoryInfo(PagerInfo pagerInfo)
        {
            try
            {
                //string connection_String = ConfigurationManager.ConnectionStrings["BSMConnectionString"].ConnectionString;
                Database db = DatabaseFactory.CreateDatabase("BSMConnectionString");
                DataTable categoryTable = MasterDataDAL.GetGroupCategoryInfo(db, pagerInfo.Filter);
                List<CategoryInfo> categoryList = new List<CategoryInfo>();
                foreach (DataRow categoryRow in categoryTable.Rows)
                {
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryID = Convert.ToInt32(categoryRow["FCATEGORYID"].ToString());
                    //categoryInfo.CategoryCode = categoryRow["FCATEGORYCODE"].ToString();
                    categoryInfo.CategoryName = categoryRow["FCATEGORYNAME"].ToString();

                    categoryList.Add(categoryInfo);
                }
                return categoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

    }
}
