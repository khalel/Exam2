using System;
using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    public class CardLoadHist
    {
        [Key]
        public Guid CardLoadRef { get; set; }
        [Required]
        public int CardId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CardLoadDate { get; set; }
        [Required]
        public decimal CardLoadFr { get; set; }
        [Required]
        public decimal CardLoadTo { get; set; }
        [Required]
        public decimal Fare { get; set; } = 0;
        [Required]
        public decimal FareDiscount { get; set; } = 0;
        [Required]
        public decimal FareDailyAdditionalDiscount { get; set; } = 0;
    }
}
