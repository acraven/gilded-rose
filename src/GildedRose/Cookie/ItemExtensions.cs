using System;
using GildedRose.Cookie.ItemTypes;

namespace GildedRose.Cookie
{
    public static class ItemExtensions
    {
        public static void Deconstruct(this Item item, out string name, out int sellIn, out int quality)
        {
            name = item.Name;
            sellIn = item.SellIn;
            quality = item.Quality;
        }

        public static IQualityItem ToQualityItem(this Item item)
        {
            var (name, sellIn, quality) = item;
            name = name ?? string.Empty;

            if (NameStartsWith(name, "aged brie"))
                return new AgedBrie(name, sellIn, quality);

            if (NameStartsWith(name, "conjured"))
                return new ConjuredItem(name, sellIn, quality);

            if (NameStartsWith(name, "sulfuras"))
                return new SulfurasItem(name, sellIn, quality);

            if (NameStartsWith(name, "backstage"))
                return new BackstagePass(name, sellIn, quality);

            return new StandardItem(name, sellIn, quality);
        }

        private static bool NameStartsWith(string name, string stringToFind)
        {
            return name.StartsWith(stringToFind, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}