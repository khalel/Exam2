using System;

namespace QLESS.Contract.Model
{
    public class CardLoadHist
    {
        public Guid CardLoadRef { get; set; }
        public int CardId { get; set; }
        public DateTime CardLoadDate { get; set; }
        public decimal CardLoadFr { get; set; }
        public decimal CardLoadTo { get; set; }
        public decimal Fare { get; set; } = 0;
        public decimal FareDiscount { get; set; } = 0;
        public decimal FareDailyAdditionalDiscount { get; set; } = 0;
    }
}
