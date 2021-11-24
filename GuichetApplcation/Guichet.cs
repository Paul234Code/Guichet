using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Guichet
    {
       
        
        private EtatDuSysteme mode;
        private decimal solde;

        List<Client> ListeClients = new List<Client>();
        ListeClients.Add(new client1("Firdaous", 1234);
        ListeClients.Add(new client2("JonamDes",4321);

        ListeClients.Add(new client3)



        // Menu Utilisateur
        public void MenuPrincipal()
        {
            Console.WriteLine("1- Se connecter à votre compte");
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");
            
        }
        //Menu du compte personnel
        public void MenuPersonnel()
        {
           
        }

        //Menu Admin
        public void MenuAdmin()
        {

        }
        // methode qui retourne le solde du guichet
        public decimal getSoldeGuichet()
        {
            return solde;
        }
        // Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {

        }
        // Methode pour debiter un montant du Guichet
        public void Debiter(decimal montant)
        {

        }
    }
}
