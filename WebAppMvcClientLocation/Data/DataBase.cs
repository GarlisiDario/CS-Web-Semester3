using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Data
{
    public class DataBase
    {
        public static List<Client> Clients { get; set; }
        public static List<Location> Locations { get; set; }

        public void StartDataBase()
        {
            Clients.Add(new Client(1,1,"Dario"));
            Clients.Add(new Client(2, 2, "Wille"));
            Locations.Add(new Location(1, "3630", "Maasmechelen"));
            Locations.Add(new Location(2, "3660", "Genk"));

        }
    }
}
