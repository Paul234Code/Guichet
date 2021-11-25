using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Guichet
    {
        // Attributs de la classe

        private List<Client> listeClients;
        private EtatDuSysteme mode = EtatDuSysteme.ON; // mode par defaut       
        private decimal solde = 10000;
        // Les proprietes
        public List<Client> ListeClients { get; set; }
        public EtatDuSysteme Mode { get; set; }
        public decimal Solde { get; set; }
        // Le constructeur de la classe Guichet
        public Guichet()
        {
            listeClients = new List<Client>();
           solde = 10000;

        }
        // methode qui ajoute un client dans la liste
        public  void AjouterClient(Client client)
        {
            listeClients.Add(client);
        }

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
        // Menu du compte Personnel
        
        // methode qui retourne le solde du guichet
        public  decimal getSoldeGuichet()
        {
            return solde;
        }
        // Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {
            Console.WriteLine("Solde Guichet:  " + solde);

        }
        // Methode pour debiter un montant du Guichet
        public void Debiter(decimal montant)
        {
            if(montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant),"montant du retrait doit etre positif");
            }
            if(montant > solde)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "operation de retrait impossible ");
            }
            solde -= montant;

        }
    }
}
