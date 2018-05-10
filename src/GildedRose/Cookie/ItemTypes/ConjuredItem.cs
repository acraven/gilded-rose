namespace GildedRose.Cookie.ItemTypes
{
    public class ConjuredItem : StandardItem, IQualityItem
    {
        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        { }

        public override void AgeByOneDay()
        {
            DecreaseQualityBy(TwiceTheStandardDegregationAmount);
            ReduceSellInByOne();
        }

        private int TwiceTheStandardDegregationAmount
        {
            get
            {
                return (PastTheSellByDate
                           ? StandardRateOfQualityReductionWhenOutOfDate
                           : StandardRateOfQualityReductionWhenInDate) * 2;
            }
        }
    }
}