using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSPApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitiativesPage : ContentPage
    {
        private InitiativesViewModel _viewModel;
        public InitiativesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new InitiativesViewModel(this);
        }
    }
}