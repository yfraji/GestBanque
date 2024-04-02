using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models;

public class Banque
{
    public string Nom { get; init; }

    public Banque(string nom) 
    {
        Nom = nom;
    }

    private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();

    public Compte? this[string Numero] 
    {
        get 
        {
            if (!_comptes.ContainsKey(Numero))
                return null;

            return _comptes[Numero]; 
        }
    }

    public void Ajouter(Compte compte) 
    {
        _comptes.Add(compte.Numero, compte);
        compte.PassageEnNégatifEvent += (compte) => Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif.");
    }

    public void Supprimer(string Numero)
    {
        if (!_comptes.ContainsKey(Numero))
            return;

        _comptes[Numero].PassageEnNégatifEvent -= (compte) => Console.WriteLine($"Le compte {compte.Numero} vient de passer en négatif.");
        _comptes.Remove(Numero);
    }

    public double AvoirDesComptes(Personne titulaire)
    {
        double total = 0;
        foreach (Compte compte in _comptes.Values)
        {
            if (compte.Titulaire == titulaire)
            {
                total += compte;
            }
        }
            
        return total;
    }
}
