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
                    SetQualityToZero();
                }
                else
                {
                    IncreaseQualityBy(SellByDateWithin(FiveDays) ? 3 : 2);
                }

                ReduceSellInByOne();
            }
            else
            {
                base.AgeByOneDay();
            }
        }
    }
}