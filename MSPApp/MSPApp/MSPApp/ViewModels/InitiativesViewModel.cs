using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Helpers;
using MSPApp.Models;
using MSPApp.Service;
using MSPApp.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class InitiativesViewModel : ViewModelBase
    {
        #region Members

        private readonly IInitiativeService _initiativeService;

        private List<Initiative> _initiatives;

        private User _user;

        #endregion

        #region Properties

        public List<Initiative> Initiatives
        {
            get => _initiatives;
            set
            {
                _initiatives = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand AddCommand => new Command(async () => await AddInitiative());

        #endregion

        #region Constructor

        public InitiativesViewModel(Page page) : base(page)
        {
            _initiativeService = new InitiativeService();
            User = Variables.ConstantUser;
            Load();
        }

        #endregion

        #region Methods

        private async void Load()
        {
            IsBusy = true;
            Initiatives = await _initiativeService.GetAllActive();
            IsBusy = false;
        }

        private async Task AddInitiative()
        {
            if (_user.IsAdmin)
                await NavigateTo(new AddInitiativePage());
            else
                OnMessage("You are not authorized. Contact with your Program Manager");
        }

        #endregion
        
    }
}
