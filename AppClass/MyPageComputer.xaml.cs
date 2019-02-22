using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppClass
{
    public partial class MyPageComputer : ContentPage
    {
        public MyPageComputer()
        {
            this.BindingContext = new Computer();

            InitializeComponent();
        }
    }

    public enum OperatorType
    {
        None,
        Plus,
        Minus,
        Divided,
        Multiplied,
        Equal
    }

    public class Computer : INotifyPropertyChanged
    {
        private string entry = "0";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Entry { get { return entry; } set { entry = value; PropertyChanged(this, new PropertyChangedEventArgs("Entry")); } }

        public ICommand Digit { get; set; }
        public ICommand Operator { get; set; }
        public ICommand Clear { get; set; }
        public ICommand PlusOrMinus { get; set; }
        public ICommand Percent { get; set; }
        public ICommand Point { get; set; }

        public Computer()
        {
            string digitString = string.Empty;
            OperatorType currentOperatorType = OperatorType.None;
            this.Operator = new Command<OperatorType>(arg =>
            {
                currentOperatorType = arg;
                switch (arg)
                {
                    case OperatorType.Plus:
                        digitString += "+";
                        break;
                    case OperatorType.Minus:
                        digitString += "-";
                        break;
                    case OperatorType.Multiplied:
                        digitString += "*";
                        break;
                    case OperatorType.Divided:
                        digitString += "/";
                        break;
                    case OperatorType.Equal:
                        this.Entry = new DataTable().Compute(digitString, null).ToString();
                        break;
                }
            });

            this.Digit = new Command<string>(num =>
            {
                if (currentOperatorType == OperatorType.None)
                    this.Entry = this.Entry == "0" ? num : this.Entry += num;
                else
                {
                    currentOperatorType = OperatorType.None;
                    this.Entry = num;
                }
                digitString += num;
            });

            this.Clear = new Command(() =>
            {
                this.Entry = "0";
                digitString = "";
            });

            this.PlusOrMinus = new Command(() =>
            {
                this.Entry = (double.Parse(this.Entry) * (-1)).ToString();
            });

            this.Percent = new Command(() =>
            {
                this.Entry = (double.Parse(this.Entry) / 100).ToString();
            });

            this.Point = new Command(() =>
            {
                this.Entry = this.Entry.Contains(".") ? this.Entry: this.Entry+=".";
            });
        }
    }
}
