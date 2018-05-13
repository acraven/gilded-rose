namespace GildedRose.Cookie.ItemTypes
{
    public class BackstagePass : StandardItem, IQualityItem
    {
        private const int FiveDays = 5;
        private const int TenDays = 10;

        public BackstagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {}

        public override void AgeByOneDay()
        {
            if (SellByDateWithin(TenDays))
            {
                if (PastTheSellByDate)
                {
                    SetQualityToMinimum();
                }
                else
                {
                    IncreaseQualityBy(QualityIncreaseRate());
                }
            }
            else
            {
                IncreaseQualityBy(1);
            }

            ReduceSellIn();
        }

        private int QualityIncreaseRate()
        {
            return SellByDateWithin(FiveDays) ? 3 : 2;
        }
    }
}