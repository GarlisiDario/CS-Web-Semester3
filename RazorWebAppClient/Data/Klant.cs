namespace RazorWebAppClient.Data
{
    public class Klant
    {
        public Klant()
        {
            KlantId = -1;
            KlantNaam = string.Empty;
        }
        public Klant(int id, string naam,int locatieId)
        {
            KlantId = id;
            KlantNaam = naam;
            LocatieId = locatieId;
        }
        public int KlantId { get; set; }
        public string KlantNaam { get; set; }
        public int LocatieId { get; set; }
        public bool GevalideerdeKlant => (KlantId > -1);
        
    }

}
