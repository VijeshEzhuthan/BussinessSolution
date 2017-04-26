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
using BussinessSolution.BS_MasterDataService;

namespace BussinessSolution.MasterData
{
    /// <summary>
    /// Interaction logic for ItemInfo.xaml
    /// </summary>
    public partial class ItemInfo : UserControl
    {
        PagerInfo pagerInfo = new PagerInfo();
        BS_MasterDataService.ProductInfo _productInfo = null;
        Int64 _supplierID = 0;
        public ItemInfo()
        {
            InitializeComponent();

            List<BS_MasterDataService.ProductInfo> productList = BLL.MasterDataBLL.GetProductInfo(pagerInfo);
            productGrid.ItemsSource = productList;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BS_MasterDataService.ProductInfo productInfo = new BS_MasterDataService.ProductInfo();
                if(_productInfo!=null)
                    productInfo.ProductCode=_productInfo.ProductCode;

                productInfo.ProductDescription= txtProductName.Text;

                productInfo.IsGiftItem = chkIsGiftItem.IsChecked == true ? 'Y' : 'N';
                productInfo.IsTaxableItem = chkIsTaxable.IsChecked == true ? 'Y' : 'N';
                BS_MasterDataService.SupplierInfo supplierInfo = (BS_MasterDataService.SupplierInfo)autoManufactureName.SelectedItem;
                if (supplierInfo != null)
                {
                    productInfo.VendorInfo = supplierInfo;
                }
                else
                {
                    productInfo.VendorInfo = _productInfo.VendorInfo;
                }

                CategoryInfo categoryInfo = (CategoryInfo)autoCategoryName.SelectedItem;
                if (categoryInfo != null)
                {
                    productInfo.ProductCategoryInfo = categoryInfo;
                }
                else
                {
                    productInfo.ProductCategoryInfo = _productInfo.ProductCategoryInfo;
                }

                if(txtProfit.Text.Trim().Length>0)
                {
                    productInfo.ProfitPrecentage = Convert.ToDecimal(txtProfit.Text);
                }

                productInfo.IsDifferentRateInSize = chkDifferentRateForSize.IsChecked == true ? 'Y' : 'N';   
            
                if(productInfo!=null)
                {
                    if (BLL.MasterDataBLL.InsertOrUpdateProductInfo(productInfo))
                    {
                        List<BS_MasterDataService.ProductInfo> productList = BLL.MasterDataBLL.GetProductInfo(pagerInfo);
                        productGrid.ItemsSource = productList;
                        txtProductName.Text = string.Empty;
                        autoManufactureName.Text = string.Empty;
                        autoCategoryName.Text = string.Empty;
                        chkIsGiftItem.IsChecked = false;
                        chkIsTaxable.IsChecked = false;
                        chkDifferentRateForSize.IsChecked = false;
                        _productInfo = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                _productInfo = productGrid.SelectedItem as BS_MasterDataService.ProductInfo;
                if (_productInfo != null)
                {
                    txtProductName.Text = _productInfo.ProductDescription;
                    autoManufactureName.Text = _productInfo.VendorInfo.SupplierName;
                    autoCategoryName.Text = _productInfo.ProductCategoryInfo.CategoryName;
                    chkIsGiftItem.IsChecked = _productInfo.IsGiftItem == 'Y' ? true : false;
                    chkIsTaxable.IsChecked = _productInfo.IsTaxableItem == 'Y' ? true : false;
                    chkDifferentRateForSize.IsChecked = _productInfo.IsDifferentRateInSize == 'Y' ? true : false;

                 //   _supplierID = supplierInfo.SupplierID;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteButtom_Click(object sender, RoutedEventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void autoCategoryName_PatternChanged(object sender, UserControls.AutoComplete.AutoCompleteArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.Pattern))
                    args.CancelBinding = true;
                else
                {
                    PagerInfo pager = new PagerInfo();
                    pager.Filter = args.Pattern;
                    args.DataSource = BLL.MasterDataBLL.GetGroupCategoryInfo(pager);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void autoCategoryName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CategoryInfo categoryInfo = (CategoryInfo)autoCategoryName.SelectedItem;
            if (categoryInfo != null)
                autoCategoryName.Text = categoryInfo.CategoryName;
        }

        private void autoManufactureName_PatternChanged(object sender, UserControls.AutoComplete.AutoCompleteArgs args)
        {
            if (string.IsNullOrEmpty(args.Pattern))
                args.CancelBinding = true;
            else
            {
                PagerInfo pager = new PagerInfo();
                pager.Filter = args.Pattern;
                args.DataSource = BLL.MasterDataBLL.GetSupplierInfo(pager);
            }

        }

        private void autoManufactureName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BS_MasterDataService.SupplierInfo supplierInfo = (BS_MasterDataService.SupplierInfo)autoManufactureName.SelectedItem;
            if (supplierInfo != null)
                autoManufactureName.Text = supplierInfo.SupplierName;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtProductName.Text = string.Empty;
            autoManufactureName.Text = string.Empty;
            autoCategoryName.Text = string.Empty;
            chkIsGiftItem.IsChecked = false;
            chkIsTaxable.IsChecked = false;
            chkDifferentRateForSize.IsChecked = false;
            _productInfo = null;
        }

        private void autoSearchCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //CategoryInfo categoryInfo = (CategoryInfo)autoCategoryName.SelectedItem;
            //autoCategoryName.Text = categoryInfo.CategoryName;

        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    PagerInfo pagerInfo = new PagerInfo();
                    pagerInfo.Filter = autoCategoryName.Text;

                    List<BS_MasterDataService.ProductInfo> productList = BLL.MasterDataBLL.GetProductInfo(pagerInfo);
                    productGrid.ItemsSource = productList;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
