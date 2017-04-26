using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPageTransitions;
using System.Data;
using BussinessSolution.BS_SalesService;


namespace BussinessSolution.Sales
{
    /// <summary>
    /// Interaction logic for SalesIndex.xaml
    /// </summary>
    public partial class SalesIndex : UserControl, ITabbedMDI
    {
        private Window _parentWindow;
        delegate void OpenInvoiceOnHoldList(SalesInvoiceInfo invoiceInfo);
        #region ITabbedMDI Members

        /// <summary>
        /// This event will be fired when user will click close button
        /// </summary>
        public event delClosed CloseInitiated;

        /// <summary>
        /// This is unique name of the tab
        /// </summary>
        public string UniqueTabName
        {
            get
            {
                return "SalesIndex";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Sales"; }
        }
        #endregion

        public SalesIndex()
        {
            InitializeComponent();
        }

        private void saleInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SalesInvoice salesInvoice = new SalesInvoice(_parentWindow,null);

                pageTransitionControl.TransitionType = PageTransitionType.Slide;
                pageTransitionControl.ShowPage(salesInvoice);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void invoiceList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void salesreturn_Click(object sender, RoutedEventArgs e)
        {
            //LabelFormats.InvoiceDataSet.InvoiceItemDataTable dt1 = new LabelFormats.InvoiceDataSet.InvoiceItemDataTable();
            //for (int i = 0; i < blankLabelCount; i++)
            //{
            //    DataRow dr = dt1.NewRow();
            //    dt1.Rows.Add(dr);
            //}

            ////if (numOfBlankLabelTextbox.Text.Trim().Length > 0)
            ////{
            ////    int blankLabelCount = 0;
            ////    int.TryParse(numOfBlankLabelTextbox.Text.Trim(), out blankLabelCount);
            ////    for (int i = 0; i < blankLabelCount; i++)
            ////    {
            ////        DataRow dr = dt1.NewRow();
            ////        dt1.Rows.Add(dr);
            ////    }

            ////}

            //if (numOfCopyTextbox.Text.Trim().Length > 0)
            //{
            //    int copyCount = 0;
            //    int.TryParse(numOfCopyTextbox.Text.Trim(), out copyCount);
            //    for (int i = 0; i < copyCount; i++)
            //    {
            //        DataRow dr = dt1.NewRow();
            //        dr["FPRODUCTCODE"] = "*" + _productInfo.CategoryCode.PadRight(4, '0') + _productInfo.ProductCode.ToString().PadLeft(10, '0') + "*";
            //        dr["FRETAILRATE"] = _productInfo.RetailRate;
            //        dr["FMRP"] = "MRP:";
            //        dt1.Rows.Add(dr);
            //    }

            //}

            //LabelFormats.LabelDataSet ds = new LabelFormats.LabelDataSet();
            //ds.Tables.Add(dt1);


            //ReportDocument oDocument = new ReportDocument();
        }

        private void holdList_Click(object sender, RoutedEventArgs e)
        {
            
           

            SalesList holdList = new SalesList(_parentWindow);
            OpenInvoiceOnHoldList openInvoice = new OpenInvoiceOnHoldList(OpenInvoice);
            holdList.InvoiceOpenMethod=openInvoice;
            pageTransitionControl.TransitionType = PageTransitionType.Slide;
            pageTransitionControl.ShowPage(holdList);

        }

        private void OpenInvoice(SalesInvoiceInfo invoiceInfo)
        {
            SalesInvoice salesInvoice = new SalesInvoice(_parentWindow, invoiceInfo);

            pageTransitionControl.TransitionType = PageTransitionType.Slide;
            pageTransitionControl.ShowPage(salesInvoice);
        }
    }
}
