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
            Console.WriteLine(" Menu principal");
            Console.WriteLine("1-Se connecter à votre compte d'utilisateur"); //ajouter consolereadline + switch pour choix de menu     
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");

      
        }
         public void SelectionCompte(string choix)
        {
            switch (choix)
            {
                case "1":
                    SeconnecterUtilisateur();
                    break;
                case "2":
                    SeconnecterAdmin();
                    break;
                case "3":
                    Quitter();
                    break;
  
            }
        }

        private void SeconnecterUtilisateur()
        {
            throw new NotImplementedException();
        }
        private void SeconnecterAdmin()
        {
            throw new NotImplementedException();
        }

        private void Quitter()
        {
            throw new NotImplementedException();
        }


        public void MenuPersonnel()
        {
            Console.WriteLine(" 1- Changer le mot de passe ");
            Console.WriteLine(" 2- Déposer un montant dans un compte");
            Console.WriteLine(" 3- Retirer un montant d'un compte");
            Console.WriteLine(" 4- Afficher le solde du compte chèque ou épargne");
            Console.WriteLine(" 5- Effectuer un virment entre les comptes");
            Console.WriteLine(" 6- Payer une facture");
            Console.WriteLine(" 7- Fermer session");
    
        }
         public void SelectOperation(string operation,Usager usager)
        {
           switch (operation)
            {
                case "1":
                    usager.ChangerMotdePasse();
                    break;
                case "2":
                    usager.DeposerMontant(400);
                    break;
                case "3":
                    usager.RetirerMontant(400);
                    break;
                case "4":
                    usager.AfficherSoldeCompte();
                    break;
                case "5":
                    usager.FaireVirement();
                    break;
                case "6":
                    usager.PayerFacture();
                    break;
                case "7":
                    usager.FermerSession();
                    break;

            }
        }
        
        public void MenuAdmin()
        {
            Console.WriteLine(" 1- Remettre le guichet en fonction");
            Console.WriteLine(" 2- Déposer de l'arget dans le guichet");
            Console.WriteLine(" 3- Voir le solde du guichet");
            Console.WriteLine(" 4- Voir la liste des comptes ");
            Console.WriteLine(" 5- Retour au menu principal");
         
        }
         public void SelectChoixAdmin(string choixadmin,Administrateur admin)
        {
            switch (choixadmin)
            {
                case "1":
                    admin.RemettreGuichetEnFonction();
                    break;
                case "2":
                    admin.DeposerArgent(800);
                    break;
                case "3":
                    admin.VoirSoldeGuichet();
                    break;
                case "4":
                    admin.VoirListeDesCompte();
                    break;
                case "5":
                    admin.RetournerMenuPrincipal();
                    break;
            }
        } 
          public void MenuFournisseur()
        {
            Console.WriteLine(" 1- Amazon");
            Console.WriteLine(" 2- Bell");
            Console.WriteLine(" 3- Vidéotron");
        }
       
        
        // methode qui retourne le solde du guichet
        public  decimal getSoldeGuichet()
        {
            return solde;
        }
        //methode qui Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {
            Console.WriteLine("Solde Guichet:  "+ solde);

        }
        // Methode pour debiter/retirer un montant du Guichet
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
