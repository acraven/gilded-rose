namespace GildedRose.Cookie.ItemTypes
{
    public class SulfurasItem : IQualityItem
    {
        private readonly Quality _quality;
        private readonly SellIn _sellIn;

        public SulfurasItem(string name, int sellIn, int quality)
        {
            _quality = SulfurasQuality(quality);
            _sellIn = sellIn;
            Name = name;
        }

        private static Quality SulfurasQuality(int quality)
        {
            return new Quality(quality, quality, quality);
        }

        public IQualityItem UpdateQuality()
        {
            //do nothing...on purpose!
            return this;
        }

        public IQualityItem ReduceSellIn()
        {
            //do nothing...on purpose!
            return this;
        }

        public string Name { get; }

        public int Quality => _quality;

        public int SellIn => _sellIn;
    }
}