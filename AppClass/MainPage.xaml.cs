using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppClass
{
    public class Test
    {
        public static string Value = "test";
    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var app = Application.Current as App;
            //var value = app.Value;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //lbl.Text = "Test"; 

        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

    }
}
