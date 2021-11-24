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
        private decimal Solde;



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
                    seconnecterutilisateur();
                    break;
                case "2":
                    seconnecteradmin();
                    break;
                case "3":
                    quitter();
                    break;
  
            }
        }

        private void seconnecterutilisateur()
        {
            throw new NotImplementedException();
        }
        private void seconnecteradmin()
        {
            throw new NotImplementedException();
        }

        private void quitter()
        {
            throw new NotImplementedException();
        }

        // créer menu personnel
        //consolewriteline+consolereadline+switch choix de menu

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
         public void SelectOperation(string operation)
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
        


        // creer menu administrateur
        //consolewriteline + consolereadline + switch choix de menu
        public void MenuAdmin()
        {
            Console.WriteLine(" 1- Remettre le guichet en fonction");
            Console.WriteLine(" 2- Déposer de l'arget dans le guichet");
            Console.WriteLine(" 3- Voir le solde du guichet");
            Console.WriteLine(" 4- Voir la liste des comptes ");
            Console.WriteLine(" 5- Retour au menu principal");
         
        }
         public void SelectChoixAdmin(string choixadmin)
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
                case "1":
                    Amazon();
                    break;
                case "2":
                    Bell();
                    break;
                case "3":
            }
        }





        // methode qui retourne le solde du guichet
        public decimal getSoldeGuichet()
        {
            return Solde;
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
