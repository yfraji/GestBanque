namespace ExoDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carwash carwash = new Carwash();
            Voiture voiture = new Voiture("1-AAA-111");
            carwash.Traiter(voiture);
        }
    }
}
