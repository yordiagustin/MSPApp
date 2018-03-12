using MSPApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Service
{
    public interface IEventService
    {
        Task<List<Event>> GetAll(string filterUser, int pageIndex, int pageSize);
        Task SaveEvent(Event eventAux);
        Task<Event> UpdateEvent(Event eventAux);
        Task DeleteEvent(Event eventAux);
        Task<Event> FindByUser(string userId);
    }
}
