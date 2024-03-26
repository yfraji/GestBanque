namespace Models;

public class Courant : Compte
{
    private double _ligneDeCredit;

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

    public override void Retrait(double montant)
    {
        double ancienSolde = Solde;
        Retrait(montant, LigneDeCredit);

        if (ancienSolde >= 0D && Solde < 0)
        {
            Console.WriteLine("Solde insuffisant"); // => Erreur : Exception
            return;
        }
    }
    protected override double CalculInteret() 
    {
        return Solde * ((Solde < 0) ? .0975 : .03);
    }

}