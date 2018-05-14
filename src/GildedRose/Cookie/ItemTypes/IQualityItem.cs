namespace GildedRose.Cookie.ItemTypes
{
    public interface IQualityItem
    {
        string Name { get;  }

        int SellIn { get; }

        int Quality { get; }

        IQualityItem UpdateQuality();

        IQualityItem ReduceSellIn();
    }
}