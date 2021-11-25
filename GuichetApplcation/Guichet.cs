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



        // Menu principal
        public void MenuPincipal()
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
         public void SelectOperation(string operation,Usager usager)//créer objet usager pour appeler les fonctions créer dans le switch
        {
           switch (operation)
            {
                case "1":
                    ChangerMotDePasse();
                    break;
                case "2":
                    DéposerMontant();
                    break;
                case "3":
                    RetirerMontant();
                    break;
                case "4":
                    AfficherSoldeCompte();
                    break;
                case "5":
                    FaireVirement();
                case "6":
                    PayerFacture();
                    break;
                case "7":
                    FermerSession();
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
         public void SelectChoixAdmin(string choixadmin,Administrateur admin)//créer objet administrateur
                                                                             //pour appeler les fonctions dans switch
        {
            switch (choixadmin)
            {
                case "1":
                    RemettreGuichetEnFonction();
                    break;
                case "2":
                    DéposerArgent();
                    break;
                case "3":
                    VoirSoldeGuichet();
                    break;
                case "4":
                    VoirListeDesCompte();
                    break;
                case "5":
                    RetournerMenuPrincipal();
                    break;
            }
        } 
          public void MenuFournisseur()
        {
            Console.WriteLine(" 1- Amazon");
            Console.WriteLine(" 2- Bell");
            Console.WriteLine(" 3- Vidéotron");
        }

          public void SelectFournisseur(string fournisseur)
        {
            switch (fournisseur)
            {
                case "Amazon":
                 break;
                case "Bell":
                    break;
                case "Videotron": 
                    break;
            }
        }





        // methode qui retourne le solde du guichet
        public decimal getSoldeGuichet()
        {
            return Solde;
        }
        //methode qui Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {

        }
        // Methode pour debiter/retirer un montant du Guichet
        public void Debiter(decimal montant)
        {

        }
    }
}
