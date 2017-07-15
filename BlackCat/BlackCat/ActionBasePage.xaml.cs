using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlackCat
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionBasePage : ContentPage
    {
        public AbsoluteLayout MainBaseAL;
        public static StackLayout MainBaseSL;
        public StackLayout SuperBottonBV;



        public ActionBasePage()
        {
            InitializeComponent();

            MainBaseAL = new AbsoluteLayout();
            MainBaseSL = new StackLayout();
            SuperBottonBV = new StackLayout();

            MainBaseSlBuilder();
            SuperBottonBVBuilder();

            MainBaseAL.Children.Add(MainBaseSL);
            MainBaseAL.Children.Add(SuperBottonBV);

            //Content = MainBaseAL;
        }
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
            SuperBottonBV.HeightRequest = 80;
            SuperBottonBV.WidthRequest = 80;
            SuperBottonBV.HorizontalOptions = LayoutOptions.EndAndExpand;
            SuperBottonBV.VerticalOptions = LayoutOptions.EndAndExpand;
            IsVisible = true;

        }

    }
}