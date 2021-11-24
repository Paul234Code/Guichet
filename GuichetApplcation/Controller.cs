using System;
using System.Collections.Generic;
using System.Threading;

namespace Guichet
{
    public class Controller
    {
        static void Main(string[] args)
        {
            Guichet guichet = new Guichet();
            List<Client> ListeClients = new List<Client>();
            Client client1 = new Usager();
            Client client2 = new Usager();
            Client client3 = new Usager();
            Client client4 = new Usager();
            Client client5 = new Usager();
            Client admin = new Administrateur(guichet);
            guichet.ajouterClient(client1);
            guichet.ajouterClient(client2);
            guichet.ajouterClient(client3);
            guichet.ajouterClient(client4);
            guichet.ajouterClient(client5);



        }
    }
}
