using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public class IdeaService : IIdeaService
    {
        public async Task<List<Idea>> GetAll(string filterUser, int pageIndex, int pageSize)
        {
            var coleccion = new List<Idea>();
            try
            {
                var tabla = App.MobileService.GetTable<Idea>();
                coleccion = await tabla.Where(x => x.Title.Contains(filterUser))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .OrderBy(x => x.Title)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }

        public async Task SaveIdea(Idea idea)
        {
            if (idea != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Idea>();
                    await tabla.InsertAsync(idea);
                }
                catch (Exception ex)
                {
                    //ignore
                }
            }
        }

        public async Task<Idea> UpdateIdea(Idea idea)
        {
            if (idea == null) return null;
            try
            {
                var tabla = App.MobileService.GetTable<Idea>();
                await tabla.UpdateAsync(idea);
                return idea;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteIdea(Idea idea)
        {
            if (idea == null) return;
            try
            {
                var tabla = App.MobileService.GetTable<Idea>();
                await tabla.DeleteAsync(idea);
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        public async Task<Idea> FindByUser(string userId)
        {
            Idea idea;
            try
            {
                var tabla = App.MobileService.GetTable<Idea>();
                var users = await tabla.Where(x => x.UserId == userId).Take(1).ToListAsync();
                idea = users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
                return null;
            }
            return idea;
        }
    }
}
