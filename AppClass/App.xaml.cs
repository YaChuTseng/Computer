using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppClass
{
    public partial class App : Application
    {
        //public string Value = "test";

        public App()
        {
            InitializeComponent();

            MainPage = new MyPageComputer();
            //MainPage = new NavigationPage(new MyPage8());
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
    }
}
