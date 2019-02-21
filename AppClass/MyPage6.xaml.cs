
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppClass
{
    public partial class MyPage6 : ContentPage
    {
        public MyPage6()
        {
            InitializeComponent();

            this.Title="MyPage6";

            //var man = new Man() { Name = "Bill", Age = 18 };
            //this.BindingContext = man;

            //Binding nameBinding = new Binding();
            //nameBinding.Source = man;
            //nameBinding.Path = nameof(man.Name);
            //lblName.SetBinding(Label.TextProperty, nameBinding);

            //Binding ageBinding = new Binding();
            //nameBinding.Source = man;
            //nameBinding.Path = nameof(man.Age);
            //lblAge.SetBinding(Label.TextProperty, ageBinding);
        }

        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    var man=this.BindingContext as Man;
        //    man.Age += 1;
        //}

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            //this.Navigation.PushAsync(new MainPage());
            this.Navigation.PushModalAsync(new MainPage());
        }
    }



    public class Man : INotifyPropertyChanged
    {
        private int _age = 18;

        public ICommand OnAddAge { get; set; }

        public string Name { get; set; } = "Bill";
        public int Age
        {
            get { return this._age; }
            set
            {
                this._age = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Age)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Man()
        {
            this.OnAddAge = new Command
                (() =>
                {
                    this.Age += 1;
                });
        }
    }
}



