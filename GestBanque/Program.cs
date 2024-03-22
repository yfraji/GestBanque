using Models;

namespace GestBanque;

class Program
{
    static void Main(string[] args)
    {
        Banque banque = new Banque()
        {
            Nom = "My favorite bank"
        };

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

        banque.Ajouter(courant);
        
        banque["0001"]?.Depot(-100);
        Console.WriteLine($"Depot de -100 : {banque["0001"]?.Solde}");
        banque["0001"]?.Depot(100);
        Console.WriteLine($"Depot de 100 : {banque["0001"]?.Solde}");
        banque["0001"]?.Retrait(-100);
        Console.WriteLine($"Retrait de -100 : {banque["0001"]?.Solde}");
        banque["0001"]?.Retrait(100);
        Console.WriteLine($"Retrait de 100 : {banque["0001"]?.Solde}");
        banque["0001"]?.Retrait(600);
        Console.WriteLine($"Retrait de 600 : {banque["0001"]?.Solde}");

        banque.Supprimer("0001");

        Console.WriteLine(banque["0001"] is null);
    }
}