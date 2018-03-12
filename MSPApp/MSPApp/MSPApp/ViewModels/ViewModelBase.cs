using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Views;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ICommand GoBack { get; set; }

        public Page page;
        public PopupPage popupPage;

        public ViewModelBase(Page page)
        {
            this.page = page;
            GoBack = new Command(async ()=> await NavigateGoBack());
        }

        public ViewModelBase()
        {
        }

        public ViewModelBase(PopupPage popupPage)
        {
            this.popupPage = popupPage;
            GoBack = new Command(async () => await NavigatePopUpBack());
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public async Task NavigatePopUpBack()
        {
            await this.popupPage.Navigation.PopPopupAsync();
        }

        public async Task ModalPopUp(PopupPage page)
        {
            await PopupNavigation.PushAsync(page);
        }

        public async Task NavigateGoBack()
        {
            await this.page.Navigation.PopAsync();
        }

        public async Task NavigateTo(Page pageView)
        {
            await this.page.Navigation.PushAsync(pageView);
        }

        public async Task NavigateToModal(Page modalView)
        {
            await page.Navigation.PushModalAsync(modalView);
        }

        public void NavigatePageInit(Page pageView)
        {
            Application.Current.MainPage = new NavigationPage(pageView)
            {
                //BarTextColor = Color.White,
                //BarBackgroundColor = Color.FromHex("#3893CF")
            };
        }

        public void NavigatePageCurrent(Page pageView)
        {
            Application.Current.MainPage = pageView;
        }

        public void OnMessageError()
        {
            page.DisplayAlert(Constants.NameCompany, "Hubo un problema", "Ok!");
        }

        public void OnMessage(string message)
        {
            page.DisplayAlert(Constants.NameCompany, message, "Ok!");
        }

        public async Task OnMessagePopUpAsync(string message)
        {
            await popupPage.DisplayAlert(Constants.NameCompany, message, "Ok!");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
