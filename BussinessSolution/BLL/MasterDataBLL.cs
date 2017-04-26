using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using BussinessSolution.BS_MasterDataService;

namespace BussinessSolution.BLL
{
    public class MasterDataBLL
    {
        #region SupplierInfo
        public static List<SupplierInfo> GetSupplierInfo(PagerInfo pagerInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.GetSupplierInfo(pagerInfo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static  bool InsertOrUpdateSupplierInfo(SupplierInfo supplierInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.InsertOrUpdateSupplierInfo(supplierInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ProductInfo
        public static List<ProductInfo> GetProductInfo(PagerInfo pagerInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.GetProductInfo(pagerInfo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertOrUpdateProductInfo(ProductInfo productInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.InsertOrUpdateProductInfo(productInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region CategoryInfo

        public static List<CategoryInfo> GetCategoryInfo(PagerInfo pagerInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.GetCategoryInfo(pagerInfo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CategoryInfo> GetGroupCategoryInfo(PagerInfo pagerInfo)
        {
            try
            {

                MasterDataServiceClient service = new MasterDataServiceClient();
                return service.GetGroupCategoryInfo(pagerInfo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
