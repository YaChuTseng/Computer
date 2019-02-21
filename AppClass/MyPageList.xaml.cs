using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppClass
{
    public partial class MyPageList : ContentPage
    {
        public MyPageList()
        {
            InitializeComponent();
        }
    }

    public class ListViewModel
    {
        //public List<string> Items { get; set; }
        public List<Data> Items { get; set; }

        public ListViewModel()
        {
            //Items = new List<string>();
            Items = new List<Data>();
            for (int i = 1; i <= 100; i++)
            {
                //Items.Add($"我是第{i}個");
                Items.Add(new Data() { Value = $"我是第{i}個",Index=i});
            }
        }
    }

    public class Data
    {
        public string Value { get; set; }

        public int Index { get; set; }
    }
}
