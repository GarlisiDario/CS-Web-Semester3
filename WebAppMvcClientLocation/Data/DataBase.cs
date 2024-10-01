using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Data
{
    public static class DataBase
    {
        public static List<Client> Clients { get; set; }
        public static List<Location> Locations { get; set; }
        public static InsertResult AddClient(Client c)
        {
            InsertResult result = new InsertResult();
            Clients.Add(c);
            result.Succeeded = true;
            return result;
        }
        public static InsertResult AddLocation(Location l)
        {
            InsertResult result = new InsertResult();
            Locations.Add(l);
            result.Succeeded = true;
            return result;
        }


        public static void StartDataBase()
        {
            Clients = new List<Client>();
            Locations = new List<Location>();   
            Clients.Add(new Client(1,1,"Dario"));
            Clients.Add(new Client(2, 2, "Wille"));
            Locations.Add(new Location(1, "3630", "Maasmechelen"));
            Locations.Add(new Location(2, "3660", "Genk"));

        }
    }
}
