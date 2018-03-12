using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public interface IInitiativeService
    {
        Task<List<Initiative>> GetAllActive();
        Task<List<Initiative>> GetAll();
        Task SaveInitiative(Initiative initiative);
        Task<Initiative> UpdateInitiative(Initiative initiative);
        Task DeleteInitiative(Initiative initiative);
    }
}
