namespace ExoCelsiusFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            Celsius celsius = new Celsius()
            {
                Température = 15.0
            };
            Fahrenheit fahrenheit = new Fahrenheit()
            {
                Température = 59.0
            };
            Fahrenheit celsiusToFahrenheit = celsius;
            Console.WriteLine(celsius.Température + "°C = " + celsiusToFahrenheit.Température + "°F");

            Celsius fahrenheitToCelsius = (Celsius)fahrenheit;
            Console.WriteLine(fahrenheit.Température + "°F = " + fahrenheitToCelsius.Température + "°C");
        }
    }
}
