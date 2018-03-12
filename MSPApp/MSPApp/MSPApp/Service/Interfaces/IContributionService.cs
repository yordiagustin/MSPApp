using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public interface IContributionService
    {
        Task<ObservableCollection<Contribution>> GetAll();
        Task SaveContribution(Contribution contributionAux);
        Task<Contribution> UpdateContribution(Contribution contributionAux);
        Task DeleteContribution(Contribution contributionAux);
        Task<ObservableCollection<Contribution>> FindByUser(string userId);
    }
}
