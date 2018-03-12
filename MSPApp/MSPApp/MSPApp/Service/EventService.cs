using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public class EventService : IEventService
    {
        public async Task<List<Event>> GetAll(string filterUser, int pageIndex, int pageSize)
        {
            var coleccion = new List<Event>();
            try
            {
                var tabla = App.MobileService.GetTable<Event>();
                coleccion = await tabla.Where(x => x.Name.Contains(filterUser))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }

        public async Task SaveEvent(Event eventAux)
        {
            if (eventAux != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Event>();
                    await tabla.InsertAsync(eventAux);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<Event> UpdateEvent(Event eventAux)
        {
            if (eventAux == null) return null;
            try
            {
                var tabla = App.MobileService.GetTable<Event>();
                await tabla.UpdateAsync(eventAux);
                return eventAux;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteEvent(Event eventAux)
        {
            if (eventAux == null) return;
            try
            {
                var tabla = App.MobileService.GetTable<Event>();
                await tabla.DeleteAsync(eventAux);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public async Task<Event> FindByUser(string userId)
        {
            Event eventAux;
            try
            {
                var tabla = App.MobileService.GetTable<Event>();
                var users = await tabla.Where(x => x.UserId == userId).Take(1).ToListAsync();
                eventAux = users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
                return null;
            }
            return eventAux;
        }
    }
}
