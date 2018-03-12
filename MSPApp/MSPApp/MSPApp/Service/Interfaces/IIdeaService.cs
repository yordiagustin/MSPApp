using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service
{
    public interface IIdeaService
    {
        Task<List<Idea>> GetAll(string filterUser, int pageIndex, int pageSize);
        Task SaveIdea(Idea idea);
        Task<Idea> UpdateIdea(Idea idea);
        Task DeleteIdea(Idea idea);
        Task<Idea> FindByUser(string userId);
    }
}
