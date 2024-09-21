using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebAppClient.Pages
{
    public class NieuweKlantModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var selectedLocatie = Request.Form["SelectLocatie"];
            int locatieId = int.Parse(selectedLocatie);
            string userName = Request.Form["UserName"];
            Data.Databank.AddKlant(userName, locatieId);
            return RedirectToPage("KlantLocatieOverzicht");

        }
    }
}
