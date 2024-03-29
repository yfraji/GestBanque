using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Compte : ICustomer, IBanker
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

            private set
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

        public Personne Titulaire 
        {
            get
            {
                return _titulaire;
            } 
            private set
            { 
                _titulaire = value;
            }
        }

        protected Compte(string numero, Personne titulaire)
        {
            _numero = numero;
            Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            _solde = solde;
        }
        public void Depot(double montant)
        {
            
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Dépot d'un montant négatif impossible");
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
                throw new ArgumentOutOfRangeException(nameof(montant), "Retrait d'un montant négatif impossible");
            }

            if (Solde - montant < -ligneDeCredit)
            {
                throw new SoldeInsuffisantException("Solde insuffisant");
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
