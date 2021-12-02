using System;
using System.Collections.Generic;

namespace Guichet
{
    public class Guichet
    {
        // Attributs de la classe

        private List<Usager> listeUsager;
        private EtatDuSysteme mode; // mode par defaut
        private Administrateur administrateur;                                                  // 
        private decimal solde;
        //private Administrateur administrateur ;
        //private Usager usager;
        // Les proprietes
        public List<Usager> ListeUsager { get; set; }
        public EtatDuSysteme Mode { get; set; }
        public decimal Solde { get; set; }
        // Le constructeur de la classe Guichet
        public Guichet(decimal solde, EtatDuSysteme mode,Administrateur administrateur)
        {
            this.solde = solde;
            this.mode = mode;
            this.administrateur = administrateur;    
            listeUsager = new List<Usager>();
        }
        // methode qui ajoute un client dans la liste
        public void AjouterUsager(Usager usager)
        {
            listeUsager.Add(usager);
        }

        // Menu Utilisateur
        public void MenuPrincipal()
        {
            Console.WriteLine("Veuillez choisir l'une des actions suivantes:");
            Console.WriteLine("1-Se connecter à votre compte d'utilisateur"); //ajouter consolereadline + switch pour choix de menu     
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");
        }

        // Choix des operations dans le menu du compte personnel
        public void SelectOperationsUsager(string operation, Usager usager, CompteCheque cheque, decimal montant)
        {
            switch (operation)
            {
                case "1":
                    usager.ChangerMotdePasse();
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
        }
        // Fonction qui affiche le menu fournisseur
        public void MenuFournisseur()
        {
            Console.WriteLine(" 1- Amazon");
            Console.WriteLine(" 2- Bell");
            Console.WriteLine(" 3- Vidéotron");
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
            Console.WriteLine("Solde Guichet:  " + getSoldeGuichet());
        }
        // Fonction qui affiche l'etat du Guichet
        public void AfficherEtatGuichet()
        {
            AfficherSoldeGuichet();
            Console.WriteLine("Etat du Systeme:  " + mode);
        }
        // Methode pour Deposer un montant dans le guichet
        public void DeposerGuichet(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant du retrait doit etre positif");
            }
            solde += montant;
        }
        // Methode pour debiter un montant dans le  Guichet
        public void DebiterGuichet(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant du retrait doit etre positif");
            }
            if (montant > solde)
            {
                Console.WriteLine("operation de retrait impossible");
            }
            solde -= montant;
        }
        // Les choix des operations de l'administrateur
        public void SelectOperationsAdmin(string choixadmin)
        {
            switch (choixadmin)
            {
                case "1":
                    administrateur.RemettreGuichetEnFonction();
                    break;
                case "2":
                    administrateur.DeposerMontantGuichet();
                    break;
                case "3":
                    administrateur.VoirSoldeGuichet();
                    break;
                case "4":
                    administrateur.VoirListeDesCompte();
                    break;
                case "5":
                    administrateur.RetournerMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;
            }
        }
        // Fonction qui permet de choisir une option dans le menu principal
        public  void SelectionCompte(string choix)
        {
            switch (choix)
            {
                case "1":
                    ConnectionModeUtilisateur();
                    break;
                case "2":
                    ConnectionModeAdministrateur();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;
            }
        }
        // Connection Utilisateur
        public void ConnectionModeUtilisateur()
        {
            int compteur = 0;     // trois tentatives
            string usagerLogin;
            string password;
            while (compteur < 3)
            {
                Console.WriteLine("Enter nom utilisateur:");
                usagerLogin = Console.ReadLine();
                Console.WriteLine("Entrer mot de passe:");
                password = Console.ReadLine();
                // Convertit la saisie en tableau de caractere ;                 
                if (Egalite(usagerLogin, administrateur.GetAdministrateurId()) && Egalite(password, administrateur.GetAdministrateurPassword()))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nom utilisateur ou mot de passe incorrecte");
                    Console.WriteLine();
                }
                compteur++;
            }
            if (compteur == 3)
            {
                VerrouillerCompte();
            }
            else
            {
                Console.WriteLine("Bienvenue dans votre compte personnel");
                MenuComptePersonnel();
            }
        }
        // Connection Administrateur
        public void ConnectionModeAdministrateur()
        {
            int compteur = 0;
            string userAdmin;
            string password;
            while (compteur < 3)
            {
                Console.WriteLine("Nom Administrator: ");
                userAdmin = Console.ReadLine();
                Console.WriteLine("Mot de passe Administrator:");
                password = Console.ReadLine();
                if (!ValidationAdministrateur(userAdmin, password))
                {
                    Console.WriteLine("Nom utilisateur ou mot de passe incorrecte");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
                compteur++;
            }
            if (compteur == 3)
            {
                Console.WriteLine("Systeme Hors Service,guichet en " + EtatDuSysteme.PANNE);
            }
            else
            {
                Console.WriteLine("Bienvenue dans votre compte Administrateur");
                MenuAdmin();
            }
        }
        // Menu du compte personnel
        public void MenuComptePersonnel()
        {
            Console.WriteLine(" 1- Changer le mot de passe ");
            Console.WriteLine(" 2- Déposer un montant dans un compte");
            Console.WriteLine(" 3- Retirer un montant d'un compte");
            Console.WriteLine(" 4- Afficher le solde du compte chèque ou épargne");
            Console.WriteLine(" 5- Effectuer un virment entre les comptes");
            Console.WriteLine(" 6- Payer une facture");
            Console.WriteLine(" 7- Fermer session");
        }
        // Methode qui permet de verouiller un compte
        public void VerrouillerCompte()
        {
            Console.WriteLine("Votre Compte est verouiller Veuillez contacter le service a la clientele!");
            while (true)
            {

            }
        }
        // Fonction qui permet de comparer l'egalite de deux chaines de caracteres
        public bool Egalite(string str1, string str2)
        {
            return str1.Equals(str2);
        }
        // Fonction qui valide le mot de passe et le nom utilisateur
        public bool ValidationAdministrateur(string userAdmin, string password)
        {
            return password.Equals(administrateur.GetAdministrateurPassword()) && userAdmin.Equals(administrateur.GetAdministrateurId());
        }
    }
}
