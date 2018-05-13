namespace GildedRose.Cookie.ItemTypes
{
    public class AgedBrie : StandardItem, IQualityItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {}

        public override void AgeByOneDay()
        {
            IncreaseQualityBy(QualityIncreaseRate());
            ReduceSellIn();
        }

        private int QualityIncreaseRate()
        {
            return PastTheSellByDate ? 2 : 1;
        }
    }
}