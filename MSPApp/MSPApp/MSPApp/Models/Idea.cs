using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Models
{
    public class Idea
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TechnologyDetails { get; set; }
        public string SupportDetails { get; set; }
    }
}
