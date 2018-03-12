using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Helpers;
using MSPApp.Models;
using MSPApp.Service;
using MSPApp.Service.Interfaces;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class UserRequestViewModel : ViewModelBase
    {
        #region Members

        private IRequestService _requestService;

        private Request _request;

        #endregion

        #region Properties

        public Request Request
        {
            get => _request;
            set
            {
                _request = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SendCommand => new Command(async() => await Send());
        public ICommand ReturnCommand => new Command(async() => await ReturnTo());

        #endregion

        #region Constructor

        public UserRequestViewModel(PopupPage page) : base(page)
        {
            _requestService = new RequestService();
            Request = new Request();
        }

        #endregion

        #region Methods

        private async Task Send()
        {
            try
            {
                IsBusy = true;
                if (_request != null)
                {
                    await _requestService.SaveRequest(_request);
                    IsBusy = false;
                    await OnMessagePopUpAsync("Data succesfully sent");
                    await NavigatePopUpBack();
                }
            }
            catch (Exception e)
            {
                OnMessageError();
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ReturnTo()
        {
            await NavigatePopUpBack();
        }

        #endregion
    }
}
