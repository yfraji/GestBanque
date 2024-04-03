using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGestBanque
{
    public class UnitTestEpargne
    {
        [Fact]
        public void TestEpargne_Creation()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            //Act
            Epargne epargne = new Epargne("0001", doeJohn);

            //Assert
            Assert.Equal("0001", epargne.Numero);
            Assert.Equal(doeJohn, epargne.Titulaire);
            Assert.NotNull(epargne);
        }

        [Fact]
        public void TestEpargne_CreationSoldeDT()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            //Act
            Epargne epargne = new Epargne("0001", doeJohn, 1000, DateTime.Now);

            //Assert
            Assert.Equal("0001", epargne.Numero);
            Assert.Equal(doeJohn, epargne.Titulaire);
            Assert.Equal(1000, epargne.Solde);
            Assert.NotNull(epargne);
        }


        [Fact]
        public void TestEpargne_AppliquerInteretZero()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Epargne epargne = new Epargne("0001", doeJohn, 0, DateTime.Now);

            //Act
            epargne.AppliquerInteret();

            //Assert

            Assert.Equal(0, epargne.Solde);
        }
        [Fact]
        public void TestEpargne_AppliquerInteretPositif()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Epargne epargne = new Epargne("0001", doeJohn, 1000, DateTime.Now);

            //Act
            epargne.AppliquerInteret();

            //Assert

            Assert.Equal(1045, epargne.Solde);
        }
        [Fact]
        public void TestEpargne_AppliquerInteretNegatif()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Epargne epargne = new Epargne("0001", doeJohn, -1000, DateTime.Now);

            //Act
            epargne.AppliquerInteret();

            //Assert

            Assert.Equal(-1045, epargne.Solde);
        }
    }
}
