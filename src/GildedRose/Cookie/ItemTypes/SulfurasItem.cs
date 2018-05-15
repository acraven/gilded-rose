namespace GildedRose.Cookie.ItemTypes
{
    public class SulfurasItem : IQualityItem
    {
        private readonly SellIn _sellIn;

        public SulfurasItem(string name, int sellIn, int quality)
        {
            Quality = quality;
            _sellIn = sellIn;
            Name = name;
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

        public int Quality { get; }

        public int SellIn => _sellIn;
    }
}