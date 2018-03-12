using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> Login(string email, string password);
        Task<User> FindByEmail(string email);
        Task<List<User>> GetAll();
    }
}
