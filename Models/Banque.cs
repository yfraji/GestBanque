using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models;

public class Banque
{
    public string Nom { get; set; }

    private Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();

    public Courant? this[string Numero] 
    {
        get 
        {
            if (!_comptes.ContainsKey(Numero))
                return null;

            return _comptes[Numero]; 
        }
    }

    public void Ajouter(Courant compte) 
    {
        _comptes.Add(compte.Numero, compte);
    }

    public void Supprimer(string Numero)
    {
        if (!_comptes.ContainsKey(Numero))
            return;

        _comptes.Remove(Numero);
    }

    public double AvoirDesComptes(Personne titulaire)
    {
        double total = 0;
        foreach (Courant courant in _comptes.Values)
        {
            if (courant.Titulaire == titulaire)
            {
                total += courant;
            }
        }
            
        return total;
    }
}
