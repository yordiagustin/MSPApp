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
    public partial class ContributionsPage : ContentPage
    {
        private ContributionsViewModel viewModel;
        public ContributionsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ContributionsViewModel(this);
        }
        
    }
}