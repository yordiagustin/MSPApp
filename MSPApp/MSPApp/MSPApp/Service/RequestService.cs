using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Models;
using MSPApp.Service.Interfaces;

namespace MSPApp.Service
{
    public class RequestService : IRequestService
    {
        public async Task SaveRequest(Request request)
        {
            if (request != null)
            {
                try
                {
                    var tabla = App.MobileService.GetTable<Request>();
                    await tabla.InsertAsync(request);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
