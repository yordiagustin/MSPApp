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
    public class AddContributionViewModel : ViewModelBase
    {
        #region Members

        private readonly IContributionService _contributionService;
        private Contribution _contribution;

        public DateTime Today => DateTime.Today;
        public DateTime MinimumDate => new DateTime(2017,01,01);

        #endregion

        #region Properties

        public Contribution Contribution
        {
            get => _contribution;
            set
            {
                _contribution = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand => new Command(async () => await SaveContribution());

        #endregion

        #region Constructor

        public AddContributionViewModel(Page page) : base(page)
        {
            Contribution = new Contribution();
            _contributionService = new ContributionService();
        }

        #endregion

        #region Methods

        private async Task SaveContribution()
        {
            try
            {
                IsBusy = true;
                if (_contribution != null)
                {
                    _contribution.UserId = Variables.ConstantUser.Id;
                    await _contributionService.SaveContribution(_contribution);
                    IsBusy = false;
                    OnMessage("Contribution Registered");
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
