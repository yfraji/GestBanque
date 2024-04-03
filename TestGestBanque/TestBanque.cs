using Models;
using System.Numerics;
namespace TestGestBanque
{
    public class UnitTestBanque
    {
        [Fact]
        public void TestBanque_Creation()
        {
            //Arrange
            string nom = "My favorite bank";
            //Act
            Banque banque = new Banque(nom);
            //Assert
            Assert.Equal(nom, banque.Nom);
            Assert.NotNull(banque);
        }

        [Fact]
        public void TestBanque_RightIndex()
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte = new Courant("0001", 500, doeJohn);
            banque.Ajouter(compte);

            //Act
            Compte c = banque["0001"];

            //Assert
            Assert.NotNull(c);
            Assert.Equal("0001", c.Numero);
            Assert.Equal(doeJohn, c.Titulaire);
            Assert.Equal("John", c.Titulaire.Prenom);
        }

        [Fact]
        public void TestBanque_WrongIndex() 
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1)); 
            Compte compte = new Courant("0001", 500, doeJohn);
            banque.Ajouter(compte);

            //Act
            Compte c = banque["0002"];

            //Assert
            Assert.Null(c);
        }

        [Fact]
        public void TestBanque_AvoirDesComptesVide()
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            Compte compte3 = new Epargne("0003", doeJohn);
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);

            //Act
            double total = banque.AvoirDesComptes(doeJohn);

            //Assert
            Assert.Equal(0, total);
        }

        [Fact]
        public void TestBanque_AvoirDesComptes()
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            compte1.Depot(1000);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            compte2.Depot(500);
            Compte compte3 = new Epargne("0003", doeJohn);
            compte3.Depot(1500);
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);

            //Act
            double total = banque.AvoirDesComptes(doeJohn);

            //Assert
            Assert.Equal(3000, total);
        }

        [Fact]
        public void TestBanque_AvoirDesComptesNegatifs()
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            compte1.Retrait(100);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            compte2.Retrait(100);
            Compte compte3 = new Epargne("0003", doeJohn);
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);

            //Act
            double total = banque.AvoirDesComptes(doeJohn);

            //Assert
            Assert.Equal(0, total);
        }

        [Fact]
        public void TestBanque_AjouterComptes() 
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            compte1.Depot(1000);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            compte2.Depot(500);
            Compte compte3 = new Epargne("0003", doeJohn);
            compte3.Depot(1500);
            
            //Act
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);

            //Assert
            Assert.Equal(3, banque.Count);
        }

        [Fact]
        public void TestBanque_AjouterMemeCompte() 
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte = new Courant("0001", 500, doeJohn);

            //Act
            banque.Ajouter(compte);
            ArgumentException argException = Assert.Throws<ArgumentException>(() => banque.Ajouter(compte));
        }

        [Fact]
        public void TestBanque_SupprimerCompte() 
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            compte1.Depot(1000);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            compte2.Depot(500);
            Compte compte3 = new Epargne("0003", doeJohn);
            compte3.Depot(1500);

            //Act
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);
            banque.Supprimer("0003");

            //Assert
            Assert.Equal(2, banque.Count);
            Assert.Null(banque["0003"]);
        }

        [Fact]
        public void TestBanque_SupprimerMemeCompte()
        {
            //Arrange
            Banque banque = new Banque("My favorite bank");
            Personne doeJohn = new Personne("Doe", "John", new DateTime(1970, 1, 1));
            Compte compte1 = new Courant("0001", 500, doeJohn);
            compte1.Depot(1000);
            Compte compte2 = new Courant("0002", 500, doeJohn);
            compte2.Depot(500);
            Compte compte3 = new Epargne("0003", doeJohn);
            compte3.Depot(1500);

            //Act
            banque.Ajouter(compte1);
            banque.Ajouter(compte2);
            banque.Ajouter(compte3);
            banque.Supprimer("0002");
            banque.Supprimer("0003");
            banque.Supprimer("0003");

            //Assert
            Assert.Equal(1, banque.Count);
            Assert.NotNull(banque["0001"]);
            Assert.Null(banque["0002"]);
            Assert.Null(banque["0003"]);
        }
    }
}