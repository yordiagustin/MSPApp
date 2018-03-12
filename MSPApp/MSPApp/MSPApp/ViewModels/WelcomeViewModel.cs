using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        #region Commands

        public ICommand GoToLoginCommand => new Command(async() => await GoToLogin());

        public ICommand SeeMoreCommand => new Command(SeeMore);

        #endregion

        #region Constructor

        public WelcomeViewModel(Page page ) : base(page)
        {
            
        }

        #endregion

        #region Methods

        private async Task GoToLogin()
        {
            await NavigateToModal(new LoginPage());
        }

        private void SeeMore()
        {
            Uri uri = new Uri("https://imagine.microsoft.com/en-us/msp");
            Device.OpenUri(uri);
        }

        #endregion
    }
}
