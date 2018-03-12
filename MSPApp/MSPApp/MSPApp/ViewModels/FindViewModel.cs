using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;
using MSPApp.Service;
using MSPApp.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class FindViewModel : ViewModelBase
    {
        #region Members

        private readonly IUserService _userService;

        private List<User> _users;

        #endregion

        #region Properties

        public List<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public FindViewModel(Page page) : base(page)
        {
            _userService = new UserService();
            Load();
        }

        #endregion

        #region MyRegion

        private async void Load()
        {
            IsBusy = true;
            Users = await _userService.GetAll();
            Users = Users.OrderBy(x => x.Name).ToList();
            IsBusy = false;
        }

        public async Task OnUser(User userAux)
        {
            ProfileViewModel.ConstantUser = userAux;
            await NavigateTo(new ProfilePage());
        }

        #endregion
    }
}
