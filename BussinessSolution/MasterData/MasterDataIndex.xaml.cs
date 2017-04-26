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


namespace BussinessSolution.MasterData
{
    /// <summary>
    /// Interaction logic for MasterDataIndex.xaml
    /// </summary>
    public partial class MasterDataIndex : UserControl, ITabbedMDI
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
                return "MasterDataIndex";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Master Data"; }
        }
        #endregion
        public MasterDataIndex()
        {
            InitializeComponent();
           
            //pageTransitionControl.Margin = new Thickness(MainCanvas.Width, 5, 5, 5);
           
            //UserInfo userInfo = new UserInfo();
            //pageTransitionControl.TransitionType = PageTransitionType.Slide;
            //pageTransitionControl.ShowPage(userInfo);

           
        }

        //public void ShowMenu()
        //{
        //    //WrapPanel tileWrapPanel = new WrapPanel();
        //    //tileWrapPanel.Orientation = Orientation.Vertical;
        //    //tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
        //    //tileWrapPanel.Height = (110 * 3) + (6 * 3);
        //    Metrolizer metro = new Metrolizer();
        //    //metro.DisplayTiles(ref MetroStackPanel);
        //    Dictionary<string, string[]> di = metro.GetIconsAndPaths();
        //    foreach (KeyValuePair<string, string[]> key in di)
        //    {
        //        UserControls.Tile newTile = new UserControls.Tile();
        //        //newTile.ExecutablePath = kvp.Value(1)
        //        //newTile.TileIcon.Source = New BitmapImage(New Uri(kvp.Value(0), UriKind.Absolute))
        //        newTile.TileTxtBlck.Text = key.Key;
        //        newTile.Margin = new Thickness(0, 0, 6, 6);
        //        //tileWrapPanel.Children.Add(newTile);

        //        MetroStackPanel.Children.Add(newTile);
        //    }
        //}


        private void UserControl1_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            
            pageTransitionControl.TransitionType = PageTransitionType.Slide;
            pageTransitionControl.ShowPage(userInfo);
        }

        private void productInfo_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo itemInfo = new ItemInfo();
            ((System.Windows.FrameworkElement)(itemInfo.gridScroll)).Height = this.mainGrid.Height - (this.mainGrid.Height) * 0.15;
            pageTransitionControl.TransitionType = PageTransitionType.Slide;
            pageTransitionControl.ShowPage(itemInfo);
        }

        private void supplierInfo_Click(object sender, RoutedEventArgs e)
        {
            SupplierInfo supplierInfo = new SupplierInfo();
            ((System.Windows.FrameworkElement)(supplierInfo.gridScroll)).Height = this.mainGrid.Height - (this.mainGrid.Height) * 0.15;
            pageTransitionControl.TransitionType = PageTransitionType.Slide;
            pageTransitionControl.ShowPage(supplierInfo);
        }
    }
}
