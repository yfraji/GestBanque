namespace Models
{
    public class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; private set; }

        public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
        {

        }

        public Epargne(string numero, Personne titulaire, double solde, DateTime dateDernierRetrait) : base(numero, titulaire, solde)
        {
            DateDernierRetrait = dateDernierRetrait;
        }
        public override void Retrait(double montant)
        {
            double ancienSolde = Solde;
            base.Retrait(montant);

            if (Solde != ancienSolde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }

        protected override double CalculInteret()
        {
            return Solde * .045;
        }
    }
}
