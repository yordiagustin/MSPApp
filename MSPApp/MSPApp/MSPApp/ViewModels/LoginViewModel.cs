using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Helpers;
using MSPApp.Models;
using MSPApp.Service;
using MSPApp.Views;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Members

        private Realm _instance => Realm.GetInstance();

        private readonly IEncryptorService _encryptorService;
        private readonly IUserService _userService;

        #endregion

        #region  Properties

        private User _user;

        public User User
        {
            get => _user;
            set => _user = value;
        }

        #endregion

        #region Commands

        public ICommand LoginCommand => new Command(async () => await Login());
        public ICommand HelpCommand => new Command(async () => await Help());

        #endregion

        public LoginViewModel(Page page) : base(page)
        {
            _user = new User();
            _encryptorService = new EncryptorService();
            _userService = new UserService();
        }

        private async Task Login()
        {
            try
            {
                IsBusy = true;
                var email = _user.Email;
                var password = _user.Password;
                if (!string.IsNullOrEmpty(email) && !(string.IsNullOrEmpty(password)))
                {
                    var pass = _encryptorService.EncryptAes(password, Constants.passwordCrypto);
                    var validated = await _userService.Login(email, pass);
                    if (validated != null)
                    {
                        Settings.IsLogged = true;
                        Variables.ConstantUser = validated;
                        var userDB = TransformToUserDB(validated);
                        _instance.Write(() =>
                        {
                            _instance.Add(userDB);
                        });
                        await NavigateToModal(new MasterPage());
                        IsBusy = false;
                    }
                    else
                    {
                        OnMessage("Incorrect Credentials");
                        User = new User();
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private UserDB TransformToUserDB(User validated)
        {
            var userDB = new UserDB()
            {
                MobileId = validated.Id,
                Email = validated.Email,
                Username = validated.Username,
                Name = validated.Name,
                Surname = validated.Surname,
                Password = validated.Password,
                IsAdmin = validated.IsAdmin,
                IsActive = validated.IsActive,
                Biography = validated.Biography,
                Country = validated.Country,
                WebsiteUrl = validated.WebsiteUrl,
                FacebookUrl = validated.FacebookUrl,
                TwitterUrl = validated.TwitterUrl,
                LinkedInUrl = validated.LinkedInUrl,
                ProfileUrl = validated.ProfileUrl,
                GithubUrl = validated.GithubUrl,
                BackgroundUrl = validated.BackgroundUrl,
                FirstAwarded = validated.FirstAwarded,
                NumberOfAwards = validated.NumberOfAwards
            };
            return userDB;
        }

        private async Task Help()
        {
            await ModalPopUp(new UserRequest());
        }

    }
}
