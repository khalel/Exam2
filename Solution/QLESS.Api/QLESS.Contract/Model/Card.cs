using System;

namespace QLESS.Contract.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public int CardRegTypeId { get; set; } = 1; // Default to Regular
        public DateTime PurchaseDate { get; set; }
        public DateTime LastUsed { get; set; }
        public decimal CardLoad { get; set; } = 100;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
