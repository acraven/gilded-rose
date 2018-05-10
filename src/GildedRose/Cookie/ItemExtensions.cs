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

        private const string AgedBrie = "aged brie";
        private const string BackstagePasses = "backstage";
        private const string Conjured = "conjured";
        private const string Sulfuras = "sulfuras";

        public static IQualityItem ToQualityItem(this Item item)
        {
            var (name, sellIn, quality) = item;

            if (NameStartsWith(name, AgedBrie))
                return new AgedBrie(name, sellIn, quality);

            if (NameStartsWith(name, Conjured))
                return new ConjuredItem(name, sellIn, quality);

            if (NameStartsWith(name, Sulfuras))
                return new SulfurasItem(name, sellIn, quality);

            if (NameStartsWith(name, BackstagePasses))
                return new BackstagePass(name, sellIn, quality);

            return new StandardItem(name, sellIn, quality);
        }

        private static bool NameStartsWith(string name, string stringToFind)
        {
            return name.StartsWith(stringToFind, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}