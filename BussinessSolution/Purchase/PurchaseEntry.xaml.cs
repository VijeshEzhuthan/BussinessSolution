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
using System.Collections.ObjectModel;
using BussinessSolution.BS_CommonService;
using BussinessSolution.BS_PurchaseService;

namespace BussinessSolution.Purchase
{
    
    /// <summary>
    /// Interaction logic for PurchaseEntry.xaml
    /// </summary>
    public partial class PurchaseEntry : UserControl
    {
        private Window _parentWindow;
     
        List<BS_PurchaseService.PurchaseInfo> purchaseList = new List<BS_PurchaseService.PurchaseInfo>();
        List<UnitOfMeasureInfo> uomList = new List<UnitOfMeasureInfo>();
        public PurchaseEntry(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            autoVendorName.Focus();
            
            uomList = BLL.CommonBLL.GetUnitOfMeasure();
            AddHotKeys();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.autoVendorName.Focus();
            //this.autoProductName.Focus();
        }

        /// <summary>
        /// occurs when the user stops typing after a delayed timespan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected void autoProductInfo_PatternChanged(object sender, BussinessSolution.UserControls.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                int id=0;
                Int32.TryParse(args.Pattern,out id);
                args.DataSource = BLL.PurchaseBLL.GetProductInfoByNameOrCode(args.Pattern, id);
                
               // args.DataSource = GetProductInfo(args.Pattern);
            }
        }

        private void autoProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ProductInfo productInfo = (ProductInfo)autoProductName.SelectedItem;
                if (productInfo != null)
                {
                    autoProductName.Text = productInfo.DisplayProductName;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void autoUOM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                UnitOfMeasureInfo uomInfo = (UnitOfMeasureInfo)autoUOM.SelectedItem;
                if (uomInfo != null)
                    autoUOM.Text = uomInfo.UnitOfMeasure;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void autoUOM_PatternChanged(object sender, UserControls.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = uomList.Where((uom, match) => uom.UnitOfMeasure.ToLower().Contains(args.Pattern.ToLower()));
            }
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {

                if (autoProductName.SelectedItem != null && txtWholeSaleRate.Text.Length > 0 && autoUOM.SelectedItem != null &&
                    txtQty.Text.Length > 0 && txtProfit.Text.Length > 0 && txtTaxRate.Text.Length > 0)
                {

                    ProductInfo productInfo = null;

                    if (autoProductName.SelectedItem != null)
                        productInfo = (ProductInfo)autoProductName.SelectedItem;
                    UnitOfMeasureInfo uomInfo =null;
                    if (autoUOM != null)
                        uomInfo = (UnitOfMeasureInfo)autoUOM.SelectedItem;
                    BS_PurchaseService.ProductInfo productInfoExist = purchaseList.SingleOrDefault(i => i.ProductCode == productInfo.ProductCode);
                    if (productInfoExist != null)
                    {
                        MessageBox.Show("Product already in the list. If you want to change qty please update in the list it self");
                    }
                    else
                    {
                        BS_PurchaseService.PurchaseInfo purchaseInfo = new BS_PurchaseService.PurchaseInfo();
                        if (productInfo != null)
                        {

                            purchaseInfo.DisplayProductName = productInfo.DisplayProductName;
                            purchaseInfo.ProductCategoryInfo = productInfo.ProductCategoryInfo;
                           
                            purchaseInfo.ProductCode = productInfo.ProductCode;
                            purchaseInfo.ProductDescription = productInfo.ProductDescription;
                            //purchaseInfo. = productInfo.ProductSize;
                            decimal qty = 0;
                            decimal.TryParse(txtQty.Text.ToString(), out qty);
                            purchaseInfo.Qty = qty;
                            decimal profitInPercentage = 0;
                            decimal.TryParse(txtProfit.Text.ToString(), out profitInPercentage);
                            purchaseInfo.RetailRate = profitInPercentage;
                            purchaseInfo.VendorInfo = productInfo.VendorInfo; ;
                            
                            purchaseInfo.UoM = uomInfo.UnitOfMeasure;
                            decimal wholeSaleRate = 0;
                            decimal.TryParse(txtWholeSaleRate.Text.ToString(), out wholeSaleRate);
                            purchaseInfo.WholeSaleRate = wholeSaleRate;
                            decimal taxRate = 0;
                            decimal.TryParse(txtTaxRate.Text.ToString(), out taxRate);
                           // purchaseInfo.TaxRate = taxRate;
                            decimal retailRate = 0;
                            decimal.TryParse(txtRetailRate.Text.ToString(), out retailRate);
                            purchaseInfo.RetailRate = retailRate;
                            purchaseList.Add(purchaseInfo);
                        }
                        datagridProduct.ItemsSource = null;
                        datagridProduct.ItemsSource = purchaseList;
                        //this.autoProductName.Focus();
                        autoUOM.SelectedItem = null;
                        autoProductName.SelectedItem = null;
                        txtWholeSaleRate.Text = "";
                        txtQty.Text = "";
                        txtProfit.Text = "";
                        txtRetailRate.Text = "";
                        txtTaxRate.Text = "";
                    }
                }
            }
        }

        private void AddHotKeys()
        {
            try
            {
                RoutedCommand firstSettings = new RoutedCommand();
                firstSettings.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));
                CommandBindings.Add(new CommandBinding(firstSettings, My_first_event_handler));
            }
            catch (Exception err)
            {
                //handle exception error
            }
        }

        private void My_first_event_handler(object sender, ExecutedRoutedEventArgs e)
        {

                if (purchaseList.Count > 0)
                {
                    if (MessageBox.Show("Are you sure do you want to save purchase info?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        PurchaseDetaiInfo purchaseDetailInfo = new PurchaseDetaiInfo();
                        //if (invoiceDate.SelectedDate != null)
                        //{
                        //    DateTime billDate = invoiceDate.SelectedDate ?? DateTime.Now;
                        //    if(billDate!=null)
                        //    {
                        //        purchaseDetailInfo.InvoiceDate = Convert.ToInt32(billDate.ToString("yyyyMMdd"));
                        //    }
                        //}
                        purchaseDetailInfo.InvoiceNum = txtInvoiceNum.Text;
                        purchaseDetailInfo.PurchaseitemList = purchaseList.ToArray();
                        decimal totalAmount = 0;
                        decimal.TryParse(txtTotalAmount.Text, out totalAmount);
                        purchaseDetailInfo.TotalAmount = totalAmount;

                        VendorInfo vendorInfo = (VendorInfo)autoVendorName.SelectedItem;
                         if (vendorInfo != null)
                             purchaseDetailInfo.VendorID = vendorInfo.VendorID;

                         BLL.PurchaseBLL.InsertPurchaseInfo(purchaseDetailInfo);
                         purchaseList = new List<BS_PurchaseService.PurchaseInfo>();
                         datagridProduct.ItemsSource = null;
                         //this.autoProductName.Focus();
                    }
                }
            
        }

        private void autoVendorName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            VendorInfo vendorInfo = (VendorInfo)autoVendorName.SelectedItem;
            if (vendorInfo != null)
                autoVendorName.Text = vendorInfo.VendorName;
        }

        private void autoVendorName_PatternChanged(object sender, UserControls.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                args.DataSource = BLL.CommonBLL.GetVendorInfo(args.Pattern);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
               
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void BarcodePrint_Click(object sender, RoutedEventArgs e)
        {
            if (datagridProduct.Items.Count > 0 && datagridProduct.SelectedIndex>-1)
            {
                BS_PurchaseService.PurchaseInfo purchaseInfo = (BS_PurchaseService.PurchaseInfo)datagridProduct.Items[datagridProduct.SelectedIndex];
                Print.PrinterDialog printerDialog = new Print.PrinterDialog(_parentWindow, purchaseInfo);
                printerDialog.Owner = _parentWindow;
                printerDialog.ShowInTaskbar = false;

                printerDialog.ShowDialog();
            }
        }



        private void invoiceDate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Back || e.Key == Key.Delete  || e.Key == Key.Left  || e.Key == Key.Right)
                {

                }
                else
                {
                    switch (invoiceDateText.Text.Length)
                    {
                        case 2:
                            {
                                string s = invoiceDateText.Text + "-";
                                invoiceDateText.Text = s;// invoiceDate.Text + "-";
                                break;
                            }
                        case 5:
                            {
                                string[] values = invoiceDateText.Text.Split('-');
                                if (Convert.ToInt32(values[1]) > 12)
                                {
                                    MessageBox.Show("Not a valid month");
                                }
                                else
                                {
                                    invoiceDateText.Text = invoiceDateText.Text + "-";
                                }
                                break;
                            }
                        default:
                            break;

                    }

                    if (invoiceDateText.Text.Length > 0)
                    {
                        invoiceDateText.SelectionStart = invoiceDateText.Text.Length; // add some logic if length is 0
                        invoiceDateText.SelectionLength = 0;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

    }

}
