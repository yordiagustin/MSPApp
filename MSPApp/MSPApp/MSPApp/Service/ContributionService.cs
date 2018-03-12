using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public class ContributionService : IContributionService
    {
        public async Task<ObservableCollection<Contribution>> GetAll()
        {
            var coleccion = new ObservableCollection<Contribution>();
            try
            {
                var tabla = App.MobileService.GetTable<Contribution>();
                var list = await tabla.ToListAsync();
                coleccion = new ObservableCollection<Contribution>(list);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }

        public async Task SaveContribution(Contribution contributionAux)
        {
            if (contributionAux != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Contribution>();
                    await tabla.InsertAsync(contributionAux);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<Contribution> UpdateContribution(Contribution contributionAux)
        {
            if (contributionAux == null) return null;
            try
            {
                var tabla = App.MobileService.GetTable<Contribution>();
                await tabla.UpdateAsync(contributionAux);
                return contributionAux;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteContribution(Contribution contributionAux)
        {
            if (contributionAux == null) return;
            try
            {
                var tabla = App.MobileService.GetTable<Contribution>();
                await tabla.DeleteAsync(contributionAux);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public async Task<ObservableCollection<Contribution>> FindByUser(string userId)
        {
            ObservableCollection<Contribution> contributions;
            try
            {
                var tabla = App.MobileService.GetTable<Contribution>();
                var list = await tabla.Where(x => x.UserId == userId).Take(1).ToListAsync();
                contributions = new ObservableCollection<Contribution>(list);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
                return null;
            }
            return contributions;
        }
    }
}
