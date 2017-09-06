using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackCat
{
    public partial class App : Application
    {
        public static NavigationPage PageInfo;
        public static MainPage MainP;
        public static DataCatcher DataCatcherE;
        public static PersonMessage LoginPerson;
        public static PersonMessage DisplayPerson;

        //预置数据-
        public static PersonMessage PP;
        public static PersonMessage CCat;
        public static ActivityMessage DemoActivity;
        public static ActivityMessage Demo2;
        //-end

        public static ActivityMessage DisplayActivity;
        public static Theme SettingTheme;
        public static PicUriChanger UriChanger;

        public App()
        {
            //InitializeComponent();

            UriChanger = new PicUriChanger();
            SettingTheme = new Theme();
            DataCatcherE = new DataCatcher();

            //LoginPerson = new PersonMessage(-1);
            //TempClear();
            CCat = new PersonMessage(-1);
            //PP = new PersonMessage(-2);
            DisplayPerson = CCat;   //temp, Change After taking Log in
            //DemoActivity = new ActivityMessage("", "", "", "", 10, BlackCat.App.CCat, -1);
            //Demo2 = new ActivityMessage("", "", "", "", 4, BlackCat.App.CCat, -2);


            DisplayActivity = new ActivityMessage();
            MainP = new MainPage();
            PageInfo = new NavigationPage(new LoginPage("", ""));

            
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
