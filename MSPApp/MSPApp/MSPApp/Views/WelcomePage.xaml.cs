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
    public partial class WelcomePage : ContentPage
    {
        private WelcomeViewModel viewModel;
        public WelcomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new WelcomeViewModel(this);
        }
    }
}