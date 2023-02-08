
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate_Tracker.Models
{
    public class Estate
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; } = string.Empty;

        [Display(Name = "Date Listed Online")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Type of Estate")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Type_of_Estate { get; set; }

        [Range(1, 10000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
