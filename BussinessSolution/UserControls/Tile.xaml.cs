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

namespace BussinessSolution.UserControls
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public Tile()
        {
            InitializeComponent();
            
        }

        public string TitleText
        {
            set
            {
                TileTxtBlck.Text = value;
            }
            get { return TileTxtBlck.Text; }
        }

        public ImageSource TileIconSource
        {
            set { TileIcon.Source = value; }
            
        }

        bool IsMousDown = false;

        public static readonly RoutedEvent ClickEvent;
        static Tile()
        {
            Tile.ClickEvent =
             EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble,
                        typeof(RoutedEventHandler),
                        typeof(Tile));
        }
        public event RoutedEventHandler Click
        {
            add { AddHandler(Button.ClickEvent, value); }
            remove { RemoveHandler(Button.ClickEvent, value); }
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            IsMousDown = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (IsMousDown)
                RaiseEvent(new RoutedEventArgs(Tile.ClickEvent, this));
            IsMousDown = false;
        }
    }
}
