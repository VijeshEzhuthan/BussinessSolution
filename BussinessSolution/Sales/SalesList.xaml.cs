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
using BussinessSolution.BS_SalesService;

namespace BussinessSolution.Sales
{
    /// <summary>
    /// Interaction logic for SalesList.xaml
    /// </summary>
    public partial class SalesList :  UserControl
    {
        private Window _parentWindow;

        private System.Delegate _delegateInvoiceOpen;
        public Delegate InvoiceOpenMethod
        {
            set { _delegateInvoiceOpen = value; }
        }
                
        public SalesList(Window parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
            BindHoldList();
        }

        private void BindHoldList()
        {
            try
            {
                SalesInvoiceInfo[] holdList = BLL.SalesBLL.GetSaleHoldList();
                datagridHoldInvoice.ItemsSource = holdList;
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void datagridHoldInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row == null)
                return;
            
            _delegateInvoiceOpen.DynamicInvoke();
        }

        private void datagridHoldInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {

                SalesInvoiceInfo itemBindInfo = this.datagridHoldInvoice.SelectedValue as SalesInvoiceInfo;
                // find row for the first selected item

                if (itemBindInfo != null)
                {                 
                    _delegateInvoiceOpen.DynamicInvoke(itemBindInfo);
                }
            }
        }
    }
}
