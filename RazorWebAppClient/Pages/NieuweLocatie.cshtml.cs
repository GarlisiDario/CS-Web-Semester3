using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebAppClient.Pages
{
    public class NieuweLocatieModel : PageModel
    {
        public IActionResult OnPost()
        {
            string postCode = Request.Form["PostCode"];
            string city = Request.Form["Gemeente"];
            Data.Databank.AddLocation(postCode, city);
            return RedirectToPage("Locaties");


        }
        public void OnGet()
        {
        }
    }
}
