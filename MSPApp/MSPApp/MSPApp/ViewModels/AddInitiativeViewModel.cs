using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MSPApp.Helpers;
using MSPApp.Models;
using MSPApp.Service;
using Xamarin.Forms;

namespace MSPApp.ViewModels
{
    public class AddInitiativeViewModel : ViewModelBase
    {
        #region Members

        private readonly IInitiativeService _initiativeService;
        private Initiative _iniative;

        public DateTime Today => DateTime.Today;

        #endregion

        #region Properties

        public Initiative Initiative
        {
            get => _iniative;
            set
            {
                _iniative = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand => new Command(async () => await SaveInitiative());

        #endregion

        #region Constructor

        public AddInitiativeViewModel(Page page) : base(page)
        {
            Initiative = new Initiative();
            _initiativeService = new InitiativeService();
        }

        #endregion

        #region Methods

        private async Task SaveInitiative()
        {
            try
            {
                IsBusy = true;
                if (_iniative != null)
                {
                    await _initiativeService.SaveInitiative(_iniative);
                    IsBusy = false;
                    OnMessage("Iniative Registered");
                    await NavigateGoBack();
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

        #endregion
    }
}
