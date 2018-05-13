namespace GildedRose.Cookie
{
    public struct Quality
    {
        private readonly int _minimum;
        private readonly int _maximum;

        public Quality(int value = 0, int min = 0, int max = 50)
        {
            _minimum = min;
            _maximum = max;

            if (value <= _minimum)
            {
                Value = _minimum;
            }
            else if (value >= _maximum)
            {
                Value = _maximum;
            }
            else
            {
                Value = value;
            }
        }

        private int Value { get; }

        public Quality SetToMinimum() => new Quality(_minimum);

        public Quality DecreaseBy(int amountToDecrease) => new Quality(Value - amountToDecrease);

        public Quality IncreaseBy(int increaseInQuality) => new Quality(Value + increaseInQuality);

        public static implicit operator int(Quality quality)
        {
            return quality.Value;
        }

        public static implicit operator Quality(int quality)
        {
            return new Quality(quality);
        }

        //public static explicit operator Quality(int quality)
        //{
        //    return new Quality(quality);
        //}
    }
}