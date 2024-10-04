using System.ComponentModel.DataAnnotations;

namespace WebAppMVCClientLocationEFCore.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [MaxLength(15)][Required]
        public string? Postcode { get; set; }
        [MaxLength(100)][Required]
        public string? City { get; set; }
       

    }
}
