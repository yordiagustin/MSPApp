using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSPApp.Views;

namespace MSPApp.Models.Data
{
    public class Item
    {
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public bool IsAdmin { get; set; }
        public Type Page { get; set; }
    }

    public class ItemData
    {
        public ObservableCollection<Item> ItemsList { get; set; }
        public ItemData()
        {
            ItemsList = new ObservableCollection<Item>()
            {
                new Item() {Title="Home", IsAdmin = false, IconUrl="ic_home.png", Page= typeof(InitiativesPage)},
                //new Item() {Title="Perfil", IconUrl="ic_profile.png", Page= typeof(ProfilePage)},
                new Item() {Title="Find a MSP",IsAdmin = false, IconUrl="ic_msp.png", Page= typeof(FindPage)},
                new Item() {Title="Contributions",IsAdmin = false, IconUrl="ic_msp.png", Page= typeof(ContributionsPage)},
                //new Item() {Title="Eventos", IconUrl="ic_events.png", Page= typeof(EventsPage)},
                new Item() {Title="Add a Initiative", IsAdmin = true,IconUrl="ic_initiatives.png", Page= typeof(AddInitiativePage)},
                //new Item() {Title="Construye tu idea", IconUrl="ic_idea.png", Page= typeof(IdeaPage) },
                //new Item() {Title="Cerrar Sesión", IconUrl="ic_close.png", Page= null}
            };
        }
    }
}
