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

        Courant courantJD1 = new Courant()
        {
            Numero = "0001",
            LigneDeCredit = 500,
            Titulaire = doeJohn
        };

        Courant courantJD2 = new Courant()
        {
            Numero = "0002",
            LigneDeCredit = 500,
            Titulaire = doeJohn
        };

        Courant courantJD3 = new Courant()
        {
            Numero = "0003",
            LigneDeCredit = 500,
            Titulaire = doeJohn
        };
        Epargne epargneJD1 = new Epargne()
        { 
            Numero = "0004",
            Titulaire = doeJohn
        };

        banque.Ajouter(courantJD1);
        banque.Ajouter(courantJD2);
        banque.Ajouter(courantJD3);
        
        banque["0001"]?.Depot(1000);
        Console.WriteLine($"Depot de 1000 : {banque["0001"]?.Solde}");
        banque["0002"]?.Depot(1000);
        Console.WriteLine($"Depot de 100 : {banque["0002"]?.Solde}");
        banque["0003"]?.Retrait(300);
        Console.WriteLine($"Retrait de 400 : {banque["0003"]?.Solde}");

        Console.WriteLine($"Avoir des comptes de {doeJohn.Prenom} : {banque.AvoirDesComptes(doeJohn)}");

        banque.Supprimer("0001");
        banque.Supprimer("0002");
        banque.Supprimer("0003");

        Console.WriteLine(banque["0001"] is null);
        Console.WriteLine(banque["0002"] is null);
        Console.WriteLine(banque["0003"] is null);
    }
}