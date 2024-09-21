using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebAppClient.Pages
{
    public class LocatieDetailsModel : PageModel
    {
        public int LocatieId { get; set; } 
        public void OnGet(int id)
        {
            LocatieId = id;
        }
    }
}
