namespace ExoDelegate
{
    public class Carwash
    {
        private MonType _delegate;
        public Carwash()
        {
            //_delegate += Préparer;
            //_delegate += Laver;
            //_delegate += Secher;
            //_delegate += Finaliser;

            _delegate += delegate (Voiture v) { Console.WriteLine($"Je prépare la voiture : {v.Plaque}"); };
            _delegate += delegate (Voiture v) { Console.WriteLine($"Je lave la voiture : {v.Plaque}"); };
            _delegate += delegate (Voiture v) { Console.WriteLine($"Je sèche la voiture : {v.Plaque}"); };
            _delegate += delegate (Voiture v) { Console.WriteLine($"Je finalise la voiture : {v.Plaque}"); };
        }
        private void Préparer(Voiture v)
        {
            Console.WriteLine($"Je prépare la voiture : {v.Plaque}.");
        }
        private void Laver(Voiture v)
        {
            Console.WriteLine($"Je lave la voiture : {v.Plaque}.");
        }
        private void Secher(Voiture v)
        {
            Console.WriteLine($"Je sèche la voiture : {v.Plaque}.");
        }
        private void Finaliser(Voiture v)
        {
            Console.WriteLine($"Je finalise la voiture : {v.Plaque}.");
        }
        public void Traiter(Voiture v)
        {
            _delegate(v);
        }   
    }
}