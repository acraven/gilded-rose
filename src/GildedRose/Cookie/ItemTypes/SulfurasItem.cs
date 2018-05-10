namespace GildedRose.Cookie.ItemTypes
{
    public class SulfurasItem : IQualityItem
    {
        private const int FixedQuality = 80;

        public SulfurasItem(string name, int sellIn, int quality = FixedQuality) 
        {
            Name = name;
            SellIn = sellIn;
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

        public int SellIn { get; }

        public int Quality => FixedQuality;
    }
}