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

namespace BussinessSolution
{
    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow1 : Window
    {
        private Dictionary<string, string> _mdiChildren = new Dictionary<string, string>();
        public MainWindow1()
        {
            InitializeComponent();
        }

        private void NewInvoice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void SalesList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void SalesReturn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void InvoiceHold_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

       
    }
}
