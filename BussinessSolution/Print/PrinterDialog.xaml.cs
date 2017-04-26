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
using System.Windows.Shapes;
using System.Drawing.Printing;
using BussinessSolution.BS_PurchaseService;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
   

namespace BussinessSolution.Print
{
    /// <summary>
    /// Interaction logic for PrinterDialog.xaml
    /// </summary>
    public partial class PrinterDialog : Window
    {
        private Window _parentWindow;
        private PurchaseInfo _productInfo;
        //private System.Drawing.Printing.PrintDocument printDocument1;
        //   private System.Windows.Controls.PrintDialog printDialog1;
        public PrinterDialog(Window parentWindow, PurchaseInfo productInfo)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _productInfo = productInfo;
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                printerCombobox.Items.Add(printname);
            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = _parentWindow.Left + (_parentWindow.Width - this.ActualWidth) / 2;
            this.Top = _parentWindow.Top + (_parentWindow.Height - this.ActualHeight) / 2;
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LabelFormats.LabelDataSet.ProductLabelDataTable dt1 = new LabelFormats.LabelDataSet.ProductLabelDataTable();
                if(numOfBlankLabelTextbox.Text.Trim().Length>0)
                {
                    int blankLabelCount = 0;
                    int.TryParse(numOfBlankLabelTextbox.Text.Trim(), out blankLabelCount);
                    for(int i=0; i<blankLabelCount; i++)
                    {
                        DataRow dr = dt1.NewRow();
                        dt1.Rows.Add(dr);
                    }
                    
                }
                
                if (numOfCopyTextbox.Text.Trim().Length > 0)
                {
                    int copyCount = 0;
                    int.TryParse(numOfCopyTextbox.Text.Trim(), out copyCount);
                    for (int i = 0; i < copyCount; i++)
                    {
                        DataRow dr = dt1.NewRow();
                        dr["FPRODUCTCODE"] = "*" + _productInfo.ProductCode.ToString().PadLeft(10, '0') + "*";
                        dr["FRETAILRATE"] = _productInfo.RetailRate;
                        dr["FMRP"] = "MRP:";
                        dt1.Rows.Add(dr);
                    }

                }
            
                LabelFormats.LabelDataSet ds = new LabelFormats.LabelDataSet();
                ds.Tables.Add(dt1);


                ReportDocument oDocument = new ReportDocument();

                //oDocument.Load(@"D:\Work\Bussiness\BussinessSolution\BussinessSolution\LabelFormats\Label48_24.rpt");
                oDocument.Load(@"D:\Work\Bussiness\BussinessSolution\BussinessSolution\LabelFormats\LabelFormat_50MM25MM.rpt");
                oDocument.SetDataSource(ds.Tables[1]); // Added report data as dataset.

                oDocument.PrintToPrinter(1, true, 1, 10);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
