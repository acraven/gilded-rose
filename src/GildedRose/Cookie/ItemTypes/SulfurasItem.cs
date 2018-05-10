namespace GildedRose.Cookie.ItemTypes
{
    public class SulfurasItem : IQualityItem
    {
        private const int FixedQuality = 80;
        private const int FixedSellInValue = 0;

        public SulfurasItem(string name, int sellIn = FixedSellInValue, int quality = FixedQuality) 
        {
            Name = name;
        }

        public void AgeByOneDay()
        {
            //do nothing...on purpose!
        }

        public Item ToItem()
        {
            return new Item {Name = Name, Quality = Quality, SellIn = SellIn};
        }

        public string Name { get; }

        public int SellIn => FixedSellInValue;

        public int Quality => FixedQuality;
    }
}