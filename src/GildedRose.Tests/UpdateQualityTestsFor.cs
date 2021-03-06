using Xunit;
using GildedRose.UpdateQuality;

namespace GildedRose.Tests
{
   public abstract class UpdateQualityTestsFor<T> where T : IUpdateQuality, new()
   {
      private Item[] Act(params Item[] items)
      {
         var testSubject = new T();
         testSubject.Update(items);
         return items;
      }

      [Theory]
      [InlineData(1, 1, 0, 0)]
      [InlineData(3, 2, 2, 1)]
      [InlineData(5, 3, 4, 2)]
      [InlineData(7, 4, 6, 3)]
      public void lower_both_values_by_one(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData(2, 0, 0, -1)]
      [InlineData(3, 0, 1, -1)]
      [InlineData(4, -1, 2, -2)]
      public void quality_degrades_twice_as_fast_once_sell_by_date_has_passed(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData(0, 0, 0, -1)]
      [InlineData(1, 0, 0, -1)]
      [InlineData(2, -1, 0, -2)]
      [InlineData(0, 1, 0, 0)]
      [InlineData(1, 1, 0, 0)]
      public void quality_of_an_item_is_never_negative(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData(0, 2, 1, 1)]
      [InlineData(0, 1, 1, 0)]
      [InlineData(0, 0, 2, -1)] // Appears to increases twice as fast
      [InlineData(0, -1, 2, -2)] // Appears to increases twice as fast
      [InlineData(1, 2, 2, 1)]
      [InlineData(1, 1, 2, 0)]
      [InlineData(1, 0, 3, -1)] // Appears to increases twice as fast
      [InlineData(1, -1, 3, -2)] // Appears to increases twice as fast
      [InlineData(0, 15, 1, 14)]
      [InlineData(0, -15, 2, -16)] // Appears to increases twice as fast
      public void aged_brie_increases_in_quality_the_older_it_gets(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Name = "Aged Brie", Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData("Aged Brie", 50, 0, 50, -1)]
      [InlineData("Aged Brie", 49, 0, 50, -1)]
      [InlineData("Aged Brie", 48, 0, 50, -1)]
      [InlineData("Aged Brie", 50, 10, 50, 9)]
      [InlineData("Aged Brie", 49, 10, 50, 9)]
      [InlineData("Backstage passes to a TAFKAL80ETC concert", 50, 1, 50, 0)]
      public void quality_of_an_item_is_never_more_than_fifty(string name, int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Name = name, Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData(80, 0, 80, 0)]
      [InlineData(80, 1, 80, 1)]
      [InlineData(80, -1, 80, -1)]
      public void sulfuras_never_has_to_be_sold_and_never_decreases_in_quality(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Name = "Sulfuras, Hand of Ragnaros", Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Theory]
      [InlineData(0, 11, 1, 10)]
      [InlineData(0, 10, 2, 9)]
      [InlineData(0, 6, 2, 5)]
      [InlineData(0, 5, 3, 4)]
      [InlineData(0, 1, 3, 0)]
      [InlineData(1, 1, 4, 0)]
      [InlineData(0, 0, 0, -1)]
      public void backstage_passes_increases_in_quality_as_sell_by_date_approaches_but_is_zero_after(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }

      [Fact]
      public void should_lower_values_of_multiple_items()
      {
         var item1 = new Item { Quality = 5, SellIn = 7 };
         var item2 = new Item { Quality = 3, SellIn = 11 };

         var result = Act(item1, item2);

         Assert.Equal(4, result[0].Quality);
         Assert.Equal(6, result[0].SellIn);
         Assert.Equal(2, result[1].Quality);
         Assert.Equal(10, result[1].SellIn);
      }

      [Theory]
      [InlineData(0, 0, 0, -1)]
      [InlineData(1, 0, 0, -1)]
      [InlineData(4, 0, 0, -1)]
      [InlineData(5, 0, 1, -1)]
      [InlineData(0, -1, 0, -2)]
      [InlineData(0, 1, 0, 0)]
      [InlineData(1, 1, 0, 0)]
      [InlineData(2, 1, 0, 0)]
      [InlineData(3, 1, 1, 0)]
      [InlineData(4, 1, 2, 0)]
      [InlineData(5, 1, 3, 0)]
      [InlineData(5, 2, 3, 1)]
      public void conjured_items_degrade_in_quality_twice_as_fast(int quality, int sellIn, int expectedQuality, int expectedSellIn)
      {
         if (typeof(T) == typeof(OriginalUpdateQuality))
         {
            return;
         }

         var item = new Item { Name = "Conjured", Quality = quality, SellIn = sellIn };

         var result = Act(item);

         Assert.Equal(expectedQuality, result[0].Quality);
         Assert.Equal(expectedSellIn, result[0].SellIn);
      }
   }
}
