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

        private set
        {
            if (value < 0)
            {
                Console.WriteLine("La ligne de crédit est strictement positive..."); // => Erreur : Exception
                return;
            }
            _ligneDeCredit = value;
        }
    }

    public Courant(string numero, Personne titulaire ) : base (numero, titulaire)
    {

    }

    public Courant(string numero, double ligneDeCredit, Personne titulaire) : base(numero, titulaire)
    {
        _ligneDeCredit = ligneDeCredit;
    }

    public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
    { 
        
    }

    public override void Retrait(double montant)
    {

        Retrait(montant, LigneDeCredit);
    }
    protected override double CalculInteret() 
    {
        return Solde * ((Solde < 0) ? .0975 : .03);
    }

}