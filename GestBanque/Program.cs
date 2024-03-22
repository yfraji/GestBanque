using Models;

namespace GestBanque;

class Program
{
    static void Main(string[] args)
    {
        Personne doeJohn = new Personne()
        {
            Nom = "Doe",
            Prenom = "John",
            DateNaiss = new DateTime(1970, 1, 1)
        };

        Courant courant = new Courant()
        {
            Numero = "0001",
            LigneDeCredit = 500,
            Titulaire = doeJohn
        };

        courant.Depot(-100);
        Console.WriteLine($"Depot de -100 : {courant.Solde}");
        courant.Depot(100);
        Console.WriteLine($"Depot de 100 : {courant.Solde}");
        courant.Retrait(-100);
        Console.WriteLine($"Retrait de -100 : {courant.Solde}");
        courant.Retrait(100);
        Console.WriteLine($"Retrait de 100 : {courant.Solde}");
        courant.Retrait(600);
        Console.WriteLine($"Retrait de 600 : {courant.Solde}");
    }
}