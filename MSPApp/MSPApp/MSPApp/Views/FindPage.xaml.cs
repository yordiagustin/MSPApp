using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;
using MSPApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSPApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindPage : ContentPage
    {
        private FindViewModel _viewModel;
        public FindPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FindViewModel(this);
        }

        private async Task MenuList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is User item))
            {
                return;
            }
            MenuList.SelectedItem = null;
            await _viewModel.OnUser(item);
        }
    }
}