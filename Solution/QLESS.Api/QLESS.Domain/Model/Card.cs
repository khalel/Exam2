using System;
using System.ComponentModel.DataAnnotations;

namespace QLESS.Domain.Model
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string SerialNumber { get; set; } // Using Guid to simulate a serial number
        [Required]
        public int CardRegTypeId { get; set; } = 1; // Default to Regular
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUsed { get; set; }
        [Required]
        public decimal CardLoad { get; set; } = 100;
        [StringLength(60)]
        public string FirstName { get; set; }
        [StringLength(60)]
        public string LastName { get; set; }
        [StringLength(60)]
        public string MiddleName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
