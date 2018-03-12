using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        #region Members
        
        public static User ConstantUser;

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

        public ICommand EditProfileCommand => new Command(async () => await EditProfile());

        #endregion

        #region Constructor

        public ProfileViewModel()
        {
            User = ConstantUser;
        }

        #endregion

        #region Methods

        private async Task EditProfile()
        {
            
        }

        #endregion
    }
}
