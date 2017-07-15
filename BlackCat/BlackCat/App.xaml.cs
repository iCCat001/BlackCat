using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Xamarin.Forms;

namespace BlackCat
{
    public partial class App : Application
    {
        public static NavigationPage PageInfo;
        public static MainPage MainP;
        public static DataCatcher DataCatcherE;
        public static PersonMessage LoginPerson;
        public static PersonMessage DisplayPerson;
        public static PersonMessage CCat;
        public static ActivityMessage DemoActivity;
        public static ActivityMessage DisplayActivity;
        public static Theme SettingTheme;
        //string DatabasePath;
        //SQLite.Net.Interop.ISQLitePlatform SQLitePlatform;

        public App()
        {
            SettingTheme = new Theme();
            DataCatcherE = new DataCatcher();
            //LoginPerson = new PersonMessage(-1);

            TempClear();

            CCat = new PersonMessage(-1);
            DisplayPerson = CCat;
            DemoActivity = new ActivityMessage("", "", "", "", 10, BlackCat.App.CCat, -1);
            DisplayActivity = new ActivityMessage();

            MainP = new MainPage();
            LoginPage MainP1 = new LoginPage("","");
            PageInfo = new NavigationPage(MainP1);

            
            InitializeComponent();

            

            int a = 0;
            MainPage = PageInfo;
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static void TempClear()
        {
            BlackCat.App.DataCatcherE.ActivityTableC.SQLConnection.DropTable<SQLActivityUnit>();
            BlackCat.App.DataCatcherE.PersonTableC.SQLConnection.DropTable<SQLPersonUnit>();
            BlackCat.App.DataCatcherE.FollowListTableC.SQLConnection.DropTable<SQLFollowListUnit>();
            BlackCat.App.DataCatcherE.ActivityTableC.SQLConnection.CreateTable<SQLActivityUnit>();
            BlackCat.App.DataCatcherE.PersonTableC.SQLConnection.CreateTable<SQLPersonUnit>();
            BlackCat.App.DataCatcherE.FollowListTableC.SQLConnection.CreateTable<SQLFollowListUnit>();
        }
        public static void TempSee()
        {
            IEnumerable<SQLFollowListUnit> e = BlackCat.App.DataCatcherE.FollowListTableC.SQLConnection.Query<SQLFollowListUnit>("SELECT * FROM SQLFollowListUnit");
            IEnumerable<SQLPersonUnit> e1 = BlackCat.App.DataCatcherE.PersonTableC.SQLConnection.Query<SQLPersonUnit>("SELECT * FROM SQLPersonUnit");
            IEnumerable<SQLActivityUnit> e2 = BlackCat.App.DataCatcherE.ActivityTableC.SQLConnection.Query<SQLActivityUnit>("SELECT * FROM SQLActivityUnit");
        }
    }
}
