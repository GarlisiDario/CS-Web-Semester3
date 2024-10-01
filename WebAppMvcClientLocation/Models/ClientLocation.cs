
namespace WebAppMvcClientLocation.Models
{
    public class ClientLocation
    {
       private List<ClientLocation> clientLocation = new List<ClientLocation>();
       public IEnumerable<ClientLocation> Overview()
        {
            return clientLocation;
        }
        
        public string ClientName { get; set; }
        public string City { get; set; }
    }
}
