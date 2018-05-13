using GildedRose.Cookie;
using Xunit;

namespace GildedRose.Tests
{
    public class QualityTests
    {
        [Fact]
        public void ShouldImplicitlyConvertFromQualityToInt()
        {
            var quality = new Quality(2);

            Assert.Equal<int>(2, quality);
        }

        [Fact]
        public void ShouldImplicitlyConvertionFromInToQuality()
        {
            Quality q = 2;

            Assert.Equal<Quality>(2, q);
        }
    }
}