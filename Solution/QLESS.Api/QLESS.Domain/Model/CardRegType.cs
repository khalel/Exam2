using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    public class CardRegType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string CardRegTypeDesc { get; set; }
        [Required]
        [StringLength(60)]
        public string CardRegTypeFormat { get; set; }
        [Required]
        public decimal Discount { get; set; } = 0;
        [Required]
        public decimal DailyAdditionalDiscount { get; set; } = 0;
        [Required]
        public int MaxDailyAdditionalDiscount { get; set; } = 0;
    }
}
