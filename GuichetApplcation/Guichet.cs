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
        private EtatDuSysteme mode ; // mode par defaut
        private Administrateur admin;                                                  // 
        private decimal solde ;
        //private Administrateur administrateur ;
        //private Usager usager;
        // Les proprietes
        public List<Client> ListeClients { get; set; }
        public EtatDuSysteme Mode { get; set; }
        public decimal Solde { get; set; }
        // Le constructeur de la classe Guichet
        public Guichet(decimal solde,EtatDuSysteme mode)
        {
            this.solde = solde;
            this.mode = mode;
            listeClients = new List<Client>();           
        }
        // methode qui ajoute un client dans la liste
        public  void AjouterClient(Client client)
        {
            listeClients.Add(client);
        }

        // Menu Utilisateur
        public void MenuPrincipal()
        {
            Console.WriteLine("Veuillez choisir l'une des actions suivantes:");
            Console.WriteLine("1- Se connecter à votre compte d'utilisateur"); //ajouter consolereadline + switch pour choix de menu     
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");
            string choixMenuPrincipal = Console.ReadLine();
            SelectionCompte(choixMenuPrincipal);

        }
                   
        // Choix des operations dans le menu du compte personnel
         public void SelectOperationsUsager(string operation,Usager usager,CompteCheque cheque,decimal montant)
        {
           switch (operation)
            {
                case "1":
                    usager.ChangerMotDePasse();
                    break;
                case "2":
                    usager.DeposerMontant();
                    break;
                case "3":
                    usager.RetirerMontant(montant);
                    break;
                case "4":
                    usager.AfficherSoldeCompte();
                    break;
                case "5":
                    usager.FaireVirement(montant);
                    break;
                case "6":
                    usager.PayerFacture();
                    break;
                case "7":
                    usager.FermerSession();
                    break;
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;
            }
        }

        // Les choix du menu  de l'administrateur       
        public void MenuAdmin()
        {
            Console.WriteLine(" 1- Remettre le guichet en fonction");
            Console.WriteLine(" 2- Déposer de l'arget dans le guichet");
            Console.WriteLine(" 3- Voir le solde du guichet");
            Console.WriteLine(" 4- Voir la liste des comptes ");
            Console.WriteLine(" 5- Retourner au menu principal");
            string choixMenuAdmin = Console.ReadLine();
            SelectOperationsAdmin(choixMenuAdmin);

        }
        // Fonction qui affiche le menu fournisseur
        public void MenuFournisseur()
        {
            
            Console.WriteLine(" 1- Amazon");
            Console.WriteLine(" 2- Bell");
            Console.WriteLine(" 3- Vidéotron");
            string choixFournisseur = Console.ReadLine();


        }

        public FournisseurService getFournisseurService()
        {
            Console.WriteLine("Entrer le nom  fournisseur");
            string choixFournisseur = Console.ReadLine();
            return  new FournisseurService(choixFournisseur);

        }

        // methode qui retourne le solde du guichet
        public decimal getSoldeGuichet()
        {
            return solde;
        }
        // Fonction qui modifie le solde du guichet
        public void setSoldeGuichet(decimal solde)
        {
            this.solde = solde;
        }
        // Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {
            Console.WriteLine("Solde Guichet:  "+ getSoldeGuichet());

        }
        // Fonction qui affiche l'etat du Guichet
        public void AfficherEtatGuichet()
        {
            AfficherSoldeGuichet();
            Console.WriteLine("Etat du Systeme:  "+ EtatDuSysteme.ACTIF);
        }
        // Methode pour Deposer un montant dans le guichet
        public void DeposerGuichet( decimal montant )
        {
            if(montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "montant du retrait doit etre positif");

            }
            solde += montant;

        }
        // Methode pour debiter un montant dans le  Guichet
        public void DebiterGuichet(decimal montant)
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

        // Les choix des operations de l'administrateur
        public void SelectOperationsAdmin(string choixadmin)
        {
            switch (choixadmin)
            {
                case "1":
                    admin.RemettreGuichetEnFonction();
                    break;
                case "2":
                    admin.DeposerMontantGuichet();
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
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;
            }
        }
        // Fonction qui permet de choisir une option dans le menu principal
        public void SelectionCompte(string choix, Administrateur admin, Usager usager)
        {
            switch (choix)
            {
                case "1":
                    usager.ConnectionModeUtilisateur();
                    break;
                case "2":
                    admin. ConnectionModeAdministrateur();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;

            }
        }
    }
}
