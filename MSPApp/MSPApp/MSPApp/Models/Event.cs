using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPApp.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Place { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EventUrl { get; set; }
        public string BackgroundUrl { get; set; }

        public virtual User User { get; set; }
    }
}
