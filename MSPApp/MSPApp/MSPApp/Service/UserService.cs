using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public class UserService : IUserService
    {
        public async Task SaveUser(User user)
        {
            if (user != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<User>();
                    await tabla.InsertAsync(user);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            if (user == null) return null;
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                await tabla.UpdateAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                var users = App.MobileService.GetTable<User>();
                List<User> result = await users.Where(x => x.Email == email && x.Password == password).Take(1).ToListAsync();
                return result.FirstOrDefault();
            }
            catch
            {
                throw new TimeoutException();
            }
        }

        //public async Task<List<User>> GetAll(string filterUser, int pageIndex, int pageSize)
        //{
        //    List<User> coleccion = new List<User>();
        //    try
        //    {
        //        var tabla = App.MobileService.GetTable<User>();
        //        coleccion = await tabla.Where(x => x.Name.Contains(filterUser) || x.Surname.Contains(filterUser))
        //                            .Skip((pageIndex - 1) * pageSize)
        //                            .Take(pageSize)
        //                            .OrderBy(x => x.Name)
        //                            .ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
        //    }
        //    return coleccion;
        //}

        public async Task<List<User>> GetAll()
        {
            List<User> coleccion = new List<User>();
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                coleccion = await tabla.ToListAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
            }
            return coleccion;
        }

        public async Task<User> FindByID(string id)
        {
            User user;
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                var users = await tabla.Where(x => x.Id == id).Take(1).ToListAsync();
                user = users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
                return null;
            }
            return user;
        }

        public async Task<User> FindByEmail(string email)
        {
            User user;
            try
            {
                var tabla = App.MobileService.GetTable<User>();
                var users = await tabla.Where(x => x.Email == email).Take(1).ToListAsync();
                user = users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No hay conexión a internet. Code error: " + ex.Message, "Ok");
                return null;
            }
            return user;
        }
    }
}
