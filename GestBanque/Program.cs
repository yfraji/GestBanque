using Models;
using System.Linq.Expressions;

namespace GestBanque;

class Program
{
    static void Main(string[] args)
    {
        Banque banque = new Banque("My favorite bank");
        Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
        Compte courantJD1 = new Courant("0001", 500, doeJohn);
        Compte courantJD2 = new Courant("0002", 500, doeJohn);
        Compte courantJD3 = new Courant("0003", 500, doeJohn);
        Compte epargneJD1 = new Epargne("0004", doeJohn);

        banque.Ajouter(courantJD1);
        if (banque["0001"] is Courant c1)
        {
            try
            {
                c.LigneDeCredit = -500;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        banque.Ajouter(courantJD2);
        if (banque["0002"] is Courant c2)
        {
            try
            {
                c.LigneDeCredit = -500;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        banque.Ajouter(courantJD3);
        if (banque["0003"] is Courant c3)
        {
            try
            {
                c.LigneDeCredit = -500;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        banque.Ajouter(epargneJD1);
        if (banque["0004"] is Courant c4)
        {
            try
            {
                c.LigneDeCredit = -500;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        try
        {
            banque["0001"]?.Depot(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Courant 1 de JD, Depot de 1000 : {banque["0001"]?.Solde}");
        try
        {
            banque["0002"]?.Depot(1000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Courant 2 de JD, Depot de 1000 : {banque["0002"]?.Solde}");
        try
        {
            banque["0003"]?.Retrait(300);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Courant 3 de JD, Retrait de 300 : {banque["0003"]?.Solde}");
        try
        {
            banque["0004"]?.Depot(1500);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Epargne 1 de JD, Depot de 1500 : {banque["0004"]?.Solde}");
        try
        {
            banque["0004"]?.Retrait(5000);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine($"Epargne 1 de JD, Retrait de 5000 : {banque["0004"]?.Solde}, Date de dernier retrait : {((Epargne)banque["0004"]).DateDernierRetrait}");

        Console.WriteLine($"Avoir des comptes de {doeJohn.Prenom} : {banque.AvoirDesComptes(doeJohn)}");
         
        banque.Supprimer("0001");
        banque.Supprimer("0002");
        banque.Supprimer("0003");
        banque.Supprimer("0004");

        Console.WriteLine(banque["0001"] is null);
        Console.WriteLine(banque["0002"] is null);
        Console.WriteLine(banque["0003"] is null);
        Console.WriteLine(banque["0004"] is null);
    }
}