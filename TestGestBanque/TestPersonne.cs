using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGestBanque
{
    public class UnitTestPersonne
    {
        [Fact]
        public void TestPersonne_Creation()
        {
            //Arrange
            string nom = "Doe";
            string prenom = "John";
            DateTime dateDeNaissance = new DateTime(1970, 1, 1);
            //Act
            Personne doeJohn = new Personne(nom, prenom, dateDeNaissance);
            //Assert
            Assert.Equal(nom, doeJohn.Nom);
            Assert.Equal(prenom, doeJohn.Prenom);
            Assert.Equal(dateDeNaissance, doeJohn.DateNaiss);
            Assert.NotNull(doeJohn);
        }
    }
}
