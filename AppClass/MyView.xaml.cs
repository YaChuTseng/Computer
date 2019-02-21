using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppClass
{
    public partial class MyView : ContentView
    {
        public event EventHandler MyClick;

        public MyView()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if(MyClick!=null)
            {
                MyClick(sender, e);
            }
        }
    }
}
