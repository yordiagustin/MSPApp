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
    public class ContributionsViewModel : ViewModelBase
    {
        #region Members
        
        private readonly IContributionService _contributionService;

        private ObservableCollection<Contribution> _contributions;

        private User _user;

        #endregion

        #region Properties

        public ObservableCollection<Contribution> Contributions
        {
            get => _contributions;
            set
            {
                _contributions = value;
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

        public ICommand AddContributionCommand => new Command(async() => await AddContribution());
        public ICommand RefreshCommand => new Command(Load);

        #endregion

        #region Constructor

        public ContributionsViewModel(Page page) : base (page)
        {
            _contributionService = new ContributionService();
            User = Variables.ConstantUser;
            Load();
        }

        #endregion

        #region Methods

        private async void Load()
        {
            IsBusy = true;
            Contributions = await _contributionService.FindByUser(_user.Id);
            IsBusy = false;
        }

        private async Task AddContribution()
        {
            await NavigateTo(new AddContributionPage());
        }

        #endregion


    }
}
