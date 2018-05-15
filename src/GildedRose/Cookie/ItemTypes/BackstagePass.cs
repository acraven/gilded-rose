namespace GildedRose.Cookie.ItemTypes
{
    public class BackstagePass : StandardItem, IQualityItem
    {
        private const int FiveDays = 5;
        private const int TenDays = 10;

        public BackstagePass(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {}

        public override IQualityItem UpdateQuality()
        {
            if (SellByDateWithin(TenDays))
            {
                if (PastTheSellByDate)
                {
                    return SetQualityToMinimum();
                }

                return IncreaseQualityBy(QualityAppriciation());
            }

            return IncreaseQualityBy(1);
        }

        private int QualityAppriciation()
        {
            return SellByDateWithin(FiveDays) ? 3 : 2;
        }
    }
}