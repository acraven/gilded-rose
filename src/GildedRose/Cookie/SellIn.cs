namespace GildedRose.Cookie
{
    public struct SellIn
    {
        private readonly int _value;

        public SellIn(int value)
        {
            _value = value;
        }

        public SellIn AgeByOneDay() => new SellIn(_value - 1);

        public bool SellByDateWithin(int days) => _value <= days;

        public bool PastTheSellByDate => _value <= 0;

        public static implicit operator int(SellIn sellin)
        {
            return sellin._value;
        }

        public static implicit operator SellIn(int value)
        {
            return new SellIn(value);
        }
    }
}