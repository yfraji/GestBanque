namespace ExoCelsiusFahrenheit
{
    public struct Fahrenheit
    {
        public double Température { get; set; }

        public static explicit operator Celsius(Fahrenheit value)
        {
            return new Celsius() { Température = (value.Température - 32.0) / 1.8 };
        }
    }
}
