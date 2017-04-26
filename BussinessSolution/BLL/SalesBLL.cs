using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessSolution.BS_SalesService;

namespace BussinessSolution.BLL
{
    public class SalesBLL
    {
        public static NextInvoiceInfo GetNextInvoiceInfo()
        {

            SalesServiceClient service = new SalesServiceClient();
            return service.GetNextInvoiceInfo();
        }

        public static Int32 InsertOrUpdateSalesInfo(SalesInvoiceInfo salesInvoiceInfo)
        {
            SalesServiceClient service = new SalesServiceClient();
            return service.InsertOrUpdateSalesInfo(salesInvoiceInfo);
        }

        public static SalesInvoiceInfo[] GetSaleHoldList()
        {

            SalesServiceClient service = new SalesServiceClient();
            return service.GetSaleHoldList();
        }
    }
}
