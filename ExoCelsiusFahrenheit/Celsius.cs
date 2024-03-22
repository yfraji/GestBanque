namespace ExoCelsiusFahrenheit
{
    public struct Celsius
    {
        public double Température { get; set; }

        public static implicit operator Fahrenheit(Celsius value)
        {
            return new Fahrenheit() {Température = 1.8 * value.Température + 32.0 };
        }
    }
}
