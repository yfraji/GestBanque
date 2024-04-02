namespace ExoDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carwash carwash = new Carwash();
            Voiture voiture = new Voiture("1-AAA-111");
            Voiture voiture2 = new Voiture("2-BBB-222");
            carwash.Traiter(voiture);
            carwash._delegate(voiture, voiture2);
        }
    }
}
