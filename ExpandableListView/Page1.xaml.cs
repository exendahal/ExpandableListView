using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpandableListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public ICommand TapCommand { get; set; }
        public Page1()
        {
            //Just for demo purpose,no related to this topic
            BindingContext = this;
            InitializeComponent();
            List<ItemModel> itemModels = new List<ItemModel>();
            itemModels.Add(new ItemModel() { Name="hello",Location="Kathmandu"});
            itemModels.Add(new ItemModel() { Name="Hi",Location="Nepal"});
            list.ItemsSource = itemModels;
            TapCommand = new Command<ItemModel>(async items =>
            {
                await DisplayAlert(items.Name, items.Location, "OK");
            });
        }
    }
}