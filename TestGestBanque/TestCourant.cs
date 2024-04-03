using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGestBanque
{
    public class UnitTestCourant
    {
        [Fact]
        public void TestCourant_Creation()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            //Act
            Courant courant = new Courant("0001", doeJohn);

            //Assert
            Assert.Equal("0001", courant.Numero);
            Assert.Equal(doeJohn, courant.Titulaire);
            Assert.NotNull(courant);
        }

        [Fact]
        public void TestCourant_CreationLDC()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            //Act
            Courant courant = new Courant("0001", 500, doeJohn);

            //Assert
            Assert.Equal("0001", courant.Numero);
            Assert.Equal(doeJohn, courant.Titulaire);
            Assert.Equal(500, courant.LigneDeCredit);
            Assert.NotNull(courant);
        }

        [Fact]
        public void TestCourant_CreationSolde()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));

            //Act
            Courant courant = new Courant("0001", doeJohn, 1000);

            //Assert
            Assert.Equal("0001", courant.Numero);
            Assert.Equal(doeJohn, courant.Titulaire);
            Assert.Equal(1000, courant.Solde);
            Assert.NotNull(courant);
        }

        [Fact]
        public void TestCourant_LigneDeCrédit()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0001", doeJohn, 1000);

            //Act
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => (courant.LigneDeCredit = -500));
        }

        [Fact]
        public void TestCourant_AppliquerInteretZero()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0001", doeJohn, 0);

            //Act
            courant.AppliquerInteret();

            //Assert

            Assert.Equal(0, courant.Solde);
        }
        [Fact]
        public void TestCourant_AppliquerInteretPositif()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0001", 2000, doeJohn);
            courant.Depot(1000);

            //Act
            courant.AppliquerInteret();

            //Assert

            Assert.Equal(1030, courant.Solde);
        }
        [Fact]
        public void TestCourant_AppliquerInteretNegatif()
        {
            //Arrange
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Courant courant = new Courant("0001", 2000, doeJohn);
            courant.Retrait(1000);

            //Act
            courant.AppliquerInteret();

            //Assert

            Assert.Equal(-1097.5, courant.Solde);
        }
    }
}
