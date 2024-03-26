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
        public DateTime DateDernierRetrait { get; set; }

        public override void Retrait(double montant)
        {
            double ancienSolde = Solde;
            base.Retrait(montant);
            if (ancienSolde != Solde)
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
