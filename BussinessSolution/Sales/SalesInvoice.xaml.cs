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
using BussinessSolution.BS_CommonService;
using BussinessSolution.BS_SalesService;
using BussinessSolution.BS_PurchaseService;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BussinessSolution.Sales
{
     
    /// <summary>
    /// Interaction logic for SalesInvoice.xaml
    /// </summary>
    public partial class SalesInvoice : UserControl
    {
        CompanyInfo _companyInfo = null;
        SalesInvoiceInfo _invoiceInfo=new SalesInvoiceInfo();
        List<UnitOfMeasureInfo> uomList = new List<UnitOfMeasureInfo>();
        List<SalesItemBind> itemList=new List<SalesItemBind>();
        List<SalesItemInfo> itemInfoList = new List<SalesItemInfo>();
        private Window _parentWindow;

        public SalesInvoice(Window parentWindow, SalesInvoiceInfo invoiceInfo)
        {
             _parentWindow = parentWindow;
             itemInfoList = new List<SalesItemInfo>();
             itemList = new List<SalesItemBind>();
            InitializeComponent();
            uomList = BLL.CommonBLL.GetUnitOfMeasure();
            comboUoM.ItemsSource = uomList;
            comboUoM.DisplayMemberPath = "UnitOfMeasure";
            comboUoM.SelectedValuePath = "UnitOfMeasure";
            if (invoiceInfo == null)
            {
                GetNextInvoiceInfo();
            }
            else
            {
                _invoiceInfo = invoiceInfo;
                txtInvoiceNum.Text = _invoiceInfo.SalesID.ToString();
                int itemNum = 0;
                itemInfoList = invoiceInfo.SalesItemList.ToList();
               foreach(SalesItemInfo itemInfo in invoiceInfo.SalesItemList)
               {
                   itemNum++;
                   SalesItemBind itemBindInfo = new SalesItemBind();
                   itemBindInfo.ItemNum = itemNum;
                   itemBindInfo.ItemInfo.ProductID = itemInfo.ProductID;
                   itemBindInfo.DisplayProductName = itemInfo.ProductName + " - " + itemInfo.VendorName;
                   itemBindInfo.ItemInfo.DiscountRate = itemInfo.DiscountRate;
                    itemBindInfo.ItemInfo.Qty = itemInfo.Qty;


                    itemBindInfo.ItemInfo.RetailRate = itemInfo.RetailRate;
                    itemBindInfo.ItemInfo.Unit = itemInfo.Unit;

                    if (itemInfo.DiscountRate > 0)
                        itemBindInfo.ItemInfo.Amount = itemInfo.Qty * itemInfo.DiscountRate;
                   else
                        itemBindInfo.ItemInfo.Amount = itemInfo.Qty * itemInfo.RetailRate;

                   itemList.Add(itemBindInfo);
               }

                datagridProduct.ItemsSource = null;
                datagridProduct.ItemsSource = itemList;
                SetTotalAmount();

            }
            
            _companyInfo = BLL.CommonBLL.GetCompanyInfo();
            AddHotKeys();
        }

        private void GetNextInvoiceInfo()
        {
            try
            {
                NextInvoiceInfo invoiceNextInfo = BLL.SalesBLL.GetNextInvoiceInfo();
                txtInvoiceNum.Text = invoiceNextInfo.SalesID.ToString();
                _invoiceInfo.SalesID = invoiceNextInfo.SalesID;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void autoProductInfo_PatternChanged(object sender, BussinessSolution.UserControls.AutoComplete.AutoCompleteArgs args)
        {
            //check
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                int id = 0;
                Int32.TryParse(args.Pattern, out id);
                args.DataSource = BLL.PurchaseBLL.GetProductInfoByNameOrCode(args.Pattern, id);

                // args.DataSource = GetProductInfo(args.Pattern);
            }
        }

        private void autoProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                StockInfo productInfo = (StockInfo)autoProductName.SelectedItem;
                comboRetailRate.ItemsSource = null;
                if (productInfo != null)
                {
                    autoProductName.Text = productInfo.DisplayProductName;
                    List<decimal> priceList = productInfo.QtyPriceInfo.Select(i =>i.RetailRate).ToList();
                    comboRetailRate.ItemsSource = priceList;

                    if (productInfo.QtyPriceInfo.Length > 1)
                    {

                    }
                    else if(productInfo.QtyPriceInfo.Length>0)
                    {
                        comboRetailRate.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                if (autoProductName.SelectedItem != null && txtQty.Text.Length > 0 && comboRetailRate.Text != null && comboUoM.SelectedValue != null)
                {

                    ProductInfo productInfo = null;

                    if (autoProductName.SelectedItem != null)
                        productInfo = (ProductInfo)autoProductName.SelectedItem;

                    int itemNum = 0;
                    SalesItemInfo productInfoExist = null;
                    if (itemInfoList != null && itemInfoList.Count > 0)
                    {
                        itemNum = _invoiceInfo.SalesItemList.Length + 1;
                        productInfoExist = _invoiceInfo.SalesItemList.ToList().SingleOrDefault(i => i.ProductID == productInfo.ProductCode);
                    }
                    else
                        itemNum = 1;

                    if (productInfoExist != null)
                    {
                        MessageBox.Show("Product already in the list. If you want to change qty please update in the list it self");
                        this.autoProductName.Focus();
                        comboRetailRate.SelectedItem = null;
                        autoProductName.SelectedItem = null;
                        txtDiscount.Text = "";
                        txtQty.Text = "";
                    }
                    else
                    {

                        if (productInfo != null)
                        {
                            SalesItemBind itemBindInfo = new SalesItemBind();
                            itemBindInfo.ItemNum = itemNum;
                            itemBindInfo.ItemInfo.ProductID = productInfo.ProductCode;
                            decimal discountRate = 0;
                            decimal.TryParse(txtDiscount.Text, out discountRate);
                            itemBindInfo.DisplayProductName = productInfo.ProductDescription + " - " + productInfo.VendorInfo.SupplierName;
                            itemBindInfo.ItemInfo.DiscountRate = discountRate;
                            decimal qty = 0;
                            decimal.TryParse(txtQty.Text, out qty);
                            itemBindInfo.ItemInfo.Qty = qty;
                            decimal retailRate = 0;

                            retailRate = Convert.ToDecimal(comboRetailRate.Text);

                            itemBindInfo.ItemInfo.RetailRate = retailRate;
                            itemBindInfo.ItemInfo.Unit = comboUoM.SelectedValue.ToString();

                            if (discountRate > 0)
                                itemBindInfo.ItemInfo.Amount = qty * discountRate;
                            else
                                itemBindInfo.ItemInfo.Amount = qty * retailRate;


                            itemInfoList.Add(itemBindInfo.ItemInfo);
                            itemList.Add(itemBindInfo);
                            _invoiceInfo.SalesItemList = itemInfoList.ToArray();
                            datagridProduct.ItemsSource = null;
                            datagridProduct.ItemsSource = itemList;
                            SetTotalAmount();
                        }
                        
                        this.autoProductName.Focus();
                        comboRetailRate.SelectedItem = null;
                        autoProductName.SelectedItem = null;
                        txtDiscount.Text = "";
                        txtQty.Text = "";
                       

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
            SaveAndPrintInvoice(false);

            //if (itemInfoList.Count > 0)
            //{
            //    if (MessageBox.Show("Are you sure do you want to save print invoice?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {

            //        SaveInvoice();

            //    }
            //}

        }
      
        public class SalesItemBind 
        {
            private SalesItemInfo _itemInfo = new SalesItemInfo();
            public SalesItemInfo ItemInfo
            {
                get { return _itemInfo; }
                set { ItemInfo = value; }
            }
            public int ItemNum{get; set;}
            public string DisplayProductName{get; set;}
        }

        private void datagridProduct_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void comboRetailRate_GotFocus(object sender, RoutedEventArgs e)
        {
            comboRetailRate.IsDropDownOpen = true;
        }

        private void datagridProduct_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (e.EditAction == DataGridEditAction.Commit)
                {
                    var column = e.Column as DataGridBoundColumn;
                    if (column != null)
                    {
                        SalesItemBind er = e.Row.Item as SalesItemBind;
                        TextBox el = e.EditingElement as TextBox;
                        var bindingPath = (column.Binding as Binding).Path.Path;
                        if (bindingPath == "ItemInfo.RetailRate")
                        {
                            decimal retailRate = 0;
                            retailRate = Convert.ToDecimal(el.Text);
                            er.ItemInfo.RetailRate = retailRate;
                         
                        }
                        else if(bindingPath == "ItemInfo.Qty")
                        {
                            decimal qty = 0;
                            qty = Convert.ToDecimal(el.Text);
                            er.ItemInfo.Qty = qty;
                        }
                        else if (bindingPath == "ItemInfo.DiscountRate")
                        {
                            decimal discountRate = 0;
                            discountRate = Convert.ToDecimal(el.Text);
                            er.ItemInfo.DiscountRate = discountRate;

                             
                        }
                        if (er.ItemInfo.DiscountRate > 0)
                            er.ItemInfo.Amount = er.ItemInfo.DiscountRate * er.ItemInfo.Qty;
                        else
                           er.ItemInfo.Amount = er.ItemInfo.RetailRate * er.ItemInfo.Qty;

                        SetTotalAmount();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void SetTotalAmount()
        {
            decimal totalAmount = 0;
            decimal netAmount = 0;
            totalAmount = itemInfoList.Sum(i => i.Amount);
            netAmount = itemInfoList.Where(i => i.DiscountRate == 0).Sum(j => j.Amount);
            netAmount = netAmount - netAmount * (decimal)(0.05);
            decimal itemDiscount = itemInfoList.Where(i => i.DiscountRate > 0).Sum(j => j.Amount);
            netAmount += itemDiscount;
            txtDiscountAmount.Text = netAmount.ToString("#.##");

            txtTotalAmount.Text = totalAmount.ToString("#.##");
           
        }

        private bool SaveAndPrintInvoice(bool isHold)
        {
            try
            {
                if (itemInfoList.Count > 0)
                {
                    _invoiceInfo.NetAmount = Convert.ToDecimal(txtDiscountAmount.Text);
                    decimal paidAmount = 0;
                    decimal.TryParse(txtPaidAmount.Text, out paidAmount);
                    _invoiceInfo.IsHold = isHold;
                    _invoiceInfo.PaidAmount = paidAmount;
                    _invoiceInfo.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                    _invoiceInfo.SalesItemList = itemInfoList.ToArray();
                    _invoiceInfo.InvoiceNum = BLL.SalesBLL.InsertOrUpdateSalesInfo(_invoiceInfo);
                    return true;
                    
                    //if (_invoiceInfo.InvoiceNum > 0)
                    //{
                    //    PrintInvoice();
                    //    GetNextInvoiceInfo();
                    //    itemInfoList = new List<BS_SalesService.SalesItemInfo>();
                    //    itemList = new List<SalesItemBind>();
                    //    datagridProduct.ItemsSource = null;
                    //    this.autoProductName.Focus();
                    //    txtTotalAmount.Text = string.Empty;
                    //    txtDiscountAmount.Text = string.Empty;

                    //}
                }
                else
                {
                    MessageBox.Show("Please add item");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        private void btnSavePrint_Click(object sender, RoutedEventArgs e)
        {
            if(SaveAndPrintInvoice(false))
            {
                if (_invoiceInfo.InvoiceNum > 0)
                {
                    PrintInvoice();
                    GetNextInvoiceInfo();
                    itemInfoList = new List<BS_SalesService.SalesItemInfo>();
                    itemList = new List<SalesItemBind>();
                    datagridProduct.ItemsSource = null;
                    this.autoProductName.Focus();
                    txtTotalAmount.Text = string.Empty;
                    txtDiscountAmount.Text = string.Empty;
                }
            }
        }


        private void PrintInvoice()
        {
            try
            {
                LabelFormats.InvoiceDataSet.InvoiceItemDataTable itemTable = new LabelFormats.InvoiceDataSet.InvoiceItemDataTable();
                LabelFormats.InvoiceDataSet.InvoiceMainDataTable mainTable = new LabelFormats.InvoiceDataSet.InvoiceMainDataTable();
                System.Data.DataRow drMain = mainTable.NewRow();
                drMain["FINVOICENUM"] = _invoiceInfo.InvoiceNum;
                drMain["FSHOPNAME"] = _companyInfo.CompanyName;
                drMain["FADDRESS1"] = _companyInfo.Address1;
                drMain["FADDRESS2"] = _companyInfo.Address2;
                drMain["FPINCODE"] = _companyInfo.Pincode;
                drMain["FPHONE"] = _companyInfo.Phone1;
                drMain["FTINNUM"] = _companyInfo.TinNum;
                drMain["FSTATE"] = _companyInfo.State;
                drMain["FTOTALAMOUNT"] = txtTotalAmount.Text.ToString();
                drMain["FDISCOUNT"] = "";
                drMain["FNETAMOUNT"] = txtDiscountAmount.Text.ToString();
                drMain["FDATE"] = DateTime.Now.ToString("dd-MM-yyyy");
                drMain["FTIME"] = DateTime.Now.ToString("HH:mm");
                drMain["FITEMCOUNT"] = itemList.Count.ToString();
                mainTable.Rows.Add(drMain);

                foreach (SalesItemBind itemInfo in itemList)
               {
                   System.Data.DataRow drItem = itemTable.NewRow();
                   drItem["FITEMNUM"] = itemInfo.ItemNum;
                   drItem["FITEMDESC"] = itemInfo.DisplayProductName;
                   drItem["FQTY"] = itemInfo.ItemInfo.Qty;
                   drItem["FRETAILRATE"] = itemInfo.ItemInfo.RetailRate.ToString("#.##");
                   drItem["FDISCOUNT"] = itemInfo.ItemInfo.DiscountRate.ToString("#.##");

                   drItem["FAMOUNT"] = itemInfo.ItemInfo.Amount.ToString("#.##");
                   itemTable.Rows.Add(drItem);
               }

                LabelFormats.InvoiceDataSet ds = new LabelFormats.InvoiceDataSet();
                ds.Tables.Remove("InvoiceItem");
                ds.Tables.Remove("InvoiceMain");
                ds.Tables.Add(mainTable);
                ds.Tables.Add(itemTable);


                ReportDocument oDocument = new ReportDocument();
                oDocument.Load(@"D:\Work\Bussiness\BussinessSolution\BussinessSolution\LabelFormats\InvoiceFormat.rpt");
                oDocument.SetDataSource(ds); // Added report data as dataset.

                oDocument.PrintToPrinter(1, true, 1, 10);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.datagridProduct.Items.Count > 0)
                {
                    SalesItemBind itemBindInfo = this.datagridProduct.SelectedValue as SalesItemBind;
                    itemList.RemoveAt(this.datagridProduct.SelectedIndex);
                    SalesItemInfo productInfoExist = itemInfoList.SingleOrDefault(i => i.ProductID == itemBindInfo.ItemInfo.ProductID);
                    itemInfoList.Remove(productInfoExist);
                    SetTotalAmount();
                    datagridProduct.Items.Refresh();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());     
            }
        }

        private void btnHold_Click(object sender, RoutedEventArgs e)
        {
            if(SaveAndPrintInvoice(true))
            {
                if (_invoiceInfo.InvoiceNum > 0)
                {
                    GetNextInvoiceInfo();
                    itemInfoList = new List<BS_SalesService.SalesItemInfo>();
                    itemList = new List<SalesItemBind>();
                    datagridProduct.ItemsSource = null;
                    this.autoProductName.Focus();
                    txtTotalAmount.Text = string.Empty;
                    txtDiscountAmount.Text = string.Empty;
                }
            }
        }
        
        private void btnWithDraw_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
