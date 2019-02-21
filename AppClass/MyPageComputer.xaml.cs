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
        private string _value = "0";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Value { get { return _value; } set { _value = value; PropertyChanged(this, new PropertyChangedEventArgs("Value")); } }

        public ICommand Calculate { get; set; }
        public ICommand Operator { get; set; }
        public ICommand Zero { get; set; }
        public ICommand PlusOrMinus { get; set; }
        public ICommand Percent { get; set; }
        public ICommand Point { get; set; }

        public Computer()
        {

            //string math = "100 / 2";
            //string value = new DataTable().Compute(math, null).ToString();

            string calculateString = string.Empty;
            OperatorType currentOperatorType = OperatorType.None;
            this.Operator = new Command<OperatorType>(arg =>
            {
                currentOperatorType = arg;
                switch (arg)
                {
                    case OperatorType.Plus:
                        calculateString += "+";
                        break;
                    case OperatorType.Minus:
                        calculateString += "-";
                        break;
                    case OperatorType.Multiplied:
                        calculateString += "*";
                        break;
                    case OperatorType.Divided:
                        calculateString += "/";
                        break;
                    case OperatorType.Equal:
                        this.Value = new DataTable().Compute(calculateString, null).ToString();
                        break;
                }
            });

            this.Calculate = new Command<string>(num =>
            {
                if (currentOperatorType == OperatorType.None)
                    this.Value = this.Value == "0" ? num : this.Value += num;
                else
                {
                    currentOperatorType = OperatorType.None;
                    this.Value = num;
                }
                calculateString += num;
            });

            this.Zero = new Command(() =>
            {
                this.Value = "0";
                calculateString = "";

            });

            this.PlusOrMinus = new Command(num =>
            {
                this.Value = (double.Parse(this.Value) * (-1)).ToString();
            });

            this.Percent = new Command(() =>
            {
                this.Value = (double.Parse(this.Value) / 100).ToString();
            });



        }
    }
}
