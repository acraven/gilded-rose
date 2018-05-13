namespace GildedRose.Cookie.ItemTypes
{
    public class SulfurasItem : StandardItem, IQualityItem
    {
        public SulfurasItem(string name, int sellIn, int quality) 
            : base(name, sellIn, SulfurasQuality(quality))
        {}

        private static Quality SulfurasQuality(int quality)
        {
            return new Quality(quality, quality, quality);
        }

        public override void AgeByOneDay()
        {
//            do nothing...on purpose!
        }
    }
}