using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Interop;

namespace BlackCat
{
    //1. UI以及表层控制类
    //1.1. 总入口类
    public partial class MainPage : ContentPage
    {
        StackLayout MainPageBaseSL;
        StackLayout ActionListSL;
        StackLayout PersonMessageSL;

        ScrollView MainPageBaseSV;
        ScrollView ActionListSV;

        StackLayout[] ActionUnits;

        int NowIndex = 1;
        static public int SelectIndex = 1;

        static public SuperBotton SuperButtonM;


        /*
         * 占位 ：其他公共组件声明
         */

        Theme DefaultTheme = BlackCat.App.SettingTheme;

        public MainPage()
        {
            InitializeComponent();

            MainBaseAL = new AbsoluteLayout();
            MainBaseSL = new StackLayout();
            SuperBottonBV = new StackLayout();

            ActionListSL = new StackLayout();
            PersonMessageSL = new StackLayout();

            MainPageBaseSV = new ScrollView();
            ActionListSV = new ScrollView();

            ActionUnits = new StackLayout[20];
            MainPageBaseSL = new StackLayout();

            SuperButtonM = new SuperBotton(1, 1);

            /*
             * 占位 ：其他公共组件定义
             */



            //PersonMessageSL = MainPersonMessageSLBuilder(1, 0);
            PersonMessageSL = new PersonMessageBoard(1, 1);
            //ActionListSL = MainActionListSLBuilder(1, 0);
            //ActionListSL.Spacing = 0;
            ActionListSL = new ActionList(-1, -1);


            MainPageBaseSV.Content = MainPageBaseSL;


            MainPageBaseSL.Spacing = 0;

            MainPageBaseSV.Content = MainPageBaseSL;

            
            ActionListSV.Content = ActionListSL;
            MainPageBaseSL.BackgroundColor = DefaultTheme.ColorLightGrayClear;

            MainPageBaseSL.Children.Add(PersonMessageSL);
            MainPageBaseSL.Children.Add(ActionListSV);

            //MainPageBaseSL.Children.Add();
            TableView TVTest = new TableView();
            //TVTest.Root.Add()
            //Content = MainPageBaseSV;


            MainBaseSlBuilder();
            SuperBottonBVBuilder();

            MainBaseAL.Children.Add(MainBaseSL);
            MainBaseAL.Children.Add(SuperBottonBV);

            SuperBottonBV.Children.Add(SuperButtonM);

            Content = MainBaseAL;

            MainBaseSL.Children.Add(MainPageBaseSV);
            NavigationPage.SetHasNavigationBar(this, false);

            ActionListSL.ChildAdded += ActionListSL_ChildAdded;
            ActionListSL.LayoutChanged += ActionListSL_ChildAdded;
        }

        private void ActionListSL_ChildAdded(object sender, EventArgs e)
        {
            if (NowIndex != SelectIndex)
            {
                SuperBottonBV.Children.Clear();
                SuperButtonM = new SuperBotton(SelectIndex, 1);
                SuperBottonBV.Children.Add(SuperButtonM);
                NowIndex = SelectIndex;
            }
        }

        public MainPage(int Key = 0)
        {
            Content = ActionListSV;
        }

        /*test*/
        public AbsoluteLayout MainBaseAL;
        public StackLayout MainBaseSL;
        public StackLayout SuperBottonBV;

        private void MainBaseSlBuilder()
        {
            AbsoluteLayout.SetLayoutBounds(MainBaseSL, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(MainBaseSL, AbsoluteLayoutFlags.All);
        }
        private void SuperBottonBVBuilder()
        {
            AbsoluteLayout.SetLayoutBounds(SuperBottonBV, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(SuperBottonBV, AbsoluteLayoutFlags.SizeProportional);
            //SuperBottonBV.BackgroundColor = Color.FromRgba(128, 128, 128, 128);
            SuperBottonBV.HeightRequest = 82;
            SuperBottonBV.WidthRequest = 82;
            SuperBottonBV.HorizontalOptions = LayoutOptions.EndAndExpand;
            SuperBottonBV.VerticalOptions = LayoutOptions.EndAndExpand;
            IsVisible = true;

        }
        /*test*/

        private StackLayout MainPersonMessageSLBuilder(int ID, int key = 0)
        {
            StackLayout NewBoard = new StackLayout();

            StackLayout ControlBarSL = new StackLayout();
            StackLayout ListTitleSL = new StackLayout();
            Image HeadImgIM = new Image();

            Label UserNameLB = new Label();
            Label UserRealNameLB = new Label();
            Label UserDescripeLB = new Label();
            Label UserIntegrityMarkLB = new Label();

            NewBoard.BackgroundColor = DefaultTheme.GetMainThemeColor();
            NewBoard.Spacing = 5;

            /*
             * ControlBarSL = ControlBarSLBuilder(ID);
             * 占位 ：构建控制条 并绑定事件
             */


            HeadImgIM.Source = ImageSource.FromResource("BlackCat.Images.Icon-CCat853.gif");
            HeadImgIM.HorizontalOptions = LayoutOptions.Center;
            HeadImgIM.HeightRequest = 170;
            HeadImgIM.WidthRequest = 170;


            /*
             * UserNameLB.Text = PersonMessage.Name;
             * UserNameLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
             * 占位 ：姓名
             */
            //----Temp----
            UserNameLB.Text = "C-Cat";
            UserNameLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            UserNameLB.TextColor = DefaultTheme.ColorWhiteClear;
            UserNameLB.HorizontalOptions = LayoutOptions.Center;
            //-----------

            /*
             * UserRealNameLB.Text = PersonMessage.RealName;
             * UserRealNameLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
             * 占位 ：真实姓名
             */
            //----Temp----
            UserRealNameLB.Text = "信息学院软件工程一班 王凯";
            UserRealNameLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            UserRealNameLB.TextColor = DefaultTheme.ColorWhiteClear;
            UserRealNameLB.HorizontalOptions = LayoutOptions.Center;
            //-----------

            /*
             * UserDescripeLB.Text = PersonMessage.Descripe;
             * UserDescripeLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
             * 占位 ：签名
             */
            //----Temp----
            UserDescripeLB.Text = "没什么方向感但对一切充满好奇的程序员";
            UserDescripeLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            UserDescripeLB.TextColor = DefaultTheme.ColorWhiteClear;
            UserDescripeLB.HorizontalOptions = LayoutOptions.Center;
            //-----------

            /*
             * UserIntegrityMarkLB.Text = PersonMessage.Mark;
             * UserIntegrityMarkLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
             * 占位 ：信用分数
             */
            //----Temp----
            UserIntegrityMarkLB.Text = "信用评分：94";
            UserIntegrityMarkLB.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            UserIntegrityMarkLB.TextColor = DefaultTheme.ColorWhiteClear;
            UserIntegrityMarkLB.HorizontalOptions = LayoutOptions.Center;
            //-----------

            /*
             * ListTitleSL = ListTitleSLBuilder(ID);
             * 占位 ：构建标题枢纽 并绑定事件
             */

            NewBoard.Children.Add(ControlBarSL);
            NewBoard.Children.Add(HeadImgIM);
            NewBoard.Children.Add(UserNameLB);
            NewBoard.Children.Add(UserRealNameLB);
            NewBoard.Children.Add(UserDescripeLB);
            NewBoard.Children.Add(UserIntegrityMarkLB);
            NewBoard.Children.Add(ListTitleSL);



            return NewBoard;
        }
        private StackLayout MainActionListSLBuilder(int ID, int key = 0)
        {
            StackLayout NewBoard = new StackLayout();



            return NewBoard;
        }


    }
    //1.2. 其他类
    public class ActionPage : ActionBasePage
    {

        //StackLayout MainBaseSL;

        StackLayout ControlBarSL;
        ScrollView MainBoardSV;

        StackLayout MainBoardSL;

        StackLayout MainMessageBoardSL;
        StackLayout CreaterMessageBoard;
        StackLayout MainTextBoardSL;
        StackLayout FollowerBoardSL;
        StackLayout[] GuestBookUnitsSL;
        SuperBotton SuperButtonM;

        Label MainTitleLB;

        Label TitleLB;
        Label TimeLB;
        Label StartPlaceLB;
        Label[] TagsLB;
        Label PeopleNumberLB;

        Label CreaterNameLB;
        Label CreaterRealNameLB;
        Label CreaterMarkLB;
        Label MainTextLB;

        Label FollowerLB;

        /*
         * 占位：Icons
         */

        PersonMessage Creater;
        Theme SettingTheme = new Theme();
        int GuestbookNumberLimit = 20;

        public ActionPage()
        {
            //MainBaseSL = new StackLayout();
            ControlBarSL = new StackLayout();

            MainBoardSV = new ScrollView();
            MainBoardSL = new StackLayout();

            TitleLB = new Label();
            TimeLB = new Label();
            StartPlaceLB = new Label();
            PeopleNumberLB = new Label();
            CreaterNameLB = new Label();
            CreaterRealNameLB = new Label();
            CreaterMarkLB = new Label();
            MainTextLB = new Label();
            FollowerLB = new Label();

            SuperButtonM = new SuperBotton(4, 1);
        }
        public ActionPage(int ActionID, int key = 0) : this()
        {
            BlackCat.App.DataCatcherE.SetCatchType(1);
            BlackCat.App.DisplayActivity= new ActivityMessage((SQLActivityUnit)BlackCat.App.DataCatcherE.Catch(ActionID));
            BlackCat.App.DataCatcherE.SetCatchType(2);
            Creater = BlackCat.App.DisplayActivity.Creater;

            TagsLB = new Label[BlackCat.App.DisplayActivity.TagsCount];



            ControlBarSL = ControlBaseSLBulider();
            MainBoardSV.Content = MainBoardSLBuilder();
            MainBoardSL.Children.Add(ControlBarSL);
            MainBoardSL.Children.Add(MainBoardSV);

            //MainBaseSL.Children.Add(ControlBarSL);
            //MainBaseSL.Children.Add(MainBoardSL);

            MainBaseSL.Spacing = 0;
            MainBoardSL.Spacing = 0;


            //MainBaseLayout.Children.Add(MainBaseSL);

            //Content = MainBaseLayout;
            MainBaseSL.Children.Add(MainBoardSL);
            SuperBottonBV.Children.Add(SuperButtonM);


            Content = MainBaseAL;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private int BaseLayoutBuild(int Key = 0)
        {


            return 1;
        }

        private StackLayout ControlBaseSLBulider()
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.BackgroundColor = SettingTheme.GetMainThemeColor();
            ReturnObject.HeightRequest = 40;
            ReturnObject.Orientation = StackOrientation.Horizontal;

            Button BackButton = new Button();
            BackButton.Image = (FileImageSource)ImageSource.FromFile("Icons/Back40.gif");
            BackButton.BorderWidth = 0;
            BackButton.BackgroundColor = Color.Transparent;

            BackButton.HeightRequest = 40;
            BackButton.WidthRequest = BackButton.HeightRequest;
            BackButton.HorizontalOptions = LayoutOptions.Start;

            ReturnObject.Children.Add(BackButton);

            BackButton.Clicked += Back;

            MainTitleLB = new Label();
            MainTitleLB.Text = "活动详情";
            MainTitleLB.HorizontalOptions = LayoutOptions.CenterAndExpand;
            MainTitleLB.VerticalOptions = LayoutOptions.CenterAndExpand;
            MainTitleLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            MainTitleLB.TextColor = SettingTheme.ColorWhiteClear;
            ReturnObject.Children.Add(MainTitleLB);


            Button MoreButton = new Button();
            MoreButton.Image = (FileImageSource)ImageSource.FromFile("Icons/More54.gif");
            MoreButton.BackgroundColor = Color.Transparent;
            MoreButton.BorderWidth = 0;

            MoreButton.HorizontalOptions = LayoutOptions.End;
            ReturnObject.Children.Add(MoreButton);
            /*
             * 
             * 占位：选项按钮事件绑定
             */
            return ReturnObject;
        }
        private StackLayout MainBoardSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Children.Add(MainMessageBoardSLBuilder());
            ReturnObject.Children.Add(CreaterMessageBoardSLBuilder());
            ReturnObject.Children.Add(MainTextBoardSLBuilder());
            ReturnObject.Children.Add(FollowerBoardSLBuilder());

            int i = 0;
            StackLayout[] Temp;
            Temp = GuestbookBoardBuilder();
            while (Temp[i] != null)
            {
                ReturnObject.Children.Add(Temp[i]);
                i++;
            }
            ReturnObject.Padding = new Thickness(8, 0, 8, 0);
            return ReturnObject;
        }
        private StackLayout MainMessageBoardSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            TitleLB.Text = BlackCat.App.DisplayActivity.Title;
            TitleLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            TitleLB.TextColor = SettingTheme.GetMainThemeColor();

            ReturnObject.Children.Add(TitleLB);


            StackLayout TimeDisplaySL = new StackLayout();
            TimeDisplaySL.Orientation = StackOrientation.Horizontal;

            /*
            Image TimeImage = new Image();
            TimeImage.Source = FileImageSource.FromFile("Icons/TimeA15.gif");
            TimeDisplaySL.Children.Add(TimeImage);
            */

            Label TimeTitleLB = new Label();
            TimeTitleLB.Text = "时间：";
            TimeTitleLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            TimeTitleLB.TextColor = SettingTheme.GetMainThemeColor();
            TimeDisplaySL.Children.Add(TimeTitleLB);

            TimeLB.Text = BlackCat.App.DisplayActivity.PlanDate.ToString("yyyy/MM/dd hh:mm dddd", new System.Globalization.CultureInfo("zh-cn"));
            TimeLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            TimeLB.TextColor = SettingTheme.GetMainThemeColor();

            TimeDisplaySL.Children.Add(TimeLB);

            ReturnObject.Children.Add(TimeDisplaySL);


            StackLayout PlaceDisplaSL = new StackLayout();
            PlaceDisplaSL.Orientation = StackOrientation.Horizontal;

            /*
             * PlaceDisplaSL.Children.Add();
             * 占位：位置小图标
             */

            Label StartPlaceTitleLB = new Label();
            StartPlaceTitleLB.Text = "位置：";
            StartPlaceTitleLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            StartPlaceTitleLB.TextColor = SettingTheme.GetMainThemeColor();
            PlaceDisplaSL.Children.Add(StartPlaceTitleLB);

            StartPlaceLB.Text = BlackCat.App.DisplayActivity.StartPlace;
            StartPlaceLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            StartPlaceLB.TextColor = SettingTheme.GetMainThemeColor();

            PlaceDisplaSL.Children.Add(StartPlaceLB);

            ReturnObject.Children.Add(PlaceDisplaSL);


            StackLayout TagsDisplaySL = new StackLayout();
            TagsDisplaySL.Orientation = StackOrientation.Horizontal;

            /*
             * TagsDisplaSL.Children.Add();
             * 占位：标签小图标
             */

            Label TagsTitleLB = new Label();
            TagsTitleLB.Text = "标签：";
            TagsTitleLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            TagsTitleLB.TextColor = SettingTheme.GetMainThemeColor();
            TagsDisplaySL.Children.Add(TagsTitleLB);

            int i = 0;
            while (i <= 2 && BlackCat.App.DisplayActivity.Tags[i] != null)
            {
                
                TagsLB[i] = new Label();
                TagsLB[i].Text = BlackCat.App.DisplayActivity.Tags[i];
                TagsLB[i].FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                TagsLB[i].TextColor = SettingTheme.GetMainThemeColor();

                TagsDisplaySL.Children.Add(TagsLB[i]);
                i++;
            }
            ReturnObject.Children.Add(TagsDisplaySL);


            StackLayout PeopleNumberDisplaSL = new StackLayout();
            PeopleNumberDisplaSL.Orientation = StackOrientation.Horizontal;

            /*
             * PlaceDisplaSL.Children.Add();
             * 占位：人数小图标
             */

            Label PeopleNumberTitleLB = new Label();
            PeopleNumberTitleLB.Text = "人数：";
            PeopleNumberTitleLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            PeopleNumberTitleLB.TextColor = SettingTheme.GetMainThemeColor();
            PeopleNumberDisplaSL.Children.Add(PeopleNumberTitleLB);

            PeopleNumberLB.Text = BlackCat.App.DisplayActivity.PeopleNumber + "/" + BlackCat.App.DisplayActivity.PeopleNumberLimit;
            PeopleNumberLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            PeopleNumberLB.TextColor = SettingTheme.GetMainThemeColor();

            PeopleNumberDisplaSL.Children.Add(PeopleNumberLB);

            ReturnObject.Children.Add(PeopleNumberDisplaSL);

            ReturnObject.Children.Add(CrossLineBuiler());

            return ReturnObject;
        }
        private StackLayout CreaterMessageBoardSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Orientation = StackOrientation.Horizontal;

            Image CreaterHead = new Image();
            CreaterHead.Source = FileImageSource.FromFile("Icons/Icon-CCat54.gif");
            ReturnObject.Children.Add(CreaterHead);

            /*
             * ReturnObject.Children.Add();
             * 占位：创建者头像
             */

            StackLayout NameDisplaySL = new StackLayout();
            NameDisplaySL.HorizontalOptions = LayoutOptions.StartAndExpand;
            NameDisplaySL.Spacing = 0;

            CreaterNameLB.Text = " " + BlackCat.App.DisplayActivity.Creater.Name;
            CreaterNameLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            CreaterNameLB.TextColor = SettingTheme.GetMainThemeColor();
            CreaterNameLB.VerticalOptions = LayoutOptions.Center;
            NameDisplaySL.Children.Add(CreaterNameLB);

            CreaterRealNameLB.Text = " " + BlackCat.App.DisplayActivity.Creater.RealName;
            CreaterRealNameLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            CreaterRealNameLB.TextColor = SettingTheme.GetMainThemeColor();
            CreaterRealNameLB.VerticalOptions = LayoutOptions.Center;
            NameDisplaySL.Children.Add(CreaterRealNameLB);

            ReturnObject.Children.Add(NameDisplaySL);

            CreaterMarkLB.Text = BlackCat.App.DisplayActivity.Creater.Mark.ToString();
            CreaterMarkLB.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            CreaterMarkLB.TextColor = SettingTheme.GetMainThemeColor();
            ReturnObject.Children.Add(CreaterMarkLB);

            /*
             *  占位： 绑定点击事件
             */

            return ReturnObject;
        }
        private StackLayout MainTextBoardSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            MainTextLB.Text = BlackCat.App.DisplayActivity.Describe;
            MainTextLB.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

            ReturnObject.Children.Add(MainTextLB);
            ReturnObject.Children.Add(CrossLineBuiler());
            return ReturnObject;
        }
        private StackLayout FollowerBoardSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();
            ReturnObject.Orientation = StackOrientation.Horizontal;

            ReturnObject.Children.Add(new Label()
            {
                Text = "已参与：",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            });

            /*
             * 占位：添加FollowerID指代的用户（使用DataCatcher查找）的头像 & 绑定点击事件
             */


            return ReturnObject;
        }
        private StackLayout[] GuestbookBoardBuilder()
        {
            StackLayout[] ReturnObject = new StackLayout[GuestbookNumberLimit];




            for (int i = 0; i < GuestbookNumberLimit; i++)
            {

            }
            return ReturnObject;
        }

        private Label CrossLineBuiler()
        {
            Label Line = new Label();

            Line.Text = "-----------------------------------------------------";
            //Line.TextColor = SettingTheme.GetMainThemeColor();
            Line.TextColor = SettingTheme.ColorGrayClear;

            return Line;
        }

        void Back(object sender, EventArgs e)
        {
            BlackCat.App.PageInfo.PopAsync(true);
        }


    }
    public class PersonMessageBoard : StackLayout
    {
        StackLayout MainControlBarSL;

        Image PersonMessageBigHeadImgIM;

        Label PersonMessageNameLB;
        Label PersonMessageRealNameLB;
        Label PersonMessageDescribeLB;
        Label PersonMessageMarkLB;



        PersonMessage DisplayPersonMessage;
        public PersonMessageBoard()
        {

            MainControlBarSL = new StackLayout();

            PersonMessageBigHeadImgIM = new Image();

            PersonMessageNameLB = new Label();
            PersonMessageRealNameLB = new Label();
            PersonMessageDescribeLB = new Label();
            PersonMessageMarkLB = new Label();




            this.BackgroundColor = BlackCat.App.SettingTheme.GetMainThemeColor();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        public PersonMessageBoard(int LoginPersonMessageID, int AimPersonMessageID, int Key = 0) : this()
        {
            PersonMessageBulider(AimPersonMessageID, Key);

            MainControlBarSL = MainControlBuilder(LoginPersonMessageID, AimPersonMessageID);
            PersonMessageBigHeadImgIM = PersonMessageBigHeadImgBVBuilder(AimPersonMessageID);

            PersonMessageLBBulier(AimPersonMessageID);



            AddToChildren();



        }
        private int PersonMessageBulider(int AimPersonMessageID, int Key = 0)
        {
            BlackCat.App.DataCatcherE.SetCatchType(2);
            if (Key == -1)
            {
                DisplayPersonMessage =BlackCat.App.CCat;  //Android异常：返回null
            }
            else
                DisplayPersonMessage =BlackCat.App.DisplayPerson;

            return 1;
        }
        private StackLayout MainControlBuilder(int LoginPersonMessageID, int AimPersonMessageID)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Orientation = StackOrientation.Horizontal;
            if (LoginPersonMessageID != AimPersonMessageID)
            {

                Button BackButton = new Button();
                FileImageSource BackImgS = new FileImageSource();
                BackImgS = (FileImageSource)FileImageSource.FromFile("Icons/Back256.gif");
                BackButton.Image = BackImgS;

                BackButton.HeightRequest = 50;
                BackButton.HorizontalOptions = LayoutOptions.StartAndExpand;
                BackButton.BackgroundColor = Color.Transparent;
                BackButton.BorderWidth = 0;

                /*
                 * 占位：添加返回按钮 & 事件绑定
                 */

                ReturnObject.Children.Add(BackButton);
            }

            /*
             * 占位：添加选项按钮 & 事件绑定
             */

            Button MoreButton = new Button();
            MoreButton.Image = ((FileImageSource)ImageSource.FromFile("Icons/More54.gif"));

            MoreButton.Margin = new Thickness();

            MoreButton.HeightRequest = 54;
            MoreButton.WidthRequest = MoreButton.HeightRequest;
            MoreButton.HorizontalOptions = LayoutOptions.EndAndExpand;
            MoreButton.BackgroundColor = Color.Transparent;
            //MoreButton.Image.SetValue(Aspect, Aspect.AspectFill);

            MoreButton.Clicked += Test1;

            ReturnObject.Children.Add(MoreButton);

            return ReturnObject;

        }
        void Test1(object sender, EventArgs args)
        {
            /*
            SQLPersonTableControl DBTest = new SQLPersonTableControl();
            DBTest.Alter(BlackCat.App.CCat);
            
            IEnumerable<TableMapping> a = DBTest.SQLConnection.TableMappings;
            
            
            SQLiteCommand Command = DBTest.SQLConnection.CreateCommand("SELECT * FROM SQLPersonUnit WHERE Name =" + "'C-Cat'");
            IEnumerable<SQLPersonUnit> a = DBTest.SQLConnection.Query<SQLPersonUnit>(Command.CommandText);
            DBTest.SQLConnection.DeleteAll<SQLPersonUnit>();
            IEnumerable<SQLPersonUnit> b = DBTest.SQLConnection.Query<SQLPersonUnit>(Command.CommandText);
            */

            BlackCat.App.TempSee();
            BlackCat.App.TempClear();
        }
        private Image PersonMessageBigHeadImgBVBuilder(int AimPersonMessageID)
        {
            Image ReturnObject = new Image();
            if (DisplayPersonMessage.HeadImage != null)
            {
                ReturnObject = DisplayPersonMessage.HeadImage;

                ReturnObject.HeightRequest = 170;
                ReturnObject.WidthRequest = ReturnObject.HeightRequest;
                ReturnObject.HorizontalOptions = LayoutOptions.Center;
            }

            return ReturnObject;
        }
        private int PersonMessageLBBulier(int AimPersonMessageID)
        {
            PersonMessageNameLB.Text = DisplayPersonMessage.Name;
            PersonMessageNameLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            PersonMessageNameLB.TextColor = (BlackCat.App.SettingTheme).ColorWhiteClear;
            PersonMessageNameLB.HorizontalOptions = LayoutOptions.Center;


            PersonMessageRealNameLB.Text = DisplayPersonMessage.RealName;
            PersonMessageRealNameLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            PersonMessageRealNameLB.TextColor = (BlackCat.App.SettingTheme).ColorWhiteClear;
            PersonMessageRealNameLB.HorizontalOptions = LayoutOptions.Center;


            PersonMessageDescribeLB.Text = DisplayPersonMessage.Describe;
            PersonMessageDescribeLB.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            PersonMessageDescribeLB.TextColor = (BlackCat.App.SettingTheme).ColorWhiteClear;
            PersonMessageDescribeLB.HorizontalOptions = LayoutOptions.Center;

            PersonMessageMarkLB.Text = "信用评分：" + DisplayPersonMessage.Mark;
            PersonMessageMarkLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            PersonMessageMarkLB.TextColor = (BlackCat.App.SettingTheme).ColorWhiteClear;
            PersonMessageMarkLB.HorizontalOptions = LayoutOptions.Center;
            return 1;
        }

        private int AddToChildren()
        {
            this.Children.Add(MainControlBarSL);
            this.Children.Add(PersonMessageBigHeadImgIM);
            this.Children.Add(PersonMessageNameLB);
            this.Children.Add(PersonMessageRealNameLB);
            this.Children.Add(PersonMessageDescribeLB);
            this.Children.Add(PersonMessageMarkLB);
            return 1;
        }
        void Test(object sender, EventArgs args)
        {
            BlackCat.App.PageInfo.PushAsync(new ActionPage(-1, -1));
            bool a = NavigationPage.GetHasNavigationBar(BlackCat.App.PageInfo);
        }
    }
    public class ActionList : StackLayout
    {
        public static StackLayout BottomStack = new StackLayout();
        ActivityUnitsBoard ActionUnitsBoard;
        StackLayout TitleControlBarSL;
        int TitleControlNumber = 3;
        string[] TitleControlString = { "首页动态", "动态中心", "个人资料" };
        public static Label[]  TitleControl;

        public static Label SelectLabel;
        public static int SelectIndex;
        ListSLAdapter Adapter = new ListSLAdapter(0);

        public StackLayout TitleControlBar()
        {
            StackLayout ReturnObject = new StackLayout();
            TitleControl = new Label[TitleControlNumber];
            TitleControlBarSL = new StackLayout();
            for (int i = 0; i < TitleControlNumber; i++)
            {
                TitleControl[i] = new Label();
            }

            ReturnObject.Orientation = StackOrientation.Horizontal;
            ReturnObject.HeightRequest = 40;
            ReturnObject.BackgroundColor = (BlackCat.App.SettingTheme).GetMainThemeColor();
            //ReturnObject.Spacing = 5;


            for (int i = 0; i < TitleControlNumber; i++)
            {
                int Index = i;
                var tgr = new TapGestureRecognizer();
                tgr.Command = new Command(() => {
                    if (SelectLabel.Text != TitleControl[Index].Text)
                    {
                        SelectLabel = TitleControl[Index];
                        SelectIndex = Index;
                        PageChange();
                    }
                });
                TitleControl[Index].GestureRecognizers.Add(tgr);


                TitleControl[Index].Text = TitleControlString[i];
                TitleControl[Index].FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
                TitleControl[Index].TextColor = (BlackCat.App.SettingTheme).ColorWhiteClear;
                TitleControl[Index].HorizontalOptions = LayoutOptions.CenterAndExpand;
                TitleControl[Index].VerticalOptions = LayoutOptions.EndAndExpand;
                TitleControl[Index].StyleId = i.ToString();

                ReturnObject.Children.Add(TitleControl[Index]);
            }


            return ReturnObject;

        }
        public static void PageChange()
        {
            //MainPage.SuperButtonM = new SuperBotton(int.Parse(SelectLabel.StyleId), 1);

            BottomStack.Children.Clear();
            BottomStack.Children.Add((StackLayout)(new ListSLAdapter(0)).AdapterGet(int.Parse(SelectLabel.StyleId), -1));
            MainPage.SelectIndex = int.Parse(SelectLabel.StyleId) + 1;
        }
        public ActionList()
        {
            BottomStack.Children.Clear();
            SelectLabel = new Label();
            ActionUnitsBoard = new ActivityUnitsBoard();
            this.Spacing = 0;
        }
        public ActionList(int LoginPersonMessageID, int Key = 0) : this()
        {
            this.Children.Add(TitleControlBar());
            ActionUnitsBoard = new ActivityUnitsBoard(LoginPersonMessageID, Key);
            BottomStack.Children.Add(ActionUnitsBoard);
            this.Children.Add(BottomStack);
        }
    }
    public class MessageList : StackLayout
    {

        StackLayout[] MessageSLUnits;
        int MessageNumberLimit;

        Theme SettingTheme;
        /*
        public MessageList(int ID, int Key = 0)
        {

        }
        public MessageList()
        {

        }
        */

        public MessageList()
        {
            MessageNumberLimit = 20;
            MessageSLUnits = new StackLayout[MessageNumberLimit];
            SettingTheme = BlackCat.App.SettingTheme;
            //this.BackgroundColor = SettingTheme.ColorLightGrayClear;
            this.Spacing = 2;
        }
        public MessageList(int ID, int Key = 0) : this()
        {
            MessageSLUnitsBuilder(Key);
            this.Spacing = 3;

            int i = 0;
            while (MessageSLUnits[i] != null && i < MessageNumberLimit - 1)
            {
                this.Children.Add(MessageSLUnits[i]);
                i++;
            }
        }
        private void MessageSLUnitsBuilder(int Key = 0)
        {
            for (int i = 0; i < MessageNumberLimit; i++)
            {
                var tgr = new TapGestureRecognizer();
                ActivityMessage Temp = new ActivityMessage();
                MessageSLUnits[i] = new StackLayout();

                BlackCat.App.DataCatcherE.SetCatchType(6);
                if (Key == -1)
                {
                    Temp = (ActivityMessage)(BlackCat.App.DataCatcherE.Catch(-1));
                }
                else
                {
                    foreach (SQLActivityUnit e in (IEnumerable<SQLActivityUnit>)BlackCat.App.DataCatcherE.Catch(BlackCat.App.DisplayPerson.ID))
                    {
                        Temp = new ActivityMessage(e);

                        tgr.Command = new Command(() =>
                        {
                            BlackCat.App.PageInfo.PushAsync(new ActionPage((int)Temp.ID));
                        });

                        MessageSLUnits[i].GestureRecognizers.Add(tgr);

                        MessageSLUnits[i].Children.Add(MessageSLUnitsSubBuilder(Temp));

                        MessageSLUnits[i].StyleId = i.ToString();
                    }

                    return;

                }
                tgr.Command = new Command(() => {
                    BlackCat.App.PageInfo.PushAsync(new ActionPage((int)Temp.ID));
                });

                MessageSLUnits[i].GestureRecognizers.Add(tgr);

                MessageSLUnits[i].Children.Add(MessageSLUnitsSubBuilder(Temp));

                MessageSLUnits[i].StyleId = i.ToString();

                //MessageSLUnits[i].Padding = new Thickness(8, 0, 8, 0);

                /*
                if (Key == -1)
                    return;
                */
            }
        }

        private StackLayout MessageSLUnitsSubBuilder(ActivityMessage Temp)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Padding = new Thickness(8, 8, 8, 8);
            ReturnObject.Orientation = StackOrientation.Horizontal;
            ReturnObject.BackgroundColor = Color.White;
            //ReturnObject.Spacing = 10;

            Image PicShow = new Image()
            {
                Source = ImageSource.FromFile("Icons/NewMessage160.gif"),
                Aspect = Aspect.AspectFill,
                HeightRequest = 42,
                WidthRequest = 42,
            };

            ReturnObject.Children.Add(PicShow);

            StackLayout RightSL = new StackLayout();
            RightSL.Padding = new Thickness(8, 0, 0, 0);

            Label MessageLB = new Label()
            {
                Text = "已发布活动：",
                TextColor = SettingTheme.ColorGrayClear,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };


            Label ActivityTitleLB = new Label()
            {
                Text = Temp.Title,
                TextColor = SettingTheme.GetMainThemeColor(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };

            RightSL.Children.Add(MessageLB);
            RightSL.Children.Add(ActivityTitleLB);

            ReturnObject.Children.Add(RightSL);
            return ReturnObject;

        }

    }
    public class ItemList : StackLayout
    {
        Theme SettingTheme;
        PersonMessage PersonDisplay;

        public ItemList()
        {
            SettingTheme = BlackCat.App.SettingTheme;
            //this.MinimumHeightRequest = 500;
            //this.BackgroundColor = Color.White;
            //this.Spacing = -5;
        }
        public ItemList(int ID, int Key = 0) : this()
        {
            BlackCat.App.DataCatcherE.SetCatchType(2);
            PersonDisplay = BlackCat.App.DisplayPerson;
            this.Children.Add(StandardSLsBuilder());

        }
        private StackLayout StandardSLsBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Spacing = 3;

            StackLayout NameSL = new StackLayout();
            NameSL.Orientation = StackOrientation.Horizontal;
            NameSL.BackgroundColor = Color.White;
            NameSL.Padding = new Thickness(8, 15, 8, 15);
            NameSL.Children.Add(new Label()
            {
                Text = "昵称：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });
            NameSL.Children.Add(new Label()
            {
                Text = PersonDisplay.Name,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            });

            ReturnObject.Children.Add(NameSL);

            StackLayout RealNameSL = new StackLayout();
            RealNameSL.Orientation = StackOrientation.Horizontal;
            RealNameSL.Padding = new Thickness(8, 15, 8, 15);
            RealNameSL.BackgroundColor = Color.White;
            RealNameSL.Children.Add(new Label()
            {
                Text = "真实信息：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });
            RealNameSL.Children.Add(new Label()
            {
                Text = PersonDisplay.RealName,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            });

            ReturnObject.Children.Add(RealNameSL);

            StackLayout DiscribeSL = new StackLayout();
            DiscribeSL.Orientation = StackOrientation.Horizontal;
            DiscribeSL.BackgroundColor = Color.White;
            DiscribeSL.Padding = new Thickness(8, 15, 8, 15);
            DiscribeSL.Children.Add(new Label()
            {
                Text = "个人描述：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });
            DiscribeSL.Children.Add(new Label()
            {
                Text = PersonDisplay.Describe,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            });

            ReturnObject.Children.Add(DiscribeSL);

            StackLayout MarkSL = new StackLayout();
            MarkSL.Orientation = StackOrientation.Horizontal;
            MarkSL.BackgroundColor = Color.White;
            MarkSL.Padding = new Thickness(8, 15, 8, 15);
            MarkSL.Children.Add(new Label()
            {
                Text = "信用评分：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });

            StackLayout LabelSL = new StackLayout();
            LabelSL.Children.Add(new Label()
            {
                Text = PersonDisplay.Mark.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = SettingTheme.GetMainThemeColor(),
            });
            LabelSL.HorizontalOptions = LayoutOptions.FillAndExpand;
            LabelSL.VerticalOptions = LayoutOptions.Fill;

            MarkSL.Children.Add(LabelSL);
            StackLayout ComplementSL = new StackLayout();
            ComplementSL.Orientation = StackOrientation.Horizontal;

            Image ComplementIM = new Image();
            ComplementIM.Source = ImageSource.FromFile("Icons/ComplementB256.gif");
            ComplementIM.Aspect = Aspect.AspectFill;
            ComplementIM.HeightRequest = 36;
            ComplementIM.WidthRequest = 36;
            ComplementIM.HorizontalOptions = LayoutOptions.EndAndExpand;
            ComplementSL.Children.Add(ComplementIM);
            /*
            ComplementSL.Children.Add(new Image()
            {
                Source = ImageSource.FromFile("/Icons/ComplementB256.gif"),
                WidthRequest = HeightRequest = 36,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.FillAndExpand
            });
            */
            ComplementSL.Children.Add(new Label()
            {
                Text = PersonDisplay.PraiseNumber.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            });
            MarkSL.Children.Add(ComplementSL);

            StackLayout ComplainSL = new StackLayout();
            ComplainSL.Orientation = StackOrientation.Horizontal;

            Image ComplainIM = new Image();
            ComplainIM.Source = ImageSource.FromFile("Icons/ComplainB256.gif");
            ComplainIM.Aspect = Aspect.AspectFill;
            ComplainIM.HeightRequest = 36;
            ComplainIM.WidthRequest = 36;
            ComplainIM.HorizontalOptions = LayoutOptions.StartAndExpand;
            ComplainSL.Children.Add(ComplainIM);
            /*
            ComplainSL.Children.Add(new Image()
            {
                Source = ImageSource.FromFile("/Icons/ComplainB256.gif"),
                Aspect = Aspect.AspectFill,
                WidthRequest = HeightRequest = 36,
                //HorizontalOptions = LayoutOptions.EndAndExpand,
                //VerticalOptions = LayoutOptions.Fill
            });
            */
            ComplainSL.Children.Add(new Label()
            {
                Text = PersonDisplay.ComplainNumber.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            });
            MarkSL.Children.Add(ComplainSL);

            ReturnObject.Children.Add(MarkSL);

            StackLayout SetupDateSL = new StackLayout();
            SetupDateSL.Orientation = StackOrientation.Horizontal;
            SetupDateSL.BackgroundColor = Color.White;
            SetupDateSL.Padding = new Thickness(8, 15, 8, 15);
            SetupDateSL.Children.Add(new Label()
            {
                Text = "注册时间：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });
            SetupDateSL.Children.Add(new Label()
            {
                Text = PersonDisplay.SetupDate.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            });

            ReturnObject.Children.Add(SetupDateSL);


            return ReturnObject;

        }
        private StackLayout MarkCompSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout MarkSL = new StackLayout();
            MarkSL.Orientation = StackOrientation.Horizontal;
            MarkSL.BackgroundColor = Color.White;
            MarkSL.Children.Add(new Label()
            {
                Text = "信用评分：",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                TextColor = SettingTheme.ColorGrayClear,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
            });
            MarkSL.Children.Add(new Label()
            {
                Text = PersonDisplay.Mark.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,

            });


            StackLayout CompSL = new StackLayout();
            CompSL.Orientation = StackOrientation.Horizontal;
            StackLayout ComplementSL = new StackLayout();
            ComplementSL.Orientation = StackOrientation.Horizontal;
            ComplementSL.Children.Add(new Image()
            {
                Source = ImageSource.FromFile("/Icons/ComplementB256.gif"),
                WidthRequest = HeightRequest = 36,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.FillAndExpand
            });
            ComplementSL.Children.Add(new Label()
            {
                Text = PersonDisplay.PraiseNumber.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            });
            CompSL.Children.Add(ComplementSL);

            StackLayout ComplainSL = new StackLayout();
            ComplainSL.Orientation = StackOrientation.Horizontal;
            ComplainSL.Children.Add(new Image()
            {
                Source = ImageSource.FromFile("/Icons/ComplainB256.gif"),
                WidthRequest = HeightRequest = 36,
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.FillAndExpand
            });
            ComplainSL.Children.Add(new Label()
            {
                Text = PersonDisplay.ComplainNumber.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
            });
            CompSL.Children.Add(ComplainSL);


            ReturnObject.Children.Add(MarkSL);
            ReturnObject.Children.Add(CompSL);
            return ReturnObject;
        }
    }
    public class SuperBotton : StackLayout
    {
        Theme SettingTheme;
        Image PicAdd;

        public SuperBotton()
        {
            SettingTheme = BlackCat.App.SettingTheme;
        }
        public SuperBotton(int PageID, int StateKey, int Key = 0)
        {
            switch (PageID)
            {
                case 1:
                    ActionListButtonBuilder();
                    break;
                case 2:
                    MessageListButtonBuilder();
                    break;
                case 3:
                    ItemListButtonBuilder();
                    break;
                case 4:
                    ActionPageButtonBuilder();
                    break;
                case 5:
                    AddActivityPageButtonBuilder();
                    break;
                case 0:
                    LoginPageButtonBuilder();
                    break;
            }
        }
        private void ActionListButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(1); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            Image PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonAdd200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void MessageListButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(2); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            Image PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonRefrash200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void ItemListButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(3); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            Image PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonSetting200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void ActionPageButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(4); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            Image PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonFollow200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void AddActivityPageButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(5); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            Image PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonSure200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void LoginPageButtonBuilder()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Command = new Command(() => { ButtonCommandPageChange(0); });

            this.GestureRecognizers.Add(tgr);

            this.BackgroundColor = Color.Black;
            this.VerticalOptions = LayoutOptions.StartAndExpand;
            this.HorizontalOptions = LayoutOptions.StartAndExpand;
            this.BackgroundColor = Color.Transparent;
            this.HeightRequest = 54;
            this.WidthRequest = 54;

            PicAdd = new Image();
            PicAdd.BackgroundColor = Color.Transparent;
            PicAdd.Source = FileImageSource.FromFile("Icons/ButtonNext200.gif");
            PicAdd.Aspect = Aspect.AspectFill;
            PicAdd.HeightRequest = 54;
            PicAdd.WidthRequest = 54;

            this.Children.Add(PicAdd);
        }
        private void ButtonCommandPageChange(int Key = 0)
        {
            switch (Key)
            {
                case 0:
                    if (SetupPage.SetupPages[SetupPage.IndexNow + 1] != null)
                    {
                        //跳下一页
                        if (SetupPage.Check(SetupPage.IndexNow) != 0)
                        {
                            SetupPage.MainBaseSL.Children.Clear();
                            SetupPage.MainBaseSL.Children.Add(SetupPage.ControlBaseSLBulider(0));
                            SetupPage.PageTitle.Text = "注册步骤：" + (SetupPage.IndexNow +2 ) + "/3";
                            SetupPage.MainBaseSL.Children.Add(SetupPage.SetupPages[SetupPage.IndexNow + 1]);
                            int a = (SetupPage.IndexNow++);
                            if (SetupPage.SetupPages[SetupPage.IndexNow + 1] == null && SetupPage.IndexNow < 3)
                            {
                                this.PicAdd.Source = FileImageSource.FromFile("Icons/ButtonSure200.gif");
                            }
                        }
                    }
                    else
                    {
                        if (SetupPage.Check(SetupPage.IndexNow) != 0)
                        {
                            PersonMessage New = new PersonMessage();
                            New.MarkOrganize = SetupPage.MarkReanglePE.SelectedItem.ToString();
                            New.Setup(SetupPage.NameET.Text, SetupPage.DescribeET.Text, SetupPage.PhoneNumberET.Text);

                            New.SetupDate = DateTime.Now;
                            New.LoginDate = DateTime.Now;
                            New.Password = SetupPage.PasswordET.Text;
                            New.Mark = 70;
                            New.HeadImage = new Image()
                            {
                                Source = ImageSource.FromFile("Icons/DafultHeadImg.gif"),
                            };
                            New.PraiseNumber = 0;
                            New.ComplainNumber = 0;
                            New.Available = true;

                            New.TakeMark(SetupPage.MarkNumberET.Text, SetupPage.MarkReanglePE.SelectedItem.ToString(), SetupPage.RealNameET.Text);
                            SetupPage.IndexNow = 0;



                            BlackCat.App.LoginPerson = LoginPage.LoginC(New.PhoneNumber,New.Password);
                            BlackCat.App.DisplayPerson = BlackCat.App.LoginPerson;
                            BlackCat.App.PageInfo = new NavigationPage(new MainPage());
                            BlackCat.App.Current.MainPage = BlackCat.App.PageInfo;
                        }
                        //保存
                    }
                    
                    break;
                case 1:
                    BlackCat.App.PageInfo.PushAsync(new AddActivityPage());
                    break;
                case 2:
                    ActionList.SelectLabel = ActionList.TitleControl[1];
                    ActionList.PageChange();
                    break;
                case 3:

                    break;
                case 4:
                    BlackCat.App.DataCatcherE.FollowListTableC.Alter(BlackCat.App.LoginPerson, BlackCat.App.DisplayActivity);
                    break;
                case 5:
                    if(AddActivityPage.Check()==1)
                    {
                        ActivityMessage New = new ActivityMessage();

                        New.Title = AddActivityPage.TitleET.Text;
                        New.Describe = AddActivityPage.MessageED.Text;
                        New.PeopleNumberLimit = int.Parse(AddActivityPage.PeopleNumberPE.SelectedItem.ToString());
                        New.TagsCount = 0;
                        if (AddActivityPage.Tag1PE.SelectedItem != null)
                            if (!String.IsNullOrEmpty(AddActivityPage.Tag1PE.SelectedItem.ToString()))
                                {
                                    New.Tags[0] = AddActivityPage.Tag1PE.SelectedItem.ToString();
                                    New.TagsCount++;
                                }
                        if(AddActivityPage.Tag2PE.SelectedItem != null)
                            if (!String.IsNullOrEmpty(AddActivityPage.Tag2PE.SelectedItem.ToString()))
                             {
                                    New.Tags[1] = AddActivityPage.Tag2PE.SelectedItem.ToString();
                                    New.TagsCount++;
                             }
                        if (AddActivityPage.Tag3PE.SelectedItem != null)
                            if (!String.IsNullOrEmpty(AddActivityPage.Tag3PE.SelectedItem.ToString()))
                                {
                                    New.Tags[2] = AddActivityPage.Tag3PE.SelectedItem.ToString();
                                    New.TagsCount++;
                                }

                        New.PlanDate = AddActivityPage.ChooseDate;
                        New.StartPlace = AddActivityPage.PlaceET.Text;

                        New.PeopleNumber = 0;
                        New.Creater = BlackCat.App.LoginPerson;

                        New.CreatDate = DateTime.Now;
                        New.ID = New.IDRequest();


                        BlackCat.App.PageInfo.PopAsync(true);
                        ActionList.SelectLabel = ActionList.TitleControl[0];
                        ActionList.PageChange();
                    }
                    //新建活动
                    break;
                default:

                    break;

            }

        }

    }
    public class AddActivityPage : ActionBasePage
    {
        ActivityMessage CreateActivity;

        static public DateTime ChooseDate;
        static public TimeSpan ChooseTime;


        ScrollView MainBaseSV;

        StackLayout MainControlBarSL;
        StackLayout MainAreaSL;

        SuperBotton SuperButtonM;

        public static Entry TitleET =  new Entry();
        public static Entry PlaceET = new Entry();
        public static Editor MessageED = new Editor();

        public static DatePicker DP = new DatePicker();
        public static TimePicker TP = new TimePicker();
        public static Picker PeopleNumberPE = new Picker();

        public static Picker NumberPE = new Picker();
        public static Picker Tag1PE = new Picker();
        public static Picker Tag2PE = new Picker();
        public static Picker Tag3PE = new Picker();

        Theme SettingTheme;

        public AddActivityPage()
        {
            MainBaseSV = new ScrollView();
            MainAreaSL = new StackLayout();

            TitleET = new Entry();
            PlaceET = new Entry();
            MessageED = new Editor();

            DP = new DatePicker();
            TP = new TimePicker();
            PeopleNumberPE = new Picker();

            NumberPE = new Picker();
            Tag1PE = new Picker();
            Tag2PE = new Picker();
            Tag3PE = new Picker();

            SettingTheme = BlackCat.App.SettingTheme;

            SuperButtonM = new SuperBotton(5, 1);


            SuperBottonBV.Children.Add(SuperButtonM);

            MainBaseSL.Children.Add(ControlBarBuilder());

            MainBaseSV.Content = MainAreaSL;

            MainAreaSL.Children.Add(TitleSLBuilder());
            MainAreaSL.Children.Add(MessageSLBuilder());
            MainAreaSL.Children.Add(DateChooseSLBuilder());
            MainAreaSL.Children.Add(PlaceSLBuilder());
            MainAreaSL.Children.Add(PeoPleNumberSLBuilder());
            MainAreaSL.Children.Add(TagsChooseSLBuilder());

            MainBaseSL.Children.Add(MainBaseSV);

            Content = MainBaseAL;

            NavigationPage.SetHasNavigationBar(this, false);
        }
        private StackLayout ControlBarBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.BackgroundColor = SettingTheme.GetMainThemeColor();
            ReturnObject.HeightRequest = 40;
            ReturnObject.Orientation = StackOrientation.Horizontal;

            Button BackButton = new Button();
            BackButton.Image = (FileImageSource)ImageSource.FromFile("Icons/Back40.gif");
            BackButton.BorderWidth = 0;
            BackButton.BackgroundColor = Color.Transparent;

            BackButton.HeightRequest = 40;
            BackButton.WidthRequest = BackButton.HeightRequest;
            BackButton.HorizontalOptions = LayoutOptions.Start;

            ReturnObject.Children.Add(BackButton);

            BackButton.Clicked += BackButton_Clicked;

            Label MainTitleLB = new Label();
            MainTitleLB.Text = "发布活动";
            MainTitleLB.HorizontalOptions = LayoutOptions.CenterAndExpand;
            MainTitleLB.VerticalOptions = LayoutOptions.CenterAndExpand;
            MainTitleLB.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            MainTitleLB.TextColor = SettingTheme.ColorWhiteClear;
            ReturnObject.Children.Add(MainTitleLB);


            Button MoreButton = new Button();
            MoreButton.Image = (FileImageSource)ImageSource.FromFile("Icons/More54.gif");
            MoreButton.BackgroundColor = Color.Transparent;
            MoreButton.BorderWidth = 0;

            MoreButton.HorizontalOptions = LayoutOptions.End;
            ReturnObject.Children.Add(MoreButton);
            /*
             * 
             * 占位：选项按钮事件绑定
             */
            return ReturnObject;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            BlackCat.App.PageInfo.PopAsync();
        }
        private StackLayout TitleSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();


            StackLayout TitleSL = TitleSLbuilder("标题", "亮眼标题会让你的活动更加出众");
            TitleET = EntryBuilder("活动标题，简短有力");

            TitleET.VerticalOptions = LayoutOptions.Center;

            ReturnObject.Children.Add(TitleSL);
            ReturnObject.Children.Add(TitleET);

            return ReturnObject;
        }
        private StackLayout MessageSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();



            StackLayout TitleSL = TitleSLbuilder("描述", "详细介绍你的计划");
            MessageED.HeightRequest = 400;
            MessageED.Text = "活动描述，如活动详细信息";


            ReturnObject.Children.Add(TitleSL);
            ReturnObject.Children.Add(MessageED);

            return ReturnObject;
        }
        private StackLayout DateChooseSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();


            StackLayout TitleSL = TitleSLbuilder("时间", "规划活动的集合时间");
            ReturnObject.Children.Add(TitleSL);
            Button TimePickBT = new Button()
            {
                Text = "选择开始日期和时间",
                TextColor = SettingTheme.GetMainThemeColor()
            };
            TimePickBT.Clicked += DatePickBT_Clicked;

            
            ReturnObject.Children.Add(TimePickBT);

            return ReturnObject;
        }

        private void DatePickBT_Clicked(object sender, EventArgs e)
        {
            /*
            NavigationPage TempPage = new NavigationPage();

            DatePicker PA = new DatePicker();
            
            */
            var TTT = new TimePicker();

            DateTime DateTimeA = (DP).Date;
            TimeSpan DateTimeB = (TP).Time;
            ChooseDate = new DateTime(DateTimeA.Year, DateTimeA.Month, DateTimeA.Day,
            DateTimeB.Hours, DateTimeB.Minutes, DateTimeB.Seconds);
        }

        private StackLayout PlaceSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout TitleSL = TitleSLbuilder("地点", "规划活动的集合地点");
            ReturnObject.Children.Add(TitleSL);

            PlaceET.Placeholder = "集合地点";

            ReturnObject.Children.Add(PlaceET);
            return ReturnObject;
        }
        private StackLayout PeoPleNumberSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout TitleSL = TitleSLbuilder("人数限制", "设置活动的最大参与人数");
            ReturnObject.Children.Add(TitleSL);

            
            PeopleNumberPE.Title = "最大参与人数";
            for (int i = 1; i < 11; i++)
            {
                PeopleNumberPE.Items.Add(i.ToString());
            }
            ReturnObject.Children.Add(PeopleNumberPE);
            return ReturnObject;
        }
        private StackLayout TagsChooseSLBuilder()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout TitleSL = TitleSLbuilder("标签", "让活动更容易被发现");
            ReturnObject.Children.Add(TitleSL);

            StackLayout TagsSL = new StackLayout();
            TagsSL.Orientation = StackOrientation.Horizontal;

            DefaultTags TagSource = new DefaultTags();
            for(int i=0;i<8;i++)
            {
                Tag1PE.Items.Add(TagSource.GetTag(1,i));
                Tag2PE.Items.Add(TagSource.GetTag(1, i));
                Tag3PE.Items.Add(TagSource.GetTag(1, i));
            }
            

            TagsSL.Children.Add(Tag1PE);
            TagsSL.Children.Add(Tag2PE);
            TagsSL.Children.Add(Tag3PE);

            ReturnObject.Children.Add(TagsSL);
            return ReturnObject;
        }
        public static int Check()
        {
            if(!String.IsNullOrWhiteSpace( TitleET .Text))
                if(MessageED.Text != "")
                    if(!String.IsNullOrWhiteSpace(PlaceET.Text))
                        if(PeopleNumberPE.SelectedItem != null)
                            if(Tag1PE.SelectedItem !=null)
                                return 1;
            return 0;
        }
        private StackLayout TitleSLbuilder(string Title, string Describe)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Orientation = StackOrientation.Horizontal;

            Label TitleLB = new Label();
            TitleLB.Text = Title;
            TitleLB.TextColor = SettingTheme.GetMainThemeColor();
            TitleLB.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            TitleLB.HorizontalOptions = LayoutOptions.Start;
            TitleLB.VerticalTextAlignment = TextAlignment.Start;

            Label DecribeLB = new Label();
            DecribeLB.Text = Describe;
            DecribeLB.TextColor = SettingTheme.ColorLightGrayClear;
            DecribeLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            DecribeLB.HorizontalOptions = LayoutOptions.StartAndExpand;
            DecribeLB.VerticalTextAlignment = TextAlignment.End;

            ReturnObject.Children.Add(TitleLB);
            ReturnObject.Children.Add(DecribeLB);

            return ReturnObject;
        }
        private Entry EntryBuilder(string PlaceHolder, bool IsPassword = false)
        {
            Entry ReturnObject = new Entry();

            ReturnObject.Placeholder = PlaceHolder;
            ReturnObject.TextColor = SettingTheme.GetMainThemeColor();
            ReturnObject.IsPassword = IsPassword;

            return ReturnObject;
        }

    }
    public class LSPage : ContentPage
    {

    }
    public class SpecialMessageShowPage
    {

    }
    public class ActivityUnitsBoard : StackLayout
    {

        //StackLayout UnitsStackLayout;


        int ActivityNumberLimit = 15;
        StackLayout[] ActivityUnitsSL;
        int IndexCount = 0;
        int NewstAcitivityID = 0;

        Theme SettingTheme;

        public ActivityUnitsBoard()
        {
            ActivityUnitsSL = new StackLayout[ActivityNumberLimit];
            SettingTheme = BlackCat.App.SettingTheme;
            //UnitsStackLayout = new StackLayout();

            //this.BackgroundColor = SettingTheme.ColorGrayClear;
            this.Spacing = 3;

            //UnitsStackLayout.BackgroundColor = SettingTheme.ColorGrayClear;
            //UnitsStackLayout.Spacing = 3;

            /*
            for (int i = 0; i < ActivityNumberLimit; i++)
            {
                ActivityUnitsSL[i] = new StackLayout();
            }
            */
        }
        public ActivityUnitsBoard(int LoginPersonMessageID, int Key = 0) : this()
        {
            if (Key == -1)
                NewstAcitivityID = 10;
            else
            {
                BlackCat.App.DataCatcherE.SetCatchType(5);
                NewstAcitivityID = (int)(BlackCat.App.DataCatcherE.Catch(0));
            }
            if (BlackCat.App.LoginPerson != null)
            {
                ActivityUnitsSLBuilder(IndexCount, Key);
            }
            //for(int i=0;i<ActivityNumberLimit;i++)
            //this.Children.Add(ActivityUnitsSL[i]);
            //this.Children.Clear();


        }
        public int ActivityUnitsSLBuilder(int Index, int Key = 0)
        {

            BlackCat.App.DataCatcherE.SetCatchType(1);
            IEnumerable<SQLActivityUnit> SourceData = BlackCat.App.DataCatcherE.ActivityTableC.SQLConnection.Query<SQLActivityUnit>("SELECT * FROM SQLActivityUnit");

            int i = 0;

            foreach(SQLActivityUnit e in SourceData)
            {
                ActivityMessage et = new ActivityMessage(e);
                ActivityUnitsSL[i] = new StackLayout
                {
                    GestureRecognizers = {
                new TapGestureRecognizer {
                        Command = new Command (()=> BlackCat.App.PageInfo.PushAsync(new ActionPage((int)et.ID,Key),true)),
                },
                }
                };

                ActivityUnitsSL[i].Children.Add(ActivityUnitsSLTitleSLBuiler(et));
                ActivityUnitsSL[i].Children.Add(ActivityUnitsSLMainTextSLBuilder(et));
                ActivityUnitsSL[i].BackgroundColor = SettingTheme.ColorWhiteClear;
                ActivityUnitsSL[i].Spacing = 0;
                ActivityUnitsSL[i].Padding = new Thickness(8, 0, 8, 0);
                this.Children.Add(ActivityUnitsSL[i]);

                i++;
            }
            /*
            for (int i = 0; i < ActivityNumberLimit; i++)
            {
                ActivityMessage Temp;
                BlackCat.App.DataCatcherE.SetCatchType(1);
                if (Key == -1)
                    Temp = (ActivityMessage)BlackCat.App.DataCatcherE.Catch(Key);
                else
                    Temp = (ActivityMessage)BlackCat.App.DataCatcherE.Catch(
                        NewstAcitivityID - Index * ActivityNumberLimit);

                ActivityUnitsSL[i] = new StackLayout
                {
                    GestureRecognizers = {
                new TapGestureRecognizer {
                        Command = new Command (()=> BlackCat.App.PageInfo.PushAsync(new ActionPage((int)Temp.ID,Key),true)),
                },
                }
                };

                ActivityUnitsSL[i].Children.Add(ActivityUnitsSLTitleSLBuiler(Temp));
                ActivityUnitsSL[i].Children.Add(ActivityUnitsSLMainTextSLBuilder(Temp));
                ActivityUnitsSL[i].BackgroundColor = SettingTheme.ColorWhiteClear;
                ActivityUnitsSL[i].Spacing = 0;
                ActivityUnitsSL[i].Padding = new Thickness(8, 0, 8, 0);
                this.Children.Add(ActivityUnitsSL[i]);
            }
            */
            return 1;
        }
        private StackLayout ActivityUnitsSLTitleSLBuiler(ActivityMessage Temp)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Orientation = StackOrientation.Horizontal;

            StackLayout LeftNewSL = new StackLayout();

            //LeftNewSL.Orientation = StackOrientation.Horizontal;

            LeftNewSL.Spacing = 0;

            StackLayout TitleAndDa = new StackLayout();
            TitleAndDa.Orientation = StackOrientation.Horizontal;

            Label TitleLB = new Label()
            {
                Text = Temp.Title,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = SettingTheme.GetMainThemeColor()

            };
            TitleLB.HorizontalOptions = LayoutOptions.StartAndExpand;
            TitleLB.VerticalTextAlignment = TextAlignment.Center;
            TitleAndDa.Children.Add(TitleLB);

            Label Da = new Label()
            {
                Text = Temp.PlanDate.ToString("MM") + "月",
                TextColor = SettingTheme.GetMainThemeColor(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };
            Da.HorizontalOptions = LayoutOptions.EndAndExpand;
            TitleAndDa.Children.Add(Da);



            LeftNewSL.Children.Add(TitleAndDa);
            //LeftNewSL.Children.Add(CrossLineBuiler());


            LeftNewSL.HorizontalOptions = LayoutOptions.FillAndExpand;
            ReturnObject.Children.Add(LeftNewSL);
            ReturnObject.Children.Add(new Label()
            {
                Text = Temp.PlanDate.ToString("dd"),
                TextColor = SettingTheme.GetMainThemeColor(),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.End

            });
            return ReturnObject;
        }
        private StackLayout ActivityUnitsSLMainTextSLBuilder(ActivityMessage Temp)
        {
            StackLayout ReturnObject = new StackLayout();

            Label MainTextLB = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };

            if (Temp.Describe.Length <= 90)
                MainTextLB.Text = Temp.Describe;
            else
                MainTextLB.Text = Temp.Describe.Substring(0, 90);

            Label TagsLB = new Label()
            {
                Text = "标签：",
                TextColor = SettingTheme.GetMainThemeColor(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };
            for (int i = 0; i < Temp.TagsCount; i++)
            {
                TagsLB.Text += Temp.Tags[i] + " ";
            }
            Label PeopleNumberLB = new Label()
            {
                Text = "当前人数：" + Temp.PeopleNumber + "/" + Temp.PeopleNumberLimit,
                TextColor = SettingTheme.GetMainThemeColor(),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };
            ReturnObject.Children.Add(MainTextLB);
            ReturnObject.Children.Add(TagsLB);
            ReturnObject.Children.Add(PeopleNumberLB);
            return ReturnObject;
        }
        private Label CrossLineBuiler()
        {
            Label Line = new Label();

            Line.Text = "--------------------------------------------------";
            Line.TextColor = SettingTheme.GetMainThemeColor();

            return Line;
        }

        private int NextPage(int Index)
        {
            IndexCount = (Index++);

            ActivityUnitsSLBuilder(IndexCount);

            this.Children.Clear();

            for (int i = 0; i < ActivityNumberLimit; i++)
            {
                this.Children.Add(ActivityUnitsSL[i]);
            }
            ContentPage A = new ContentPage();

            return 1;
        }
    }
    public class TitleControlBar : StackLayout
    {

    }
    public class LoginPage:ContentPage
    {
        PersonMessage ExamPerson;
        string PhoneNumber;
        string PassWord;
        StackLayout MainBassSL;
        public static Entry PhoneNumberET = new Entry();
        public static Entry PasswordET = new Entry();
        public static Label MessageShowLB = new Label();

        public LoginPage()
        {
            ExamPerson = new PersonMessage();
        }
        public LoginPage(string PhoneNumber,string Password):this()
        {
            MainBassSL = new StackLayout();
            MainBassSL.Padding = new Thickness(100, 100, 100, 100);
            MainBassSL.HorizontalOptions = LayoutOptions.Center;
            MainBassSL.VerticalOptions = LayoutOptions.Center;
            MainBassSL.WidthRequest = 600;
            //MainBassSL.HeightRequest = 500;

            StackLayout LogoShowSL = new StackLayout();
            LogoShowSL.BackgroundColor = Color.Transparent;

            Image LogoImg = new Image();
            LogoImg.Source = ImageSource.FromFile("Icons/LogoA.png");
            LogoImg.WidthRequest = 600;

            LogoShowSL.Children.Add(LogoImg);

            StackLayout InputPanelSL = new StackLayout();
            InputPanelSL.BackgroundColor = Color.FromRgba(1, 1, 1, 0.8);
            InputPanelSL.Padding = new Thickness(30, 25, 30, 25);

            //PhoneNumberET.InputTransparent = true;
            PhoneNumberET.Placeholder = "输入手机号码";
            PhoneNumberET.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button));

            InputPanelSL.Children.Add(PhoneNumberET);

            
            PasswordET.IsPassword = true;
            PasswordET.Placeholder = "密码";
            PasswordET.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button));

            InputPanelSL.Children.Add(PasswordET);

            StackLayout ButtonSL = new StackLayout();
            //ButtonSL.Orientation = StackOrientation.Horizontal;

            Button SetupButton = new Button();
            SetupButton.BackgroundColor = Color.Transparent;
            SetupButton.TextColor = BlackCat.App.SettingTheme.GetMainThemeColor();
            SetupButton.Text = "注册";
            SetupButton.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Button LoginButton = new Button();
            LoginButton.BackgroundColor = BlackCat.App.SettingTheme.GetMainThemeColor();
            LoginButton.TextColor = BlackCat.App.SettingTheme.ColorWhiteClear;
            LoginButton.FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Button));           
            LoginButton.Text = "登  录";
            LoginButton.HorizontalOptions = LayoutOptions.FillAndExpand;

            var tgr1 = new TapGestureRecognizer();
            tgr1.Command = new Command(() => {
                Login();
                }
            );
            var tgr2 = new TapGestureRecognizer();
            tgr2.Command = new Command(() => {
                Setup();
            }
            );
            LoginButton.GestureRecognizers.Add(tgr1);
            SetupButton.GestureRecognizers.Add(tgr2);

            MessageShowLB.TextColor = Color.Red;
            
            ButtonSL.Children.Add(LoginButton);
            ButtonSL.Children.Add(SetupButton);
            ButtonSL.Children.Add(MessageShowLB);

            InputPanelSL.Children.Add(ButtonSL);

            MainBassSL.Children.Add(LogoShowSL);
            MainBassSL.Children.Add(InputPanelSL);

            NavigationPage.SetHasNavigationBar(this, false);
            this.BackgroundImage = "BackG-B.png";
            Content = MainBassSL;
            //this.BackgroundColor = BlackCat.App.SettingTheme.GetMainThemeColor();
            this.BackgroundColor = BlackCat.App.SettingTheme.ColorWhiteClear;
            
        }
        public static PersonMessage LoginC(string PhoneNumber,string Password)
        {
            PersonMessage ReturnObject = null;

            BlackCat.App.DataCatcherE.SetCatchType(2);
            IEnumerable<SQLPersonUnit> e =
            BlackCat.App.DataCatcherE.PersonTableC.SQLConnection
                .Query<SQLPersonUnit>("SELECT * FROM SQLPersonUnit WHERE PhoneNumber ='" + PhoneNumber + "' AND Password ='" + Password + "'");
            if (e != null)
            {
                foreach (SQLPersonUnit p in e)
                {
                    ReturnObject = new PersonMessage(p);
                    return ReturnObject;
                }
            }

            return ReturnObject;
        }
        public static void Login()
        {
            PersonMessage New = LoginC(PhoneNumberET.Text, PasswordET.Text);
            if (New != null)
            {
                BlackCat.App.LoginPerson = New;
                BlackCat.App.DisplayPerson = BlackCat.App.LoginPerson;
                BlackCat.App.PageInfo = new NavigationPage(new MainPage());
                BlackCat.App.Current.MainPage = BlackCat.App.PageInfo;
            }
            else
            {
                MessageShowLB.Text = "登陆失败！请检查您的手机号 和 密码！如果你尚未注册，请点击注册。";
            }
        }
        public void Setup()
        {
            BlackCat.App.PageInfo.PushAsync(new SetupPage(),true);
        }
    }
    public class SetupPage : ActionBasePage
    {
        public static StackLayout[] SetupPages = new StackLayout[5];
        public static Label PageTitle = new Label();
        public static int IndexNow = 0;
        public static StackLayout MainBottomSL = new StackLayout();

        Label PhoneNumberMessageLB = new Label();
        Label PasswordMessageLB = new Label();

        public static Entry PhoneNumberET = new Entry();
        public static Entry PasswordET = new Entry();
        public static Entry ReCheckPasswordET = new Entry();
        public static Entry NameET = new Entry();
        public static Entry DescribeET = new Entry();
        public static Entry MarkNumberET = new Entry();
        public static Entry RealNameET = new Entry();

        public static Picker MarkReanglePE = new Picker();

        Theme SettingTheme = BlackCat.App.SettingTheme;

        public SetupPage()
        {

            SuperBottonBV.Children.Add(new SuperBotton(0, 0));

            for (int i = 0; i < 5; i++)
            {
                SetupPages[i] = null;
            }
            SetupPages[0] = StandardPage();
            SetupPages[1] = new StackLayout();
            SetupPages[1].Children.Add(MessagePage());
            SetupPages[1].Children.Add(MarkPage());
            SetupPages[2] = MessageShowPage();

            
            MainBaseSL.Children.Add(ControlBaseSLBulider(0));
            PageTitle.Text = "注册步骤：" + (SetupPage.IndexNow+1) + "/3";
            MainBaseSL.Children.Add(SetupPages[0]);

            NavigationPage.SetHasNavigationBar(this, false);

            Content = MainBaseAL;
        }
        public SetupPage(PersonMessage Input, int Key = 0) : this()
        {
            for (int i = 0; i < 5; i++)
            {
                SetupPages[i] = null;
            }
            SetupPages[0] = EditPage();
        }
        private StackLayout StandardPage()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout PhoneSL = new StackLayout();

            StackLayout PhoneTitleSL = TitleSLbuilder("手机号码", "将作为登陆的唯一凭据");

            PhoneNumberET = EntryBuilder("输入号码");

            PhoneNumberMessageLB.TextColor = Color.Red;

            PhoneSL.Children.Add(PhoneTitleSL);
            PhoneSL.Children.Add(PhoneNumberET);
            PhoneSL.Children.Add(PhoneNumberMessageLB);

            ReturnObject.Children.Add(PhoneSL);

            StackLayout PasswordSL = new StackLayout();

            StackLayout PasswordTitleSL = TitleSLbuilder("密码", "请务必记牢！");

            PasswordET = EntryBuilder("输入密码", true);

            ReCheckPasswordET = EntryBuilder("再次输入", true);

            PasswordMessageLB.TextColor = Color.Red;

            PasswordSL.Children.Add(PasswordTitleSL);
            PasswordSL.Children.Add(PasswordET);
            PasswordSL.Children.Add(ReCheckPasswordET);
            PasswordSL.Children.Add(PasswordMessageLB);

            ReturnObject.Children.Add(PasswordSL);

            return ReturnObject;
        }
        private StackLayout MessagePage()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout NameSL = new StackLayout();

            StackLayout NameTitleSL = TitleSLbuilder("昵称", "用于个人ID显示");

            NameET = EntryBuilder("输入昵称");

            NameSL.Children.Add(NameTitleSL);
            NameSL.Children.Add(NameET);

            ReturnObject.Children.Add(NameSL);

            StackLayout DescribeSL = new StackLayout();

            StackLayout DescribeTitleSL = TitleSLbuilder("签名", "简单描述下你自己");

            DescribeET = EntryBuilder("输入内容");

            DescribeSL.Children.Add(DescribeTitleSL);
            DescribeSL.Children.Add(DescribeET);

            ReturnObject.Children.Add(DescribeSL);

            return ReturnObject;
        }
        private StackLayout MarkPage()
        {
            StackLayout ReturnObject = new StackLayout();

            StackLayout MarkOranglePESL =new  StackLayout();

            StackLayout MarkOrangleTitleSL = TitleSLbuilder("实名认证单位","选择用于实名认证的单位");

            MarkReanglePE.Items.Add("湖南人文科技学院");
            MarkReanglePE.TextColor = SettingTheme.GetMainThemeColor();

            MarkOranglePESL.Children.Add(MarkOrangleTitleSL);
            MarkOranglePESL.Children.Add(MarkReanglePE);

            ReturnObject.Children.Add(MarkOranglePESL);

            StackLayout MarkSL = new StackLayout();

            StackLayout MarkTitleSL = TitleSLbuilder("实名认证", "务必填写与上方所选单位匹配的信息！");

            MarkNumberET = EntryBuilder("个人编号，如学校的学号、单位的工号等");

            RealNameET = EntryBuilder("个人真实信息，所属单位细分 + 真实姓名");

            MarkSL.Children.Add(MarkTitleSL);
            MarkSL.Children.Add(MarkNumberET);
            MarkSL.Children.Add(RealNameET);

            ReturnObject.Children.Add(MarkSL);
            return ReturnObject;
        }
        private StackLayout MessageShowPage()
        {
            StackLayout ReturnObject = new StackLayout();

            Label label1 = new Label();
            label1.Text = "注册成功！";
            label1.TextColor = SettingTheme.GetMainThemeColor();
            label1.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            label1.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Label lab2 = new Label();
            lab2.Text = "这是你的初始信用分数：";
            lab2.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Label labM = new Label();
            labM.Text = "70.0";
            labM.TextColor = SettingTheme.GetMainThemeColor();
            labM.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            labM.HorizontalOptions = LayoutOptions.CenterAndExpand;


            Label lab3 = new Label();
            lab3.Text = "请注意：信用分数是对你在平台里进行的信用行为的描述，当你准时守信地完成了活动时，这个分会有所上涨，但是当你放别人鸽子时，这个分数会迅速下降!"+
                 Environment.NewLine + "当然分数很高的用户，往往代表其守信行为良好，是值得信赖的，但是相对来说，分数低的用户可能代表其有些问题，会影响其个人评价与参与某些活动的权限."
                + Environment.NewLine + "（活动发起者有权拒绝低分数用户参与活动!）";

            Label lab4 = new Label();
            lab4.Text = "不宝金玉，而忠信以为宝  ——《礼记》";
            lab4.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            lab4.TextColor = SettingTheme.GetMainThemeColor();
            lab4.HorizontalOptions = LayoutOptions.CenterAndExpand;


            ReturnObject.Children.Add(label1);
            ReturnObject.Children.Add(lab2);
            ReturnObject.Children.Add(labM);
            ReturnObject.Children.Add(lab3);
            ReturnObject.Children.Add(lab4);
            return ReturnObject;
        }
        private StackLayout EditPage()
        {
            StackLayout ReturnObject = null;



            return ReturnObject;
        }
        public static StackLayout ControlBaseSLBulider(int index)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.BackgroundColor = BlackCat.App.SettingTheme.GetMainThemeColor();
            ReturnObject.HeightRequest = 40;
            ReturnObject.Orientation = StackOrientation.Horizontal;

            Button BackButton = new Button();
            BackButton.Image = (FileImageSource)ImageSource.FromFile("Icons/Back40.gif");
            BackButton.BorderWidth = 0;
            BackButton.BackgroundColor = Color.Transparent;

            BackButton.HeightRequest = 40;
            BackButton.WidthRequest = BackButton.HeightRequest;
            BackButton.HorizontalOptions = LayoutOptions.Start;

            ReturnObject.Children.Add(BackButton);

            BackButton.Clicked += Back;
            PageTitle.HorizontalOptions = LayoutOptions.CenterAndExpand;
            PageTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
            PageTitle.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));

            PageTitle.TextColor = BlackCat.App.SettingTheme.ColorWhiteClear;
            ReturnObject.Children.Add(PageTitle);


            Button MoreButton = new Button();
            MoreButton.Image = (FileImageSource)ImageSource.FromFile("Icons/More54.gif");
            MoreButton.BackgroundColor = Color.Transparent;
            MoreButton.BorderWidth = 0;

            MoreButton.HorizontalOptions = LayoutOptions.End;
            ReturnObject.Children.Add(MoreButton);
            /*
             * 
             * 占位：选项按钮事件绑定
             */
            return ReturnObject;
        }
        private StackLayout TitleSLbuilder(string Title, string Describe)
        {
            StackLayout ReturnObject = new StackLayout();

            ReturnObject.Orientation = StackOrientation.Horizontal;

            Label TitleLB = new Label();
            TitleLB.Text = Title;
            TitleLB.TextColor = SettingTheme.GetMainThemeColor();
            TitleLB.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            TitleLB.HorizontalOptions = LayoutOptions.Start;
            TitleLB.VerticalTextAlignment = TextAlignment.Start;

            Label DecribeLB = new Label();
            DecribeLB.Text = Describe;
            DecribeLB.TextColor = SettingTheme.ColorLightGrayClear;
            DecribeLB.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            DecribeLB.HorizontalOptions = LayoutOptions.StartAndExpand;
            DecribeLB.VerticalTextAlignment = TextAlignment.End;

            ReturnObject.Children.Add(TitleLB);
            ReturnObject.Children.Add(DecribeLB);

            return ReturnObject;
        }
        private Entry EntryBuilder(string PlaceHolder, bool IsPassword = false)
        {
            Entry ReturnObject = new Entry();

            ReturnObject.Placeholder = PlaceHolder;
            ReturnObject.TextColor = SettingTheme.GetMainThemeColor();
            ReturnObject.IsPassword = IsPassword;

            return ReturnObject;
        }
        public static void Back(object sender, EventArgs e)
        {
            IndexNow = 0;
            BlackCat.App.PageInfo.PopAsync(true);
        }
        public static int Check(int Index)
        {
            switch(Index)
            {
                case 0:
                    if(PasswordET.Text == ReCheckPasswordET.Text && !String.IsNullOrEmpty(PasswordET.Text))
                    {
                        return 1;
                    }
                    return 0;
                case 1:
                    if(!String.IsNullOrEmpty(NameET.Text) && !String.IsNullOrEmpty(DescribeET.Text) &&
                        !String.IsNullOrEmpty(RealNameET.Text) && !String.IsNullOrEmpty(MarkNumberET.Text) &&
                        !String.IsNullOrEmpty(MarkReanglePE.SelectedItem.ToString()))
                    {
                        return 1;
                    }
                    return 0;
                case 2:
                    return 1;
                default:
                    break;
            }
            return 0;
        }
    }
    //2. 控制类
    public class DataCatcher
    {
        int CatcherID;

        string[] DefaultCatchType = { "Activity", "Person", "Tag", "Guestbook", "NewestActivityID", "Message" };
        public int CatchType;
        bool Available;

        public SQLPersonTableControl PersonTableC;
        public SQLActivityTableControl ActivityTableC;
        public SQLGuestbookTableControl GuestbookTableC;
        public SQLActivityFollowTableControl FollowListTableC;

        public IEnumerable<SQLPersonUnit> PersonTable;
        public IEnumerable<SQLActivityUnit> ActivityTable;
        public IEnumerable<SQLGuestbookUnit> GuestbookTable;
        public IEnumerable<SQLFollowListUnit> FollowListTable;

        static PersonMessage CCat;
        static ActivityMessage DemoActivity;

        Object CatchKey;
        Object ReturnThing;

        public DataCatcher()
        {
            Available = true;

            PersonTableC = new SQLPersonTableControl();
            ActivityTableC = new SQLActivityTableControl();
            GuestbookTableC = new SQLGuestbookTableControl();
            FollowListTableC = new SQLActivityFollowTableControl();

                PersonTable = PersonTableC.GetTable();
                ActivityTable = ActivityTableC.GetTable();
                GuestbookTable = GuestbookTableC.GetTable();
                FollowListTable = FollowListTableC.GetTable();
            
        }
        public DataCatcher(int CatchType):this()
        {
            this.CatchType = CatchType;
        }
        public object Catch(int CatchKey = 0)
        {
            if (CatchKey == -1)
                if ((int)CatchType == 1)
                {
                    DemoActivity = BlackCat.App.DemoActivity;
                    return DemoActivity;
                }
                else if ((int)CatchType == 2)
                {
                    CCat = BlackCat.App.CCat;
                    return CCat;
                }
                else if ((int)CatchType == 6)
                {
                    ActivityMessage TempMessageDemo = BlackCat.App.DemoActivity;
                    return TempMessageDemo;
                }
            
             switch(CatchType)
                    {
                        case 2:
                            SQLPersonUnit ReturnObjectP = PersonTableC.GetUnit(CatchKey);
                            return ReturnObjectP;
                        case 1:
                            SQLActivityUnit ReturnObjectA = ActivityTableC.GetUnit(CatchKey);
                            return ReturnObjectA;
                        case 3:
                            return GetTag(CatchKey);
                        case 4:
                            return GuestbookTableC.SQLConnection.Query<SQLGuestbookUnit>("SELECT * FROM SQLGuestbookUnit WHERE FollowActivityID ="+ CatchKey);
                        case 5:
                            return ActivityTableC.GetUnit(ActivityTableC.SQLConnection.GetTableInfo("SQLActivityUnit").Count).ID;
                        case 6:
                            return SreachMessage(CatchKey);
                    }
            
            /*
             * 占位：根据CatchType 和 CatchKey 查询对象 （服务器 & 本地），并对ReturnThing进行赋值；
             */



            return ReturnThing;
        }
        private int IDRequest(int Key = 0)
        {
            int ReturnID = -1;

            /*
             * 占位：本地分配捕捉器ID
             */

            return ReturnID;
        }
        public int SetCatchType(int CatchType)
        {
            this.CatchType = CatchType;
            return 1;
        }
        private IEnumerable<SQLActivityUnit> SreachMessage(int PersonID)
        {
            SQLiteCommand Command = FollowListTableC.SQLConnection.CreateCommand("SELECT * FROM SQLFollowListUnit WHERE FollowerID =" + PersonID);
            SQLiteCommand Command1 = ActivityTableC.SQLConnection.CreateCommand("SELECT * FROM SQLActivityUnit WHERE CreaterID =" + PersonID);

            IEnumerable<SQLActivityUnit> ReturnObject = ActivityTableC.SQLConnection.Query<SQLActivityUnit>(Command1.CommandText);
            IEnumerable<SQLFollowListUnit> Temp = FollowListTableC.SQLConnection.Query<SQLFollowListUnit>(Command.CommandText);

            List<SQLActivityUnit> ReturnObjectList = ReturnObject.ToList<SQLActivityUnit>();
            foreach(SQLFollowListUnit e in Temp)
            {
                ReturnObjectList.Add(ActivityTableC.GetUnit(e.ActivityID));
            }
            ReturnObject = ReturnObjectList.AsEnumerable();

            return ReturnObject;
        }
        private string GetTag(int Key)
        {
            switch(Key)
            {
                case 1:
                    return "";
                case 2:
                    return "";
                case 3:
                    return "";
                case 4:
                    return "";
                case 5:
                    return "";
                case 6:
                    return "";
                case 7:
                    return "";
                case 8:
                    return "";
                default:
                    return "";

            }
        }
        
    }
    public class ListSLAdapter
    {
        ActivityUnitsBoard ReturnObjectAL;
        MessageList ReturnObjectML;
        ItemList ReturnObjectIL;

        public ListSLAdapter()
        {
            ReturnObjectAL = new ActivityUnitsBoard();
            ReturnObjectML = new MessageList();
            ReturnObjectIL = new ItemList();
        }
        public ListSLAdapter(int Key = 0) : this()
        {
            ReturnObjectAL = new ActivityUnitsBoard(1, -1);
            ReturnObjectML = new MessageList(1, 0);//参数
            ReturnObjectIL = new ItemList(1, -1);//参数
        }
        public Object AdapterGet(int Index, int Key = 0)
        {
            if (Index == 0)
                return ReturnObjectAL;
            if (Index == 1)
                return ReturnObjectML;
            if (Index == 2)
                return ReturnObjectIL;
            else
                return null;
        }
    }
    public interface ISQLite
    {
        SQLite.Net.SQLiteConnection GetConnection();
        
    }
    //2.1.数据库操纵类
    public class SQLBaseControl
    {
        public SQLite.Net.SQLiteConnection SQLConnection;

        public SQLBaseControl()
        {
            
                SQLConnection = DependencyService.Get<ISQLite>().GetConnection();
            
            
        }
        public SQLBaseControl(string Connection)
        {
            //SQLConnection = DependencyService.Get<ISQLite>().GetConnection(Connection);
        }
        public int Insert()
        {

            return 1;
        }
        public int Delete(int id)
        {
            return 1;
        }
        public int Alter(PersonMessage New)
        {
            return 1;
        }
    }
    public class SQLPersonTableControl:SQLBaseControl
    {
        public SQLPersonTableControl()
        {
            SQLConnection.CreateTable<SQLPersonUnit>();
        }
        public IEnumerable<SQLPersonUnit> GetTable()
        {
            return (from t in SQLConnection.Table<SQLPersonUnit>() select t).ToList();
        }
        public SQLPersonUnit GetUnit(int id)
        {
            return SQLConnection.Table<SQLPersonUnit>().FirstOrDefault(t => t.ID == id);
        }
        public new int Delete(int id)
        {
            SQLConnection.Delete<SQLPersonUnit>(id);
            return 1;
        }
        public new int Alter(PersonMessage New)
        {
            var NewThing = new SQLPersonUnit
            {
                Name = New.Name,
                PhoneNumber = New.PhoneNumber,
                Available = (New.Available == true ? 1 : 0),
                SetupDateSourceData = New.SetupDate.ToString("yyyy-MM-dd hh:mm:ss dddd"),
                LoginDateSourceData = New.LoginDate.ToString("yyyy-MM-dd hh:mm:ss dddd"),
                Marked = New.Marked == true ? 1 : 0,
                RealName = New.RealName,
                MarkNumber = New.MarkNumber,
                MarkOrganize = New.MarkOrganize,
                Mark = New.Mark,
                PraiseNumber = New.PraiseNumber,
                ComplainNumber = New.ComplainNumber,
                Password = New.Password,
                Describe = New.Describe,
            };

            SQLConnection.Insert(NewThing);
            return 1;
        }
        

    }
    public class SQLActivityTableControl:SQLBaseControl
    {
        public SQLActivityTableControl()
        {
            SQLConnection.CreateTable<SQLActivityUnit>();
        }
        public IEnumerable<SQLActivityUnit> GetTable()
        {
            return (from t in SQLConnection.Table<SQLActivityUnit>() select t).ToList();
        }
        public SQLActivityUnit GetUnit(int id)
        {
            return SQLConnection.Table<SQLActivityUnit>().FirstOrDefault(t => t.ID == id);
        }
        public new int Delete(int id)
        {
            SQLConnection.Delete<SQLActivityUnit>(id);
            return 1;
        }
        public new int Alter(ActivityMessage New)
        {
            var NewThing = new SQLActivityUnit
            {
                Title = New.Title,
                Describe = New.Describe,
                Place = New.Place,
                StartPlace = New.StartPlace,
                PeopleNumberLimit = New.PeopleNumberLimit,
                Tag1 = New.Tags[0],
                Tag2 = New.Tags[1],
                Tag3 = New.Tags[2],

                Availabe = New.Availabe == true ? 1 : 0,
                HasMessage = New.HasMessage == true ? 1 : 0,
                CreaterID = New.Creater.ID,
                CreatDate = New.CreatDate.ToString("yyyy-MM-dd hh:mm:ss dddd"),
                PlanDate = New.PlanDate.ToString("yyyy-MM-dd hh:mm:ss dddd"),
                FollowerNumber = New.PeopleNumber,
            };

            SQLConnection.Insert(NewThing);
            return 1;
        }
    }
    public class SQLGuestbookTableControl:SQLBaseControl
    {
        public SQLGuestbookTableControl()
        {
            SQLConnection.CreateTable<SQLGuestbookUnit>();
        }
        public IEnumerable<SQLGuestbookUnit> GetTable()
        {
            return (from t in SQLConnection.Table<SQLGuestbookUnit>() select t).ToList();
        }
        public SQLGuestbookUnit GetUnit(int id)
        {
            return SQLConnection.Table<SQLGuestbookUnit>().FirstOrDefault(t => t.ID == id);
        }
        public new int Delete(int id)
        {
            SQLConnection.Delete<SQLGuestbookUnit>(id);
            return 1;
        }
        public new int Alter(GuestbookMessage New)
        {
            var NewThing = new SQLGuestbookUnit
            {
                FollowActivityID = (int)New.FollowToActivityID,
                FollowGuestbookID = (int)New.FollowToMessageID,
                CreaterID = New.CreaterID,
                Describe = New.Message,
                CreateSourceDate = New.CreaterID.ToString("yyyy-MM-dd hh:mm:ss dddd"),
            };

            SQLConnection.Insert(NewThing);
            return 1;
        }
    }   
    public class SQLActivityFollowTableControl:SQLBaseControl
    {
        public SQLActivityFollowTableControl()
        {
            SQLConnection.CreateTable<SQLFollowListUnit>();
        }
        public IEnumerable<SQLFollowListUnit> GetTable()
        {
            return (from t in SQLConnection.Table<SQLFollowListUnit>() select t).ToList();
        }
        public SQLFollowListUnit GetUnit(int id)
        {
            return SQLConnection.Table<SQLFollowListUnit>().FirstOrDefault(t => t.ID == id);
        }
        public new int Delete(int id)
        {
            SQLConnection.Delete<SQLFollowListUnit>(id);
            return 1;
        }
        public new int Alter(PersonMessage NewP,ActivityMessage NewA)
        {
            var NewThing = new SQLFollowListUnit
            {
                ActivityID = (int)NewA.ID,
                FollowerID = NewP.ID,
                CreateSourceDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss dddd"),
            };

            SQLConnection.Insert(NewThing);
            return 1;
        }
    }
    /*
    public class DatabaseControl : IDbDataFetcher
    {
        public List<string> GetData(string conn)
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {

                SqlCommand command = new SqlCommand("select * from smuser", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
            return data;
        }

    }
    */
    //3. 基础数据类
    public class Theme
    {
        public static Color MainThemeColor = Color.FromRgb(235, 97, 0);
        public Color ColorGrayClear = Color.FromRgba(128, 128, 128, 255);
        public Color ColorWhiteClear = Color.FromRgba(252, 252, 252, 255);
        public Color ColorLightGrayClear = Color.FromRgba(196, 196, 196, 255);

        public int SetMainThemColor(Color New)
        {
            MainThemeColor = New;
            return 1;
        }
        public Color GetMainThemeColor()
        {
            return MainThemeColor;
        }
    }
    public class DefaultTags
    {
        string[] ActivityTags = { "户外活动", "室内活动", "工作", "游玩", "聚会", "展览", "会议", "学习" };
        string[] MarkTags = { "", "", "", "", "", "", "", "", "" };

        public string GetTag(int Key, int Index)
        {
            string ReString = "";
            switch (Key)
            {
                case 1:
                    ReString = ActivityTags[Index];
                    break;
                case 2:
                    ReString = MarkTags[Index];
                    break;
            }

            return ReString;

        }
    }
    public class PersonMessage
    {
        public int ID { get; set; }
        public bool Available { get; set; }
        public bool Marked { get; set; }

        public string Name { get; set; }
        public string RealName { get; set; }
        public string Describe { get; set; }


        public short Mark { get; set; }
        public int PraiseNumber { get; set; }
        public int ComplainNumber { get; set; }

        public string PhoneNumber { get; set; }
        public string MarkNumber { get; set; }
        public string MarkOrganize { get; set; }

        public DateTime SetupDate { get; set; }
        public DateTime LoginDate { get; set; }

        public Image HeadImage { get; set; }
        public string Password { get; set; }
        //构造函数
        public PersonMessage()
        {
            Available = false;
            Marked = false;
        }
        public PersonMessage(int Key = 0)
        {


            Available = false;
            Marked = false;

            if (Key == -1)
                this.Setup("", "", "", -1);

        }
        public PersonMessage(SQLPersonUnit SourceData)
        {
            this.ID = SourceData.ID;
            this.Available = SourceData.Available == 1 ? true : false;
            this.Marked = SourceData.Marked == 1 ? true : false;
            this.Name = SourceData.Name;
            this.RealName = SourceData.RealName;
            this.Describe = SourceData.Describe;
            this.Mark = (short)SourceData.Mark;
            this.PraiseNumber = SourceData.PraiseNumber;
            this.ComplainNumber = SourceData.ComplainNumber;
            this.PhoneNumber = SourceData.PhoneNumber;
            this.MarkNumber = SourceData.MarkNumber;
            this.MarkOrganize = SourceData.MarkOrganize;
            this.Password = SourceData.Password;
            //this.SetupDate = new DateTime();
            //this.LoginDate = new DateTime();


            if (this.Name == "C-Cat")
            {
                this.HeadImage = new Image()
                {
                    Source = ImageSource.FromFile("Icons/Icon-CCat853.gif")
                };
            }
            else
            {
                this.HeadImage = new Image()
                {
                    Source = ImageSource.FromFile("Icons/DafultHeadImg.gif")
                };
            }

        }

        //创建以及验证过程 （+更新）
        public int Setup(string Name, string Describe, string PhoneNumber, int Key = 0)
        {
            if (Key == -1)
            {
                this.Name = "C-Cat";
                this.Describe = "没什么方向感但对一切充满好奇的程序员";
                this.PhoneNumber = "17628028283";
                this.TakeMark("", "", "",-1);

                this.ComplainNumber = 0;
                this.PraiseNumber = 16;

                this.Available = true;

                this.HeadImage = new Image
                {
                    Source = ImageSource.FromFile("Icons/Icon-CCat853.gif")
                };

                this.Password = "123456";
                ID = IDRequest(0);
                return 1;
            }
            this.Name = Name;
            this.Describe = Describe;
            this.PhoneNumber = PhoneNumber;
            this.HeadImage = new Image()
            {
                Source = ImageSource.FromFile("Icons/DafultHeadImg.gif")
            };
            /*
             * 占位：其他设置过程
             */

            
            if (Update(0) == 1)
            {
                this.Available = true;
            }
            return 1;
        }
        public int TakeMark(string MarkNumber, string MarkOrganize,string RealName, int key = 0)
        {
            if (key == -1)
            {
                this.MarkNumber = "1546108";
                this.MarkNumber = "湖南人文科技学院";
                this.RealName = "信息学院软件工程一班 王凯";
                this.Marked = true;

                this.Mark = 94;
                return 1;
            }

            this.MarkNumber = MarkNumber;
            this.MarkOrganize = MarkOrganize;
            this.RealName = RealName;
            /*
             * 占位：提交并验证认证信息（返回数据确认RealName），验证成功设置Marked标志为true；
             */


            ID = IDRequest(0);
            return 1;
        }
        private int IDRequest(int Key = 0)
        {
            int TID = -1;

            BlackCat.App.DataCatcherE.PersonTableC.Alter(this);
            foreach (SQLPersonUnit e in BlackCat.App.DataCatcherE.PersonTableC.SQLConnection.
                Query<SQLPersonUnit>("SELECT * FROM SQLPersonUnit WHERE PhoneNumber =" + "'" +this.PhoneNumber+"'").
                AsEnumerable<SQLPersonUnit>())
            {
                TID = e.ID;
            }

            return TID;
        }
        public int Update(int Key = 0)
        {
            int R = 0;

            /*
             * 占位：更新服务器数据，更新成功返回1，否则为其他值
             */

            return R;
        }
        public void ExhangeToDate(string SourceData)
        {
            
        }

    }
    public class ActivityMessage
    {
        public long ID;
        public string Title;
        public string Describe;
        public string Place;
        public string StartPlace;
        public int PeopleNumber;
        public int PeopleNumberLimit;
        public string[] Tags = new string[3];
        public int TagsCount = 0;
        public int TagsNumberMaxLimit = 3;
        public bool Availabe;
        public bool HasMessage;

        public PersonMessage Creater;
        public PersonMessage[] Follower;
        int FollowerCount = 0;

        public DateTime CreatDate;
        public DateTime PlanDate;

        public long[] FollowMessageID;
        int FollowMessageIDCount = 0;

        public ActivityMessage()
        {
            Availabe = false;
            HasMessage = false;
            TagsCount = 0;
        }
        public ActivityMessage(string Title, string Describe, string Place,
            string StartPlace, int PeopleNumberLimit, PersonMessage Creater,
            int Key = 0)
        {
            this.Title = Title;
            this.Describe = Describe;
            this.Place = Place;
            this.StartPlace = StartPlace;
            this.PeopleNumberLimit = PeopleNumberLimit;
            this.Creater = Creater;



            Availabe = false;
            HasMessage = true;

            if (Key == -1)
            {
                this.Title = "一起去爬山吧";
                this.Describe = "各位，明天是儿童节啊！虽然我们早就不是儿童了，" +
                    "但我们的童心还在！明天6月1日早上9：00，我们组织一个队伍去爬山吧，" +
                    "就去离我们最近的仙女峰。人数十人，费用自理。" + Environment.NewLine +
                    "详细信息如下： " + Environment.NewLine +
                    Environment.NewLine +
                    "9：00 在图书馆正门集合，然后乘坐公交车出发" + Environment.NewLine +
                    "10：00  大约1个小时的车程，到达目的地，短暂休息后随" +
                    "即开始进行攀登，根据其高度，一般来说，在下午1点之" +
                    "前可以到达顶峰" + Environment.NewLine +
                    "13：00 在顶峰吃午饭（自带）， 进行集体性的娱乐活动" + Environment.NewLine +
                    "14：00 一起四处游玩，走遍各个景点" + Environment.NewLine +
                    "16：00 集合并返回学校，活动结束。" + Environment.NewLine +
                    Environment.NewLine +
                    "备注：" + Environment.NewLine +
                    "1.交通、食物级其他费用均属自理" + Environment.NewLine +
                    "2.尽量不要离队过久，以避免意外情况" + Environment.NewLine +
                    "3.攀登需要注意个人安全，切勿做危险行为" + Environment.NewLine +
                    "4.准时出发，大家不要迟到哦" + Environment.NewLine +
                    Environment.NewLine +
                    "大家一起来玩吧！";
                this.Place = "娄底 仙女峰";
                this.StartPlace = "湖南人文科技学院 图书馆正门";
                this.PeopleNumberLimit = 10;
                this.Creater = Creater;
                this.PlanDate = new DateTime(2017, 6, 1, 9, 0, 0);
                this.FollowerCount = 0;

                HasMessage = true;
                AddTag(1);

            }
        }
        public ActivityMessage(SQLActivityUnit SourceData)
        {
            this.Title = SourceData.Title;
            this.ID = SourceData.ID;
            this.Describe = SourceData.Describe;
            this.Place = SourceData.Place;
            this.StartPlace = SourceData.StartPlace;
            this.PeopleNumber = SourceData.PeopleNumber;
            this.PeopleNumberLimit = SourceData.PeopleNumberLimit;
            
            if (SourceData.Tag1 != "")
            {
                this.Tags[0] = SourceData.Tag1;
                TagsCount++;
            }
            if (SourceData.Tag2 != "")
            {
                this.Tags[1] = SourceData.Tag2;
                TagsCount++;
            }
            if (SourceData.Tag3 != "")
            {
                this.Tags[2] = SourceData.Tag3;
                TagsCount++;
            }
            this.Availabe = SourceData.Availabe == 1 ? true : false;
            this.HasMessage = SourceData.HasMessage == 1 ? true : false;

            Creater = new PersonMessage(BlackCat.App.DataCatcherE.PersonTableC.GetUnit(SourceData.CreaterID));
        }
        public int AddTag(int TagIndex)
        {
            this.Tags = new string[TagsNumberMaxLimit];
            this.Tags[TagsCount] = " ";
            try
            {
                this.Tags[TagsCount] = (new DefaultTags()).GetTag(1, TagIndex - 1);
            }
            catch (Exception e)
            {
                string em = e.Message;
                em = e.Message;
            }
            TagsCount++;
            if (HasMessage == true)
            {
                Availabe = true;
                this.ID = IDRequest(0);
            }
            return 1;
        }
        public int AddFollower(PersonMessage NewFollower)
        {
            if (Follower.Length > PeopleNumberLimit)
                return -1; //人数超限
            Follower[FollowerCount] = NewFollower;
            FollowerCount++;
            return 1;
        }
        public int AddFollowMessageID(long FollowMessageID)
        {
            this.FollowMessageID[FollowMessageIDCount] = FollowMessageID;
            FollowMessageIDCount++;
            return 1;
        }
        public long IDRequest(int Key = 0)
        {
            long TID = -1;

            BlackCat.App.DataCatcherE.ActivityTableC.Alter(this);
            
            foreach(SQLActivityUnit e in BlackCat.App.DataCatcherE.ActivityTableC.SQLConnection
                .Query<SQLActivityUnit>("SELECT * FROM SQLActivityUnit WHERE PeopleNumberLimit=" + this.PeopleNumberLimit)
                .AsEnumerable())
            {
                TID = e.ID;
                
            }

            return TID;
        }
        public int Update(int Key = 0)
        {
            /*
             * 占位：上传数据 + 条件判定验证
             */
            return 1;
        }
    }
    public class GuestbookMessage
    {
        public long MessageID;
        public bool Available;

        public int CreaterID;

        public string Message;

        public DateTime CreateDate;

        public long FollowToActivityID;
        public long FollowToMessageID;
        public long[] FollowMessageID;
        public int FollowMessageIDCount = 0;

        public GuestbookMessage()
        {
            Available = true;
        }
        public GuestbookMessage(string Message, PersonMessage Creater, long FollowToMessageID)
        {
            this.Message = Message;
            this.CreaterID = Creater.ID;
            this.FollowToMessageID = FollowToMessageID;

            MessageID = IDRequest(0);

            BlackCat.App.DataCatcherE.GuestbookTableC.Alter(this);
        }
        public int AddFollowMessageID(long FollowMessageID)
        {
            this.FollowMessageID[FollowMessageIDCount] = FollowMessageID;
            FollowMessageIDCount++;
            //this.FollowMessageID.Append(FollowMessageID);
            return 1;
        }
        private long IDRequest(int Key = 0)
        {
            long TID = -1;

            /*
             * 占位：向服务器申请可用用户ID；
             */

            return TID;
        }
        public int Update(int Key = 0)
        {
            /*
             * 占位：上传数据
             */
            return 1;
        }
    }
    public class MessageReadRecode
    {
        public int ReadMessageID;
        public int ReadMessageNumber;
        public int StyleID;

        public MessageReadRecode()
        {
            ReadMessageID = -1;
            ReadMessageNumber = -1;
            StyleID = -1;
        }
        public MessageReadRecode(int ID, int Number)
        {
            ReadMessageID = ID;
            ReadMessageNumber = Number;
        }
        public int Recode(int ID, int Number)
        {
            ReadMessageID = ID;
            ReadMessageNumber = Number;
            return 1;
        }

    }
    public class ReadMessageRecoder
    {
        MessageReadRecode[] RecoderData;
        int ListIndex;

        public ReadMessageRecoder()
        {
            RecoderData = new MessageReadRecode[100];
            ListIndex = 0;
        }
        public ReadMessageRecoder(MessageReadRecode New) : this()
        {
            RecoderData[0] = New;
            ListIndex = 1;
            RecoderData[0].StyleID = ListIndex - 1;
        }
        public ReadMessageRecoder(int ID, int Number) : this()
        {
            RecoderData[0] = new MessageReadRecode(ID, Number);
            ListIndex = 1;
            RecoderData[0].StyleID = ListIndex - 1;
        }
        public int CheckIn(MessageReadRecode New)
        {

            if (Sreach(New.ReadMessageID) == null)
            {
                RecoderData[ListIndex] = New;
                RecoderData[ListIndex].StyleID = ListIndex + 1;
                ListIndex++;
            }
            else
            {
                RecoderData[Sreach(New.ReadMessageID).StyleID - 1].ReadMessageNumber = New.ReadMessageNumber;//有点晕。。。。
            }
            return 1;
        }
        public int CheckOut(int ID)
        {
            MessageReadRecode Temp = Sreach(ID);

            RecoderData[Temp.StyleID - 1] = null;

            ReCombine();


            return 1;
        }
        public MessageReadRecode Sreach(int ID)
        {
            MessageReadRecode GetObject = null;


            for (int i = 0; i < ListIndex; i++)
            {
                if (RecoderData[i].ReadMessageID == ID)
                    GetObject = RecoderData[i];
            }

            return GetObject;
        }
        private int ReCombine(int StartIndex = 0)
        {
            if (StartIndex > ListIndex)
                return 0;

            for (int i = StartIndex; i < ListIndex; i++)
            {
                if (RecoderData[i].Equals(null))
                {
                    for (int n = i; n < ListIndex; n++)
                    {
                        RecoderData[n] = RecoderData[n + 1];
                        RecoderData[n + 1] = null;
                    }
                    ListIndex--;
                }
            }
            return 1;
        }
    }
    //3.1.数据库数据格式类
    public class SQLPersonUnit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Available { get; set; }
        public string SetupDateSourceData { get; set; }
        public string LoginDateSourceData { get; set; }
        public int Marked { get; set; }
        public string RealName { get; set; }
        public string MarkNumber { get; set; }
        public string MarkOrganize { get; set; }
        public int Mark { get; set; }
        public int PraiseNumber { get; set; }
        public int ComplainNumber { get; set; }
        public string Describe { get; set; }

        public string Password { get; set; }
    }
    public class SQLActivityUnit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title{ get; set; }
        public string Describe{ get; set; }
        public string Place{ get; set; }
        public string StartPlace{ get; set; }
        public int PeopleNumberLimit{ get; set; }
        public int FollowerNumber { get; set; }
        public string Tag1{ get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public int Availabe{ get; set; }
        public int HasMessage{ get; set; }
        public int PeopleNumber { get; set; }

        public int CreaterID{ get; set; }

        public string CreatDate{ get; set; }
        public string PlanDate{ get; set; }
    }
    public class SQLGuestbookUnit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        public int FollowActivityID { get; set; }
        public int FollowGuestbookID { get; set; }
        public int CreaterID { get; set; }

        public string Describe { get; set; }
        
        public string CreateSourceDate { get; set; }
        

    }
    public class SQLFollowListUnit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int ActivityID { get; set; }
        public int FollowerID { get; set; }
        public string CreateSourceDate { get; set; }

    }
}
