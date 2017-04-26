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

namespace BussinessSolution.Purchase
{
    /// <summary>
    /// Interaction logic for PurchaseInfo.xaml
    /// </summary>
    public partial class PurchaseInfo :  UserControl, ITabbedMDI
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
                return "Tab2";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Tab 2 Title"; }
        }
        #endregion
        public PurchaseInfo()
        {
            InitializeComponent();
        }
    }
}
