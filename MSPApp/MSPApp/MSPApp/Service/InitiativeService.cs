using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public class InitiativeService : IInitiativeService
    {
        public async Task<List<Initiative>> GetAllActive()
        {
            var coleccion = new List<Initiative>();
            try
            {
                var tabla = App.MobileService.GetTable<Initiative>();
                coleccion = await tabla.Where(x => x.IsActive == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }
        public async Task<List<Initiative>> GetAll()
        {
            var coleccion = new List<Initiative>();
            try
            {
                var tabla = App.MobileService.GetTable<Initiative>();
                coleccion = await tabla.ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }

        public async Task SaveInitiative(Initiative initiative)
        {
            if (initiative != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Initiative>();
                    await tabla.InsertAsync(initiative);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<Initiative> UpdateInitiative(Initiative initiative)
        {
            if (initiative == null) return null;
            try
            {
                var tabla = App.MobileService.GetTable<Initiative>();
                await tabla.UpdateAsync(initiative);
                return initiative;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteInitiative(Initiative initiative)
        {
            if (initiative == null) return;
            try
            {
                var tabla = App.MobileService.GetTable<Initiative>();
                await tabla.DeleteAsync(initiative);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}
