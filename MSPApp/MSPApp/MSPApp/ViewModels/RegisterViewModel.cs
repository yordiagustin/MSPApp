using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Models;
using MSPApp.Service;
using MvvmHelpers;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Members

        private readonly IUserService _userService;
        private readonly IEncryptorService _encryptorService;

        private User _user;

        #endregion

        #region Properties

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            } 
        }

        #endregion

        #region Commands

        public ICommand RegisterCommand => new Command(async() => await Register());

        #endregion

        #region Constructor

        public RegisterViewModel()
        {
            User = new User();
            _userService = new UserService();
            _encryptorService = new EncryptorService();
        }

        #endregion

        #region Methods

        private async Task Register()
        {
            IsBusy = true;
            try
            {
                if (User == null)
                {
                    IsBusy = false;
                    return;
                }
                _user.Password = _encryptorService.EncryptAes(_user.Password, Constants.passwordCrypto);
                await _userService.SaveUser(_user);
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Exito", "Usuario Registrado", "Ok!");
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Revisa tu conexión", "Ok!");
            }
            finally
            {
                IsBusy = false;
            }

        }

        #endregion
    }
}
