using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Epargne : Compte
    {
        private DateTime _DateDernierRetrait;
        public DateTime DateDernierRetrait { get; private set; }

        public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
        {

        }

        public Epargne(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {

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
