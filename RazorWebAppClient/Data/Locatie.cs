namespace RazorWebAppClient.Data
{
    public class Locatie
    {
        
        public Locatie(int locatieId, string postCode, string gemeente)
        {
            LocatieId = locatieId;
            PostCode = postCode;
            Gemeente = gemeente;
        }

        public int LocatieId { get; set; }
        public string PostCode { get; set; }
        public string Gemeente { get; set; }
    }
}
