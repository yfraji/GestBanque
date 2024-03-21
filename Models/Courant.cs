namespace Models
{
    public class Courant
    {
        string numero { get; set; }
        double solde { get; set; }
        double ligneDeCredit { get; set; }
        Personne titulaire { get; set; }

        public void Retrait(double montant)
        {
            if (this.solde - montant > -ligneDeCredit) 
            {
                this.solde = this.solde - montant;
            }

        }

        public void Depot(double montant)
        {
            this.solde = this.solde + montant;
        }
    }
}
