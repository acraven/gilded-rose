using System;
using System.Collections.Generic;
using GildedRose.Cookie;

namespace GildedRose.UpdateQuality
{
    public class CookiesMethod : IUpdateQuality
    {
        public void Update(IList<Item> items)
        {
//            for (var x = 0; x <= 10; x++)
//            {
                for (var i = 0; i < items.Count; i++)
                {
                    var qualityItem = items[i].ToQualityItem();
                    qualityItem.AgeByOneDay();

                    items[i] = qualityItem.ToItem();

                    Console.WriteLine(
                        $"{qualityItem.Name}, SellIn: {qualityItem.SellIn}, Quality:{qualityItem.Quality}");
                }
//            }
        }
    }
}