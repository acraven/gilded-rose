using System.Collections.Generic;

namespace GildedRose.UpdateQuality
{
    public interface IUpdateQuality
    {
        void Update(IList<Item> items);
    }
}
