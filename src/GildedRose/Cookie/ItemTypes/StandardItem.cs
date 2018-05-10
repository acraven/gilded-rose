namespace GildedRose.Cookie.ItemTypes
{
    public class StandardItem : IQualityItem
    {
        private const int MinimumQuality = 0;
        private const int MaximumQuality = 50;
        protected const int StandardRateOfQualityReductionWhenInDate = 1;
        protected const int StandardRateOfQualityReductionWhenOutOfDate = 2;
        private int _quality;

        public StandardItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public virtual void AgeByOneDay()
        {
            DecreaseQualityBy(StandardDegregationAmount);
            ReduceSellInByOne();
        }

        private int StandardDegregationAmount
        {
            get
            {
                return PastTheSellByDate
                    ? StandardRateOfQualityReductionWhenOutOfDate
                    : StandardRateOfQualityReductionWhenInDate;
            }
        }

        public string Name { get; }

        public int SellIn { get; private set; }

        public int Quality
        {
            get => _quality;
            set
            {
                if (value <= MinimumQuality)
                {
                    _quality = MinimumQuality;
                }
                else if (value >= MaximumQuality)
                {
                    _quality = MaximumQuality;
                }
                else
                {
                    _quality = value;
                }
            }
        }

        public Item ToItem()
        {
            return new Item { Name = Name, Quality = Quality, SellIn = SellIn };
        }

        protected void SetQualityToZero() => Quality = MinimumQuality;

        protected bool SellByDateWithin(int days) => SellIn <= days;

        protected bool PastTheSellByDate => SellIn <= 0;

        protected void DecreaseQualityBy(int amountToDecrease) => Quality = Quality - amountToDecrease;

        protected void IncreaseQualityBy(int increaseInQuality) => Quality = Quality + increaseInQuality;

        protected void ReduceSellInByOne() => SellIn--;
    }
}