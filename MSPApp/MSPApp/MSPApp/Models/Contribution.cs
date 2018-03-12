using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Models
{
    public class Contribution
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Visibility { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
