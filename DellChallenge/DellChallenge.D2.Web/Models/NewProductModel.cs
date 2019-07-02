using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required(ErrorMessage = "Please enter the name.")]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
