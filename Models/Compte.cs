using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Compte
    {
        private string _numero;
        private double _solde;
        private Personne _titulaire;

        public string Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        public double Solde
        {
            get
            {
                return _solde;
            }

            private set
            {
                _solde = value;
            }
        }

        public Personne Titulaire { get; set; }

        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Dépot d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            Solde += montant;
        }

        public static double operator +(double Solde, Compte c2)
        {
            double somme = 0;

            if (Solde >= 0)
            {
                somme += Solde;
            }
            if (c2.Solde >= 0)
            {
                somme += c2.Solde;
            }
            return somme;
        }
        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0D);
        }

        protected void Retrait(double montant, double ligneDeCredit)
        {
            if (!(montant > 0))
            {
                Console.WriteLine("Retrait d'un montant négatif impossible"); // => Erreur : Exception
                return;
            }

            if (Solde - montant < -ligneDeCredit)
            {
                Console.WriteLine("Solde insuffisant"); // => Erreur : Exception
                return;
            }

            Solde -= montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret() 
        {
            Solde += CalculInteret();
        }
    }
}
