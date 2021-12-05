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
        // Les proprietes
        public List<Usager> ListeUsager {
            get => listeUsager;
            set => listeUsager = value;
        }
        public Administrateur Administrateur {
            get => administrateur;
            set => administrateur = value; 
        }
        public EtatDuSysteme Mode {
            get => mode;
            set => mode = value;
        }
        public decimal Solde {
            get => solde;
            set => solde = value;
        }
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
            if (usager == null)
            {
                Console.WriteLine("usager vide");
            }
            listeUsager.Add(usager);
        }      
        // Menu Utilisateur
        public void MenuPrincipal()
        {
            if(mode  == EtatDuSysteme.ACTIF) 
            {
                Console.WriteLine("Veuillez choisir l'une des actions suivantes:");
                Console.WriteLine("1-Se connecter à votre compte d'utilisateur");
                Console.WriteLine("2- Se connecter comme administrateur");
                Console.WriteLine("3- Quitter");
            }
            else
            {
                Console.WriteLine("Veuillez choisir l'une des actions suivantes:");
                Console.WriteLine("1- Guichet en mode  panne");
                Console.WriteLine("2- Se connecter comme administrateur");
                Console.WriteLine("3- Quitter");
            }            
        }
        // Choix des operations dans le menu du compte personnel
        public void SelectOperationsUsager(Usager usager)
        {
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    usager.ChangerMotdePasse();
                    break;
                case "2":
                    usager.DeposerMontant();
                    break;
                case "3":
                    usager.RetirerMontant2();
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
                default:
                    Console.WriteLine("Votre choix est invalide");
                    break;
            }
        }

        // Les choix du menu  de l'administrateur       
        public void MenuAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Bienvenue dans votre compte administrateur");
            Console.WriteLine();
            Console.WriteLine(" 1- Remettre le guichet en fonction");
            Console.WriteLine(" 2- Déposer de l'argent dans le guichet");
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
        public void SelectOperationsAdmin()
        {
            string choixadmin = Console.ReadLine();
            switch (choixadmin)
            {
                case "1":
                    RemettreGuichetEnFonction();
                    break;
                case "2":
                    DeposerMontantGuichet();
                    break;
                case "3":
                    VoirSoldeGuichet();
                    break;
                case "4":
                    VoirListeDesCompte();
                    break;
                case "5":
                    MenuPrincipal();
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
                    Usager usager = ConnectionModeUtilisateur();
                    SelectOperationsUsager(usager);                                      
                    break;
                case "2":
                    ConnectionModeAdministrateur();
                    SelectOperationsAdmin();
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
        public Usager ConnectionModeUtilisateur()
        {
            int compteur = 0;     // trois tentatives
            string usagerLogin;
            string password;
            Usager usager = null;
            
            while (compteur < 3 )
            {
                Console.WriteLine("Enter nom utilisateur:");
                usagerLogin = Console.ReadLine();
                Console.WriteLine("Entrer mot de passe:");
                password = Console.ReadLine();
                 usager = Rechercher(usagerLogin, password);
                if (usager != null)
                {
                    
                    break;
                }
                else
                {
                    Console.WriteLine("Nom utilisateur ou mot de passe incorrect");
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
                Console.WriteLine();
                MenuComptePersonnel();
            }
            return usager;
        }
        // Fonction de  Connection en mode  Administrateur
        public Administrateur ConnectionModeAdministrateur()
        {
            int compteur = 0;
            string userAdmin;
            string password;
            Administrateur admin = null ;
            while (compteur < 3)
            {
                Console.WriteLine("Nom Administrator : ");
                userAdmin = Console.ReadLine();
                Console.WriteLine("Mot de passe Administrator :");
                password = Console.ReadLine();
                if (!ValidationAdministrateur(userAdmin, password))
                {
                    Console.WriteLine("Nom utilisateur ou mot de passe incorrecte");
                    Console.WriteLine();
                }
                else
                {
                    admin = new(userAdmin, password);
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
                MenuAdmin();
              
            }
            
            return admin;
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
        // Fonction qui valide le mot de passe et le nom utilisateur de l'admin
        public bool ValidationAdministrateur(string userAdmin, string password)
        {
            return password.Equals(administrateur.AdministrateurPassword) && userAdmin.Equals(administrateur.AdministrateurId);
        }
        // Fonction qui permet de rechercher un element dans une liste
        public Usager Rechercher(string username,string password)
        {
            Usager usager = null;
           IEnumerator<Usager> monEnumarateur = listeUsager.GetEnumerator();
            while (monEnumarateur.MoveNext())
            {
                if(monEnumarateur.Current.NomUtilisateur == username && monEnumarateur.Current.Password == password)
                {                   
                    usager = monEnumarateur.Current;
                    break;
                }
                else
                {
                    usager = null;
                }
            }
            return usager;
        }
        //=================================================================================================
        // Fonction qui permet de remettre le guichet en fonction
        public void RemettreGuichetEnFonction()
        {
            Console.WriteLine("Voulez-vous remettre le systeme en fonction (O/N)?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "O":
                    mode = EtatDuSysteme.ACTIF;
                    MenuPrincipal();
                    break;
                case "N":
                    mode = EtatDuSysteme.PANNE;
                    Console.WriteLine("Systeme Hors Service, guichet en " + EtatDuSysteme.PANNE);
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Operation invalide");
                    break;
            }
        }
        // Fonction qui permet de deposer un montant dans le guichet     
        public void DeposerMontantGuichet()
        {
            Console.WriteLine("Entrer le montant du depot ");
            string saisie = Console.ReadLine();
            bool resulatConversion = decimal.TryParse(saisie, out decimal montant);
            if (resulatConversion && montant <= 10000)
            {
                decimal soldeCourant = getSoldeGuichet();
                setSoldeGuichet(soldeCourant + montant);
            }
            else
            {
                while (montant > 10000 && resulatConversion)
                {
                    Console.WriteLine("Le montant maximal du depot doit etre 10000$");
                    Console.WriteLine("Entrer le montant du depot ");
                    saisie = Console.ReadLine();
                    resulatConversion = decimal.TryParse(saisie, out montant);
                }
                decimal soldeCourant = getSoldeGuichet();
                setSoldeGuichet(soldeCourant + montant);            
            }
            Console.WriteLine("Transaction effectué avec success");
            VoirSoldeGuichet();
        }
        // Fonction qui Affiche le solde courant du Guichet
        public void VoirSoldeGuichet()
        {
            Console.WriteLine("Solde courant du guichet  : "+getSoldeGuichet());
        }
        // Fonction qui Affiche la liste des comptes 
        public void VoirListeDesCompte()
        {
            foreach (Usager client in listeUsager)
            {
                //Usager usager = client as Usager;
                if (client is Usager usager)
                {
                    usager.getCompteCheque.AfficherCompte();
                    usager.getCompteEpargne.AfficherCompte();
                }
            }
        }
        public void RetournerMenuPrincipal()
        {
            MenuPrincipal();

        }
        // Les choix des operations de l'administrateur
        public void OperationsAdmin()
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RemettreGuichetEnFonction();
                    break;
                case "2":
                    DeposerMontantGuichet();
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
    }
}
