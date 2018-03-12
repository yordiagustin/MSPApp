using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models.Data;
using MSPApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSPApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private MenuViewModel _viewModel;
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MenuViewModel(this);
        }

        private void MenuList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Item item))
                return;
            MenuList.SelectedItem = null;
            var page = (Page)Activator.CreateInstance(item.Page);
            App.MasterPage.IsPresented = false;
            App.MasterPage.Detail = new NavigationPage(page);

        }
    }
}