using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Models
{
    public class Initiative
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descriptiion { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FiscalYear { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
    }
}
