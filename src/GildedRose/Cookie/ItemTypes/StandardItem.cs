namespace GildedRose.Cookie.ItemTypes
{
    public class StandardItem : IQualityItem
    {
        private SellIn _sellIn;
        private Quality _quality;
        protected const int DefaultRateOfDecayWhenInDate = 1;
        protected const int DefaultRateOfDecayWhenExpired = 2;

        public StandardItem(string name, int sellIn, Quality quality, 
            int rateOfDecayWhenInDate = DefaultRateOfDecayWhenInDate, 
            int rateOfDacayWhenExpired = DefaultRateOfDecayWhenExpired)
        {
            Name = name;
            _sellIn = sellIn;
            _quality = quality;
            RateOfDecayWhenInDate = rateOfDecayWhenInDate;
            RateOfDecayWhenExpired = rateOfDacayWhenExpired;
        }

        public virtual void AgeByOneDay()
        {
            DecreaseQualityBy(RateOfDecay);
            ReduceSellIn();
        }

        protected void SetQualityToMinimum() => _quality = _quality.SetToMinimum();

        protected void DecreaseQualityBy(int amount) => _quality = _quality.DecreaseBy(amount);

        protected void IncreaseQualityBy(int amount) => _quality = _quality.IncreaseBy(amount);

        protected void ReduceSellIn() => _sellIn = _sellIn.AgeByOneDay();

        protected bool SellByDateWithin(int days) => _sellIn.SellByDateWithin(days);

        private int RateOfDecay => PastTheSellByDate ? RateOfDecayWhenExpired : RateOfDecayWhenInDate;

        public string Name { get; }

        public int SellIn => _sellIn;

        public int Quality
        {
            get => _quality;
            set => _quality = value;
        }

        protected int RateOfDecayWhenInDate { get; }

        protected int RateOfDecayWhenExpired { get; }

        protected bool PastTheSellByDate => _sellIn.PastTheSellByDate;
    }
}