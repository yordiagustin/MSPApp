using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;

namespace MSPApp.Service.Interfaces
{
    public interface IRequestService
    {
        Task SaveRequest(Request request);
    }
}
