using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace MSPApp.Models
{
    public class UserDB : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string MobileId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public string WebsiteUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string ProfileUrl { get; set; }
        public string GithubUrl { get; set; }
        public string BackgroundUrl { get; set; }
        public string FirstAwarded { get; set; }
        public int NumberOfAwards { get; set; }
    }
}
