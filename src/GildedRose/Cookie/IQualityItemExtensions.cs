using GildedRose.Cookie.ItemTypes;

namespace GildedRose.Cookie
{
    public static class QualityItemExtensions
    {
        public static Item ToItem(this IQualityItem qualityItem)
        {
            return new Item {Name = qualityItem.Name, Quality = qualityItem.Quality, SellIn = qualityItem.SellIn};
        }
    }
}