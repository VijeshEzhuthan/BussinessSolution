using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;

namespace BussinessSolution
{
    public class Metrolizer
    {
        private double wrapPanelX = 0;
        public Dictionary<string, string[]> IconsPathsDi = new Dictionary<string, string[]>();

        //public void DisplayTiles(ref StackPanel metroStackPanel)
        //{
        //    string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        //    string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        //    Dictionary<string, string[]> di = GetIconsAndPaths();
        //   foreach(KeyValuePair<string,string[]> key in di)
        //   {
        //       AddTiles(key, metroStackPanel, "t");
        //   }
        //}

        private void WrapPanelLocation(string letter, WrapPanel tileWrapPanel)
        {
           
        }

        //private void AddTiles(KeyValuePair<string, string[]> coll, StackPanel metroStackPanel, string letter)
        //{
        //    WrapPanel tileWrapPanel = new WrapPanel();
        //     tileWrapPanel.Orientation = Orientation.Vertical;
        //    tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
        //    tileWrapPanel.Height = (110 * 3) + (6 * 3);

        //    foreach (KeyValuePair<string, string[]> kvp in IconsPathsDi)
        //    {
        //        UserControls.Tile newTile = new UserControls.Tile();
        //        //newTile.ExecutablePath = kvp.Value(1)
        //        //newTile.TileIcon.Source = New BitmapImage(New Uri(kvp.Value(0), UriKind.Absolute))
        //        newTile.TileTxtBlck.Text = kvp.Key;
        //        newTile.Margin = new Thickness(0, 0, 6, 6);
        //        tileWrapPanel.Children.Add(newTile);
        //    }

        //    //WrapPanelLocation(letter, tileWrapPanel);
        //    metroStackPanel.Children.Add(tileWrapPanel);
        //}

        //public WrapPanel AddTiles(KeyValuePair<string, string[]> coll, string letter)
        //{
        //    WrapPanel tileWrapPanel = new WrapPanel();
        //    tileWrapPanel.Orientation = Orientation.Vertical;
        //    tileWrapPanel.Margin = new Thickness(0, 0, 20, 0);
        //    tileWrapPanel.Height = (110 * 3) + (6 * 3);

        //    foreach (KeyValuePair<string, string[]> kvp in IconsPathsDi)
        //    {
        //        UserControls.Tile newTile = new UserControls.Tile();
        //        //newTile.ExecutablePath = kvp.Value(1)
        //        //newTile.TileIcon.Source = New BitmapImage(New Uri(kvp.Value(0), UriKind.Absolute))
        //        newTile.TileTxtBlck.Text = kvp.Key;
        //        newTile.Margin = new Thickness(0, 0, 6, 6);
        //        tileWrapPanel.Children.Add(newTile);
        //    }

        //    //WrapPanelLocation(letter, tileWrapPanel);
        //    return tileWrapPanel;
        //}

        public void AddToDictionary(string displayName,string tileIconPath,string exePath)
        {
            if (!IconsPathsDi.ContainsKey(displayName))
            {
                IconsPathsDi.Add(displayName, new string[] { tileIconPath, exePath });
            }
        }

        public Dictionary<string,string[]> GetIconsAndPaths()
        {
            AddToDictionary("Test Title1", "1", "2");
            AddToDictionary("Test Title2", "2", "1");
            AddToDictionary("Test Title3", "3", "2");
            AddToDictionary("Test Title4", "4", "1");
            AddToDictionary("Test Title5", "5", "2");
            AddToDictionary("Test Title6", "6", "1");
            AddToDictionary("Test Title7", "7", "2");
            AddToDictionary("Test Title8", "8", "1");
            AddToDictionary("Test Title9", "9", "2");
            AddToDictionary("Test Title10", "11", "1");

            return IconsPathsDi;
        }
    }
}
