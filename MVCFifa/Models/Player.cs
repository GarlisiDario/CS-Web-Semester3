using System.ComponentModel.DataAnnotations;

namespace MVCFifa.Models
{
    public class Player
    {
        public int? PlayerId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? ImageLink { get; set; }
    }
}
