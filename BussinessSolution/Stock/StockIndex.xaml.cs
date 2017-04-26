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

namespace BussinessSolution.Stock
{
    /// <summary>
    /// Interaction logic for StockIndex.xaml
    /// </summary>
    public partial class StockIndex : UserControl, ITabbedMDI
    {
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
                return "StockIndex";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Stock"; }
        }
        #endregion
        public StockIndex()
        {
            InitializeComponent();
        }

        private void stockEntry_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stockInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
