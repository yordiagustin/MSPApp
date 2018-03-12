using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSPApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRequest : PopupPage
    {
        private UserRequestViewModel viewModel;
        public UserRequest()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserRequestViewModel(this);
        }
    }
}