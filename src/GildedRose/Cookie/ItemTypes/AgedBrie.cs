namespace GildedRose.Cookie.ItemTypes
{
    public class AgedBrie : StandardItem, IQualityItem
    {
        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {}

        public override void AgeByOneDay()
        {
            IncreaseQualityBy(PastTheSellByDate ? 2 : 1);
            ReduceSellInByOne();
        }
    }
}