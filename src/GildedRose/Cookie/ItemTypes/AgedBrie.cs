namespace GildedRose.Cookie.ItemTypes
{
    public class AgedBrie : StandardItem, IQualityItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {}

        public override IQualityItem UpdateQuality()
        {
            return IncreaseQualityBy(QualityIncreaseRate());
        }
        
        private int QualityIncreaseRate()
        {
            return PastTheSellByDate ? 2 : 1;
        }
    }
}