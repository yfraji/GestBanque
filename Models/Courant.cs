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

        }

        public void Depot(double montant)
        {

        }
    }
}
