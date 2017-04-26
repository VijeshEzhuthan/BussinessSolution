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

namespace BussinessSolution.Purchase
{
    /// <summary>
    /// Interaction logic for PurchaseIndex.xaml
    /// </summary>
    public partial class PurchaseIndex : UserControl, ITabbedMDI
    {
        private Window _parentWindow;
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
                return "PurchaseIndex";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Purchase"; }
        }
        #endregion

        public PurchaseIndex(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
        }

        private void purchaseEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PurchaseEntry puchaseEntry = new PurchaseEntry(_parentWindow);

                pageTransitionControl.TransitionType = PageTransitionType.Slide;
                pageTransitionControl.ShowPage(puchaseEntry);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void purchaseInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PurchaseInfo purchaseInfo = new PurchaseInfo();

                pageTransitionControl.TransitionType = PageTransitionType.Slide;
                pageTransitionControl.ShowPage(purchaseInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
