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
    /// Interaction logic for SupplierInfo.xaml
    /// </summary>
    public partial class SupplierInfo : UserControl
    {
        PagerInfo pagerInfo = new PagerInfo();
        Int64 _supplierID = 0;
        public SupplierInfo()
        {
            try
            {
                InitializeComponent();

                List<BS_MasterDataService.SupplierInfo> suppierList = BLL.MasterDataBLL.GetSupplierInfo(pagerInfo);
                supplierGrid.ItemsSource = suppierList;
               // supplierGrid.Columns[1].Width = (gridScroll.Width * 20) / 100;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BS_MasterDataService.SupplierInfo supplierInfo = new BS_MasterDataService.SupplierInfo();
                supplierInfo.Address = txtAddress.Text;
                supplierInfo.IsManufacture = (bool)chkIsManufacture.IsChecked;
                supplierInfo.Phone = txtPhone.Text;
                supplierInfo.Pincode = txtPincode.Text;
                supplierInfo.State = txtState.Text;
                supplierInfo.SupplierID = _supplierID;
                supplierInfo.SupplierName = txtSupplierName.Text;
                supplierInfo.TIN = txtTIN.Text;
                BLL.MasterDataBLL.InsertOrUpdateSupplierInfo(supplierInfo);
                List<BS_MasterDataService.SupplierInfo> suppierList = BLL.MasterDataBLL.GetSupplierInfo(pagerInfo);
                supplierGrid.ItemsSource = null;
                supplierGrid.ItemsSource = suppierList;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtPincode.Text = string.Empty;
                txtSupplierName.Text = string.Empty;
                txtTIN.Text = string.Empty;
                txtState.Text = string.Empty;
                chkIsManufacture.IsChecked = false;
                _supplierID = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                
                BS_MasterDataService.SupplierInfo supplierInfo = supplierGrid.SelectedItem as BS_MasterDataService.SupplierInfo;
                if(supplierInfo!=null)
                {
                    txtAddress.Text = supplierInfo.Address;
                    txtPhone.Text = supplierInfo.Phone;
                    txtPincode.Text = supplierInfo.Pincode;
                    txtState.Text = supplierInfo.State;
                    txtSupplierName.Text = supplierInfo.SupplierName;
                    txtTIN.Text = supplierInfo.TIN;
                    _supplierID = supplierInfo.SupplierID;
                }

            }
            catch(Exception ex)
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
    }
}
