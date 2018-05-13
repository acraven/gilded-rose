namespace GildedRose.Cookie.ItemTypes
{
    public interface IQualityItem
    {
        string Name { get;  }

        int SellIn { get; }

        int Quality { get; }

        void AgeByOneDay();
    }
}