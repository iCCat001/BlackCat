using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SQLite.Net;
using SQLite.Net.Interop;
using Xamarin.Forms;
using BlackCat.UWP;
using Windows.Foundation.Metadata;
//using SQLite.Net;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace BlackCat.UWP
{
    

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();


            var A = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();

            LoadApplication(new BlackCat.App());
        }
    }
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
            
        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "RandomThought.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);

            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);


            return connection;
        }
        public SQLite.Net.SQLiteConnection GetConnection(string pathN)
        {
            var fileName = "RandomThought.db3";
            var path = Path.Combine(pathN, fileName);

            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
        #endregion
    }
}
