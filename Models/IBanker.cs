using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IBanker : ICustomer
    {
        public string Numero { get; }
        public Personne Titulaire { get; }
        public void AppliquerInteret();
    }
}