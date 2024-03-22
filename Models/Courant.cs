namespace Models;

public class Courant
{
    private string _numero;
    private double _solde;
    private double _ligneDeCredit;
    private Personne _titulaire;

    public string Numero
    {
        get
        {
            return _numero;
        }

        set
        {
            _numero = value;
        }
    }

    public double Solde
    {
        get
        {
            return _solde;
        }

        private set
        {
            _solde = value;
        }
    }

    public double LigneDeCredit
    {
        get
        {
            return _ligneDeCredit;
        }

        set
        {
            if (value < 0)
            {
                Console.WriteLine("La ligne de crédit est strictement positive..."); // => Erreur : Exception
                return;
            }
            _ligneDeCredit = value;
        }
    }

    public Personne Titulaire
    {
        get
        {
            return _titulaire;
        }

        set
        {
            _titulaire = value;
        }
    }

    public void Depot(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Dépot d'un montant négatif impossible"); // => Erreur : Exception
            return;
        }

        Solde += montant;
    }

    public void Retrait(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Retrait d'un montant négatif impossible"); // => Erreur : Exception
            return;
        }

        if (Solde - montant < -LigneDeCredit)
        {
            Console.WriteLine("Solde insuffisant"); // => Erreur : Exception
            return;
        }

        Solde -= montant;
    }

    public static double operator +(double Solde, Courant c2)
    {
        double somme = 0;

        if (Solde >= 0)
        {
            somme += Solde;
        }
        if (c2.Solde >= 0)
        {
            somme += c2.Solde;
        }
        return somme;
    }
}