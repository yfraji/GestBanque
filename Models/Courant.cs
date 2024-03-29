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
                throw new InvalidOperationException("La ligne de crédit est strictement positive...");
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