namespace GildedRose.Cookie.ItemTypes
{
    public class StandardItem : IQualityItem
    {
        private readonly SellIn _sellIn;
        private readonly Quality _quality;
        protected const int DefaultRateOfDecayWhenInDate = 1;
        protected const int DefaultRateOfDecayWhenExpired = 2;

        public StandardItem(string name, int sellIn, int quality, 
            int rateOfDecayWhenInDate = DefaultRateOfDecayWhenInDate, 
            int rateOfDacayWhenExpired = DefaultRateOfDecayWhenExpired)
        {
            Name = name;
            _sellIn = sellIn;
            _quality = quality;
            RateOfDecayWhenInDate = rateOfDecayWhenInDate;
            RateOfDecayWhenExpired = rateOfDacayWhenExpired;
        }

        public virtual IQualityItem UpdateQuality()
        {
            return DecreaseQualityBy(RateOfDecay);
        }

        protected IQualityItem SetQualityToMinimum() => new StandardItem(Name, _sellIn, _quality.SetToMinimum(), rateOfDecayWhenInDate: RateOfDecayWhenInDate, rateOfDacayWhenExpired: RateOfDecayWhenExpired);

        protected IQualityItem DecreaseQualityBy(int amount) => new StandardItem(Name, _sellIn, _quality.DecreaseBy(amount), RateOfDecayWhenInDate, RateOfDecayWhenExpired);

        protected IQualityItem IncreaseQualityBy(int amount) => new StandardItem(Name, _sellIn, _quality.IncreaseBy(amount), RateOfDecayWhenInDate, RateOfDecayWhenExpired);

        public IQualityItem ReduceSellIn() => new StandardItem(Name, _sellIn.AgeByOneDay(), Quality, RateOfDecayWhenInDate, RateOfDecayWhenExpired);

        protected bool SellByDateWithin(int days) => _sellIn.SellByDateWithin(days);

        private int RateOfDecay => PastTheSellByDate ? RateOfDecayWhenExpired : RateOfDecayWhenInDate;

        public string Name { get; }

        public int SellIn => _sellIn;

        public int Quality => _quality;

        protected int RateOfDecayWhenInDate { get; }

        protected int RateOfDecayWhenExpired { get; }

        protected bool PastTheSellByDate => _sellIn.PastTheSellByDate;
    }
}