using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Helpers;
using MSPApp.Models;
using MSPApp.Models.Data;
using MSPApp.Views;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {

        #region Members

        private Realm _instance = Realm.GetInstance();

        public List<Item> Items => User.IsAdmin ? new ItemData().ItemsList.ToList() : new ItemData().ItemsList.Where(x => x.IsAdmin == false).ToList();

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

        public ICommand ProfileCommand => new Command(GoToProfile);
        public ICommand LogoutCommand => new Command(Logout);

        #endregion

        #region Constructor

        public MenuViewModel(Page page) : base(page)
        {
            GetUser();
        }

        #endregion

        #region Methods

        private void GetUser()
        {
            if (Variables.ConstantUser == null)
            {
                var userDB = _instance.All<UserDB>().First();
                var user = TransformToUser(userDB);
                Variables.ConstantUser = user;
            }
            User = Variables.ConstantUser;
            return;
        }
        private void GoToProfile()
        {
            ProfileViewModel.ConstantUser = User;
            App.MasterPage.IsPresented = false;
            App.MasterPage.Detail = new NavigationPage(new ProfilePage());
        }

        private void Logout()
        {
            try
            {
                var userDB = _instance.All<UserDB>().First();
                Settings.IsLogged = false;
                using (var transaction = _instance.BeginWrite())
                {
                    _instance.Remove(userDB);
                    transaction.Commit();
                }
                ;
                NavigatePageCurrent(new WelcomePage());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private User TransformToUser(UserDB validated)
        {
            var userDB = new User()
            {
                Id = validated.MobileId,
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

        #endregion
    }
}
