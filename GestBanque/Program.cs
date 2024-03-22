﻿using Models;

namespace GestBanque;

class Program
{
    static void Main(string[] args)
    {
        Personne frajiYasser = new Personne()
        {
            Nom = "Fraji",
            Prenom = "Yasser",
            DateNaiss = new DateTime(2000, 8, 18)
        };

        Courant courant = new Courant()
        {
            Numero = "0001",
            LigneDeCredit = 500,
            Titulaire = frajiYasser
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