using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSolution.BS_PurchaseService;

namespace BussinessSolution.BLL
{
    public class PurchaseBLL
    {
        public static List<StockInfo> GetProductInfoByNameOrCode(string description, int productcode)
        {
            PurchaseServiceClient service = new PurchaseServiceClient();
            return service.GetProductInfoByNameOrCode(description, productcode).ToList();
        }

        public static bool InsertPurchaseInfo(PurchaseDetaiInfo purhcaseDetailInfo)
        {
            PurchaseServiceClient service = new PurchaseServiceClient();
            return service.InsertPurchaseInfo(purhcaseDetailInfo);
        }
    }

 
}
