namespace QLESS.Contract.Model
{
    public class CardRegType
    {
        public int Id { get; set; }
        public string CardRegTypeDesc { get; set; }
        public string CardRegTypeFormat { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal DailyAdditionalDiscount { get; set; } = 0;
        public int MaxDailyAdditionalDiscount { get; set; } = 0;
    }
}
