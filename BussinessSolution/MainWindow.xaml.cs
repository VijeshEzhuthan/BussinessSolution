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

namespace BussinessSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> _mdiChildren = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();

            this.AddHandler(Common.WindowStyle.CloseableTabItem.CloseTabEvent, new RoutedEventHandler(this.CloseTab));
        }

        /// <summary>
        /// Add tab item to the tab
        /// </summary>
        /// <param name="mdiChild">This is the user control</param>
        private void AddTab(ITabbedMDI mdiChild)
        {
            //Check if the user control is already opened
            if (_mdiChildren.ContainsKey(mdiChild.UniqueTabName))
            {
                //user control is already opened in tab. 
                //So set focus to the tab item where the control hosted
                foreach (object item in tcMdi.Items)
                {
                    TabItem ti = (TabItem)item;
                    if (ti.Name == mdiChild.UniqueTabName)
                    {
                        ti.Focus();
                        break;
                    }
                }
            }
            else
            {
                //the control is not open in the tab item
                tcMdi.Visibility = Visibility.Visible;
                //tcMdi.Width = this.ActualWidth;
               // tcMdi.Height = this.ActualHeight;

                //((ITabbedMDI)mdiChild).CloseInitiated += new delClosed(CloseTab);
                
                //create a new tab item
                Common.WindowStyle.CloseableTabItem ti = new Common.WindowStyle.CloseableTabItem();
                //ti.CloseTab += new delClosed(CloseTab);
                //set the tab item's name to mdi child's unique name
                ti.Name = ((ITabbedMDI)mdiChild).UniqueTabName;
                //set the tab item's title to mdi child's title
                ti.Header = ((ITabbedMDI)mdiChild).Title;
                //set the content property of the tab item to mdi child
                ti.Content = mdiChild;
                //ti.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                //ti.VerticalContentAlignment = VerticalAlignment.Top;
                //add the tab item to tab control
                tcMdi.Items.Add(ti);
                //set this tab as selected
                tcMdi.SelectedItem = ti;
                //add the mdi child's unique name in the open children's name list
                _mdiChildren.Add(((ITabbedMDI)mdiChild).UniqueTabName, ((ITabbedMDI)mdiChild).Title);

            }
        }

        private void CloseTab(object source, RoutedEventArgs args)
        {
            TabItem tabItem = args.Source as TabItem;
            if (tabItem != null)
            {
                TabControl tabControl = tabItem.Parent as TabControl;
                if (tabControl != null)
                {
                    tabControl.Items.Remove(tabItem);
                    _mdiChildren.Remove(((ITabbedMDI)tabItem.Content).UniqueTabName);
                    tcMdi.Items.Remove(tabItem);
                }
            }
           
        }
                
        private void menuSale_Click(object sender, RoutedEventArgs e)
        {
            OpenSalesTab();
        }

        private void menuPurchase_Click(object sender, RoutedEventArgs e)
        {
            OpenPurchaseTab();
        }

        private void menuMasterData_Click(object sender, RoutedEventArgs e)
        {
            OpenMasterTab();
        }

        private void menuStock_Click(object sender, RoutedEventArgs e)
        {

            OpenStockTab();
        }

        private void menuMiscellaneous_Click(object sender, RoutedEventArgs e)
        {

        }

        public static RoutedCommand CustomRoutedCommand = new RoutedCommand();   
      
        #region 
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenSales_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenSalesTab();
        }

        private void OpenPurchase_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenPurchaseTab();
        }

        private void OpenMaster_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenMasterTab();
        }

        private void OpenStock_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenStockTab();
        }


        #endregion  

        private void OpenSalesTab()
        {
            Sales.SalesIndex mdiChild = new Sales.SalesIndex();
            ((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Height = this.Height - (this.Height) * 0.25;
            ((System.Windows.FrameworkElement)(mdiChild.MetroStackPanel)).Width = (this.Width * 7) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Width = (this.Width * 91) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Margin = new Thickness((this.Width * 7.1) / 100, 2, 5, 5);
            AddTab(mdiChild);
        }
        
        private void OpenPurchaseTab()
        {
            Purchase.PurchaseIndex mdiChild = new Purchase.PurchaseIndex(this);
            //((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Width = this.Width - 40 / this.Width;
            ((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Height = this.Height - (this.Height) * 0.25;
            ((System.Windows.FrameworkElement)(mdiChild.MetroStackPanel)).Width = (this.Width * 20) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Width = (this.Width * 75) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Margin = new Thickness((this.Width * 20.1) / 100, 2, 5, 5);
            AddTab(mdiChild);
        }

        private void OpenMasterTab()
        {
            MasterData.MasterDataIndex mdiChild = new MasterData.MasterDataIndex();
            //((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Width = this.Width - 50/this.Width;
            ((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Height = this.Height - (this.Height) * 0.25;
            ((System.Windows.FrameworkElement)(mdiChild.MetroStackPanel)).Width = (this.Width * 20) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Width = (this.Width * 78) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.pageTransitionControl)).Margin = new Thickness((this.Width * 20.1) / 100, 2, 5, 5);
            AddTab(mdiChild);
        }

        private void OpenStockTab()
        {
            Stock.StockIndex mdiChild = new Stock.StockIndex();
            //((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Width = this.Width - 50/this.Width;
            ((System.Windows.FrameworkElement)(mdiChild.mainGrid)).Height = this.Height - (this.Height) * 0.25;
            ((System.Windows.FrameworkElement)(mdiChild.searchPanel)).Width = (this.Width * 20) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.datagridStock)).Width = (this.Width * 78) / 100;
            ((System.Windows.FrameworkElement)(mdiChild.datagridStock)).Margin = new Thickness((this.Width * 20.1) / 100, 2, 5, 5);
            AddTab(mdiChild);
        }

    }

    public static class CustomCommands
    {
        public static readonly RoutedUICommand Sales = new RoutedUICommand
                (
                        "Sales",
                        "Sales",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.S, ModifierKeys.Control)
                                }
                );

        public static readonly RoutedUICommand Purchase = new RoutedUICommand
                (
                        "Purchase",
                        "Purchase",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.P, ModifierKeys.Control)
                                }
                );

        public static readonly RoutedUICommand Stock = new RoutedUICommand
                (
                        "Stock",
                        "Stock",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.O, ModifierKeys.Control)
                                }
                );

        public static readonly RoutedUICommand Miscellaneous = new RoutedUICommand
                (
                        "Miscellaneous",
                        "Miscellaneous",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.M, ModifierKeys.Control)
                                }
                );
        
        public static readonly RoutedUICommand MasterData = new RoutedUICommand
                (
                        "MasterData",
                        "MasterData",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.A, ModifierKeys.Control)
                                }
                );

        public static readonly RoutedUICommand Settings = new RoutedUICommand
                (
                        "Settings",
                        "Settings",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                        new KeyGesture(Key.E, ModifierKeys.Control)
                                }
                );

        //Define more commands here, just like the one above
    }
}
