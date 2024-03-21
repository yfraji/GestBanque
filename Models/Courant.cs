namespace Models
{
    public class Courant
    {
        public string numero { get; set; }
        public double solde { get; set; }
        public double ligneDeCredit { get; set; }
        public Personne titulaire { get; set; }

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
