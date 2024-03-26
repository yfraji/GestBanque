namespace Models;

public class Courant : Compte
{
    private double _ligneDeCredit;

    public override double LigneDeCredit
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
    protected override double CalculInteret() 
    {
        return Solde * ((Solde < 0) ? .0975 : .03);
    }

}