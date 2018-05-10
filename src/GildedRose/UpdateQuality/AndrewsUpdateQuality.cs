using System;
using System.Collections.Generic;

namespace GildedRose.UpdateQuality
{
   public interface IUpdateBehaviour
   {
      (int, int) Update(int quality, int sellIn);
   }

   public class DepreciatingUpdateBehaviour : IUpdateBehaviour
   {
      private readonly int _rate;

      public DepreciatingUpdateBehaviour(int rate = 1)

      {
         _rate = rate;
      }

      public (int, int) Update(int quality, int sellIn)
      {
         var depreciation = sellIn <= 0 ? (_rate * 2) : _rate;

         return (Math.Max(quality - depreciation, 0), sellIn - 1);
      }
   }

   public class LinearAppreciatingUpdateBehaviour : IUpdateBehaviour
   {
      public (int, int) Update(int quality, int sellIn)
      {
         var appreciation = sellIn <= 0 ? 2 : 1;

         return (Math.Min(quality + appreciation, 50), sellIn - 1);
      }
   }

   public class ExpontialAppreciatingUpdateBehaviour : IUpdateBehaviour
   {
      public (int, int) Update(int quality, int sellIn)
      {
         int appreciation;

         if (sellIn > 10)
         {
            appreciation = 1;
         } else if (sellIn > 5)
         {
            appreciation = 2;
         }
         else if (sellIn > 0)
         {
            appreciation = 3;
         }
         else
         {
            appreciation = -quality;
         }

         return (Math.Min(quality + appreciation, 50), sellIn - 1);
      }
   }

   public class LegendaryUpdateBehaviour : IUpdateBehaviour
   {
      public (int, int) Update(int quality, int sellIn)
      {
         return (quality, sellIn);
      }
   }

   public class AndrewsUpdateQuality : IUpdateQuality
   {
      private IUpdateBehaviour GetUpdateBehaviour(Item item)
      {
         if (item.Name == "Sulfuras, Hand of Ragnaros")
         {
            return new LegendaryUpdateBehaviour();
         }
         if (item.Name == "Aged Brie")
         {
            return new LinearAppreciatingUpdateBehaviour();
         }
         if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
         {
            return new ExpontialAppreciatingUpdateBehaviour();
         }
         if (item.Name == "Conjured")
         {
            return new DepreciatingUpdateBehaviour(rate: 2);
         }
         return new DepreciatingUpdateBehaviour();
      }

      public void Update(IList<Item> items)
      {
         for (var i = 0; i < items.Count; i++)
         {
            var updateBehaviour = GetUpdateBehaviour(items[i]);

            var (newQuality, newSellIn) = updateBehaviour.Update(items[i].Quality, items[i].SellIn);

            items[i].SellIn = newSellIn;
            items[i].Quality = newQuality;
         }
      }
   }
}
