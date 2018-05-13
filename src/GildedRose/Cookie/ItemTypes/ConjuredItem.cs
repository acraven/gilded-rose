namespace GildedRose.Cookie.ItemTypes
{
    public class ConjuredItem : StandardItem, IQualityItem
    {
        private const int RateOfDecayMultiplier = 2;

        public ConjuredItem(string name, int sellIn, int quality) 
            : base(name, sellIn, quality, RateOfDecay(), ExpiredRateOfDacay())
        {}

        private static int ExpiredRateOfDacay() => DefaultRateOfDecayWhenExpired * RateOfDecayMultiplier;

        private static int RateOfDecay() => DefaultRateOfDecayWhenInDate * RateOfDecayMultiplier;
    }
}