namespace WebAppMvcClientLocation.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int LocatieId { get; set; }
        public string ClientName { get; set; }
        public Client(int clientId,int locatieId, string clientName)
        {
            ClientId = clientId;
            ClientName = clientName;
            LocatieId = locatieId;
        }
    }
}
