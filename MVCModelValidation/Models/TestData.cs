using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MVCModelValidation.Models
{

    public class TestData
    {
        public int? TestDataId { get; set; }
        [Required]
        [StringLength(10)]
        public string? TestText { get; set; }
        //[CustomData]
        public DateTime? TestDate {  get; set; }
    }
}
