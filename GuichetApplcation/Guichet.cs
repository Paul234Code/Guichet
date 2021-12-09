﻿using System;
using System.Collections.Generic;

namespace Guichet
{
    public class Guichet
    {
        // Attributs de la classe Guichet
        private List<Usager> listeUsager;
        private EtatDuSysteme mode;
        private Administrateur administrateur;
        private  Usager usagerCourant;
        private decimal solde;
        // Les proprietes
        public List<Usager> ListeUsager
        {
            get => listeUsager;
            set => listeUsager = value;
        }
        public Administrateur Administrateur
        {
            get => administrateur;
            set => administrateur = value;
        }
        public Usager UsagerCourant
        {
            get => usagerCourant;
            set => usagerCourant = value;
        }
        public EtatDuSysteme Mode
        {
            get => mode;
            set => mode = value;
        }
        public decimal Solde
        {
            get => solde;
            set => solde = value;
        }
        // Le constructeur de la classe Guichet
        public Guichet(decimal solde, EtatDuSysteme mode, Administrateur administrateur)
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
        // Fonction qui permet de verifier le solde du guichet
        public void VerifierSoldeGuichet()
        {
            if (solde == 0)
            {
                mode = EtatDuSysteme.PANNE;
                Console.WriteLine("Solde du guichet : 0. GUICHET EN PANNE.");
            }
        }
        // Fonction qui va lancer l'application
        public void StartApplication()
        {
            do
            {
                Console.Clear();
                MenuPrincipal();                               
                while (usagerCourant != null)
                {
                    MenuComptePersonnel();
                    if(usagerCourant == null)
                    {
                        MenuPrincipal();
                    }
                }
                while(administrateur != null)
                {
                    MenuAdmin();
                    if(administrateur == null)
                    {
                        MenuPrincipal();

                    }
                                 
                }
                
            }
            while (true);
        }
        // Menu Utilisateur
        public void MenuPrincipal()
        {
            Console.WriteLine("Veuillez choisir l'une des actions suivantes:");
            Console.WriteLine("1- Se connecter à votre compte d'utilisateur");
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");
            string ChoixPrincipal = Console.ReadLine();
            SelectionCompte(ChoixPrincipal);
        }
        // Choix des operations dans le menu du compte personnel
        public void SelectOperationsUsager(string operation)
        {
            switch (operation)
            {
                case "1":
                    ChangerMotdePasse();
                    break;
                case "2":
                    DeposerMontant();
                    break;
                case "3":
                    RetirerMontant2();
                    break;
                case "4":
                    AfficherSoldeCompte();
                    break;
                case "5":
                    FaireVirement();                
                    break;
                case "6":
                    PayerFacture();
                    break;
                case "7":
                    FermerSession();
                    break;
                default:
                    Console.WriteLine("Choix Utilisateur invalide");
                    break;
            }
            MenuComptePersonnel();
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
            string ChoixAdmin = Console.ReadLine();
            SelectOperationsAdmin(ChoixAdmin);
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
                Console.WriteLine("montant du depot doit etre positif");
            }
            else
            {
                solde += montant;
                Console.WriteLine("Transaction effectué avec success");
            }
           
        }
        // Methode pour debiter un montant dans le  Guichet
        public void DebiterGuichet(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("montant du retrait doit etre positif");
            }
            else if (montant > solde)
            {
                Console.WriteLine("operation de retrait impossible");
            }
            else
            {
                solde -= montant;
            }
           if(solde == 0)
            {
                MettreGuichetEnPanne();
            }
            else
            {
                MettreGuichetEnMarche();
            }
        }
        // Les choix des operations de l'administrateur
        public void SelectOperationsAdmin(string choice)
        {
            switch (choice)
            {
                case "1":
                    RemettreGuichetEnFonction();
                    break;
                case "2":
                    DeposerMontantGuichet();
                    AppuyerEntrer();
                    break;
                case "3":
                    VoirSoldeGuichet();
                    AppuyerEntrer();
                    break;
                case "4":
                    AfficherInformations();
                    AppuyerEntrer();
                    break;
                case "5":
                    MenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Choix Administrateur  invalide");
                    break;
            }
            MenuAdmin();
        }
        // Fonction qui permet de choisir une option dans le menu principal
        public void SelectionCompte(string choix)
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
        public void AfficherInformations()
        {
            foreach (Usager usager in ListeUsager)
            {
                Console.WriteLine("Numero: " + usager.CompteCheque.Numero);
                Console.WriteLine("Nom proprietaire: " + usager.CompteCheque.NomProprietaire);
                Console.WriteLine("Solde:");
                Console.WriteLine("-Cheque : " + usager.CompteCheque.Balance);
                Console.WriteLine("-Epargne : " + usager.CompteEpargne.Balance);
                Console.WriteLine("Etat du Compte: " + usager.Etat);
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------");
            }
        }
        // Connection Utilisateur
        public void ConnectionModeUtilisateur()
        {
            int compteur = 0;     // trois tentatives
            string usagerLogin;
            string password;
            if (mode == EtatDuSysteme.PANNE)
            {
                Console.WriteLine("Guichet en panne");
                AppuyerEntrer();
            }
            else
            {
                while (compteur < 3)
                {
                    Console.WriteLine("Enter nom utilisateur:");
                    usagerLogin = Console.ReadLine();
                    Console.WriteLine("Entrer mot de passe:");
                    password = Console.ReadLine();
                    if (Rechercher(usagerLogin, password))
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
                   // Console.WriteLine("Bienvenue dans votre compte personnel");
                    //Console.WriteLine();
                    MenuComptePersonnel();
                }
            }
        }
        // Fonction de  Connection en mode  Administrateur
        public void ConnectionModeAdministrateur()
        {
            int compteur = 0;
            string userAdmin;
            string password;
            while (compteur < 3)
            {
                Console.WriteLine("Nom Administrator : ");
                userAdmin = Console.ReadLine();
                Console.WriteLine("Mot de passe Administrator :");
                password = Console.ReadLine();
                if (!ValidationAdministrateur(userAdmin, password))
                {
                    Console.WriteLine("Nom utilisateur ou mot de passe incorrect");
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
                MettreGuichetEnPanne();
                AppuyerEntrer();
            }
            else
            {
                //administrateur
                MenuAdmin();
            }
        }
        // Menu du compte personnel
        public void MenuComptePersonnel()
        {
            Console.WriteLine();
            Console.WriteLine("Bienvenue dans votre compte personnel");
            Console.WriteLine();
            Console.WriteLine(" 1- Changer le mot de passe ");
            Console.WriteLine(" 2- Déposer un montant dans un compte");
            Console.WriteLine(" 3- Retirer un montant d'un compte");
            Console.WriteLine(" 4- Afficher le solde du compte chèque ou épargne");
            Console.WriteLine(" 5- Effectuer un virement entre les comptes");
            Console.WriteLine(" 6- Payer une facture");
            Console.WriteLine(" 7- Fermer session");
            string Choice = Console.ReadLine();
            SelectOperationsUsager(Choice);
        }
        // Methode qui permet de verouiller un compte
        public void VerrouillerCompte()
        {
            if (!ValidationUsagerCourant())
            {
                usagerCourant.Verrouiller();
                Console.WriteLine("Votre Compte est verouiller Veuillez contacter le service a la clientele!");
            }
            else
            {
                Console.WriteLine("Usager non connecté");
            }          
        }
        public Administrateur RechercherAdmin(string userAdmin, string password)
        {
            Administrateur admin;
            if(ValidationAdministrateur(userAdmin, password))
            {
                admin =  new Administrateur(userAdmin,password);
            }
            else
            {
                admin = null;
            }
            return admin;
        }
        // Fonction qui valide le mot de passe et le nom utilisateur de l'admin
        public bool ValidationAdministrateur(string userAdmin, string password)
        {
            return password.Equals(administrateur.AdministrateurPassword) && userAdmin.Equals(administrateur.AdministrateurId);
        }
        // Fonction qui permet de rechercher un element dans une liste
        public bool Rechercher(string username, string password)
        {
            bool resultat = false;
            IEnumerator<Usager> monEnumarateur = listeUsager.GetEnumerator();
            while (monEnumarateur.MoveNext())
            {
                if (monEnumarateur.Current.NomUtilisateur == username && monEnumarateur.Current.Password == password)
                {
                    resultat = true;
                    usagerCourant = monEnumarateur.Current;
                    break;
                }
                else
                {
                    resultat = false;
                }
            }
            return resultat;
        }
        public bool ValidationUsagerCourant()
        {
            return usagerCourant == null;
        }
        // Remettre le guichet en marche
        public void MettreGuichetEnMarche()
        {
            mode = EtatDuSysteme.ACTIF;
            Console.WriteLine("Guichet remit en fonction avec succès");
            Console.WriteLine();
        }
        // Mettre le Guichet en mode Panne
        public void MettreGuichetEnPanne()
        {
            mode = EtatDuSysteme.PANNE;
            Console.WriteLine("Systeme Hors Service, guichet en " + EtatDuSysteme.PANNE);
            Console.WriteLine();
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
                    MettreGuichetEnMarche();
                    MenuPrincipal();
                    break;
                case "N":
                    MettreGuichetEnPanne();
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
                
                DeposerGuichet( montant);
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
                DeposerGuichet(montant);
            }           
            VoirSoldeGuichet();
        }
        // Fonction qui Affiche le solde courant du Guichet
        public void VoirSoldeGuichet()
        {
            Console.WriteLine("Solde courant du guichet  : " + getSoldeGuichet());
        }
        // Fonction qui Affiche la liste des comptes 
        public void VoirListeDesCompte()
        {
            foreach (Usager client in listeUsager)
            {
                //Usager usager = client as Usager;
                if (client is Usager usager)
                {
                    usager.CompteCheque.AfficherCompte();
                    usager.CompteEpargne.AfficherCompte();
                }
            }
        }
        public void RetournerMenuPrincipal()
        {
            administrateur = null;
            MenuPrincipal();
        }
        public bool ValidationFormatMdp(string str)
        {
            bool resultatConversion = false;
            for(int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    resultatConversion = true;
                }
            }
            return resultatConversion;

        }     

        // Fonction qui permet de changer le mot de passe de l'usager
        public void ChangerMotdePasse()
        {
            Console.WriteLine("Entrer le mot de passe actuel:");
            string actuelMotPasse = Console.ReadLine();
            Console.WriteLine("Entrer le nouveau mot de passe:");
            string nouveauMotPasse = Console.ReadLine();
            Console.WriteLine("Confirmer le nouveau mot de passe :");
            string confirmation = Console.ReadLine();
            if (!nouveauMotPasse.Length.Equals(actuelMotPasse.Length))
            {
                Console.WriteLine("Le format du nouveau mot de passe est incorrect");
            }
            else if (nouveauMotPasse.Equals(actuelMotPasse))
            {
                Console.WriteLine("Le nouveau de mot de passe doit etre different de l'actuel mot de passe");
            }
            else if (confirmation.Equals(nouveauMotPasse))
            {
                if (ValidationFormatMdp(nouveauMotPasse))
                {
                    usagerCourant.Password = nouveauMotPasse;
                    Console.WriteLine("Changement de mot de passe effectif");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Le format du nouveau mot de passe est incorrect");
                    Console.WriteLine();

                }
                
            }
            else
            {
                while (!confirmation.Equals(nouveauMotPasse))
                {
                    Console.WriteLine("Veuillez confirmer le nouveau Mot de passe ");
                    confirmation = Console.ReadLine();
                    if (confirmation.Equals(nouveauMotPasse))
                    {
                        Console.WriteLine("Changement de mot de passe effecuté avec success");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Mot de passe confirmation doit etre egale au nouveau mot de passe");
                    }
                }
            }
        }
        // Fonction  qui permet de deposer un monant dans un compte
        public void DeposerMontant()
        {
            Console.WriteLine("Entrer le montant du depot:");
            string valeur = Console.ReadLine();
            bool resultat = decimal.TryParse(valeur, out decimal montant);
            if (resultat)
            {
                if (!ValidationUsagerCourant()) 
                {
                    string compte = ChoisirCompte();
                    switch (compte)
                    {
                        case "1":
                            usagerCourant.CompteCheque.Deposer(montant);
                            Console.WriteLine("Nouveau Solde du compte cheque : " + usagerCourant.CompteCheque.Balance);
                            break;
                        case "2":
                            usagerCourant.CompteEpargne.Deposer(montant);
                            Console.WriteLine("Nouveau Solde du compte epargne : " + usagerCourant.CompteEpargne.Balance);
                            break;
                        default:
                            Console.WriteLine("Operation  invalide");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Usager courant non connecté");
                }
                
            }
            else
            {
                while (!decimal.TryParse(valeur, out montant))
                {
                    Console.WriteLine("Montant invalide!");
                    Console.WriteLine("Entrer le montant du depot: ");
                    valeur = Console.ReadLine();
                }
                Console.WriteLine("Dans quel compte le dépôt doit être effectué ?");
                string compte = ChoisirCompte();
                switch (compte)
                {
                    case "1":
                        usagerCourant.CompteCheque.Deposer(montant);
                        Console.WriteLine("Nouveau Solde du compte cheque : " + usagerCourant.CompteCheque.Balance);
                        break;
                    case "2":
                        usagerCourant.CompteEpargne.Deposer(montant);
                        Console.WriteLine("Nouveau Solde du compte epargne : " + usagerCourant.CompteEpargne.Balance);
                        break;
                    default:
                        Console.WriteLine("Operation  invalide");
                        break;
                }
            }
            Console.WriteLine();
        }
        // Fonction qui permet de retirer un montant
        public void RetirerMontant(decimal montant)
        {
            if (!ValidationUsagerCourant()) 
            {
                if(montant > solde)
                {
                    Console.WriteLine("Operation de retrait impossible");

                }
                else
                {
                    string compte = ChoisirCompte();
                    switch (compte)
                    {
                        case "1":
                            DebiterGuichet(montant);
                            usagerCourant.CompteCheque.Retirer(montant);
                            usagerCourant.CompteCheque.AfficherSoldeCheque();
                            break;
                        case "2":
                            DebiterGuichet(montant);
                            usagerCourant.CompteEpargne.Retirer(montant);
                            usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                            break;
                        default:
                            Console.WriteLine("Operation  invalide");
                            break;
                    }

                }
                
            }
            else
            {
                Console.WriteLine("Usager Courant non connecté");
            }
            
            Console.WriteLine();
        }
        // fonction qui permet de retirer un montant 
        public void RetirerMontant2()
        {
            Console.WriteLine("Entrer le montant de la transaction:");
            string saisie = Console.ReadLine();
            bool resulat = decimal.TryParse(saisie, out decimal montant);
            if (resulat)
            {
                RetirerMontant(montant);
            }
            else
            {
                Console.WriteLine("Veuillez entrer un montant valide");
            }
        }
        // Afficher le solde du compte Cheque ou Epargne
        public void AfficherSoldeCompte()
        {
            string choice = ChoisirCompte();
            switch (choice)
            {
                case "1":
                    usagerCourant.CompteCheque.AfficherSoldeCheque();
                    Console.WriteLine();
                    break;
                case "2":
                    usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Operation  invalide");
                    break;
            }
        }
        // Faire un virement entre deux compte
        public void FaireVirement()
        {
            Console.WriteLine("Entrer le montant du virement:");
            string saisie = Console.ReadLine();
            bool resulatConversion = decimal.TryParse(saisie, out decimal montant);
            if (resulatConversion)
            {
                if(montant > 0)
                {
                    ValidationVirement(montant);
                }
                else
                {
                    Console.WriteLine("Le montant de la transaction doit etre positif");
                }               
            }
            else
            {
                Console.WriteLine("Veuillez entrer un montant valide");
            }
        }
        public bool ValidationConnection()
        {
            Console.WriteLine("Entrer mot de passe");
            string password = Console.ReadLine();
            return  password.Equals(usagerCourant.Password);

        }
        // Fonction qui valide les virement dans un compte
        public void ValidationVirement(decimal montant)
        {
            if (montant <= 1000)
            {
                string compte = ChoisirCompte();
                switch (compte)
                {
                    case "1":
                        usagerCourant.CompteCheque.Virer(usagerCourant.CompteEpargne, montant);
                        usagerCourant.CompteCheque.AfficherSoldeCheque();
                        usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                        break;
                    case "2":
                        usagerCourant.CompteEpargne.Virer(usagerCourant.CompteCheque, montant);
                        usagerCourant.CompteCheque.AfficherSoldeCheque();
                        usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                        break;
                    default:
                        Console.WriteLine("Veuillez effectuer un choix valide");
                        break;
                }
            }
            else
            {
                
                if (ValidationConnection()) 
                {
                    if (!ValidationUsagerCourant())
                    {
                        string compte = ChoisirCompte();
                        switch (compte)
                        {
                            case "1":
                                usagerCourant.CompteCheque.Virer(usagerCourant.CompteEpargne, montant);
                                usagerCourant.CompteCheque.AfficherSoldeCheque();
                                usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                                break;
                            case "2":
                                usagerCourant.CompteEpargne.Virer(usagerCourant.CompteCheque, montant);
                                usagerCourant.CompteCheque.AfficherSoldeCheque();
                                usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                                break;
                            default:
                                Console.WriteLine("Veuillez effectuer un choix valide");
                                break;
                        }
                        Console.WriteLine("Virement effecté avec success");

                    }
                    else
                    {
                        Console.WriteLine("Usager courant non connecté");
                    }
                }
                else
                {
                    Console.WriteLine("Connection invalide");
                }

                        
            }
            AppuyerEntrer();
        }
        // Fonction qui permet de choisir un compte 
        public string ChoisirCompte()
        {
            Console.WriteLine("Dans quel compte voulez-vous effectuer l'operation ?");
            Console.WriteLine("1- Compte Cheque");
            Console.WriteLine("2- Compte Epargne");
            string choixCompte = Console.ReadLine();
            return choixCompte;
        }
        public void AppuyerEntrer()
        {
            Console.WriteLine("Appuyer sur la touche ENTER pour retourner au menu ");
            Console.ReadLine();
        }
        // Fonction qui permet de fermer la session
        public void FermerSession()
        {
            usagerCourant = null;
            MenuPrincipal();

        }
        // Methode qui permet a l'usager de payer une facture       
        public void PayerFacture(decimal frais = 2)
        {
            string nomFournisseur = ChoixFournisseur();
            FournisseurService fournisseur = usagerCourant.FournisseurService.GetFournisseurService(nomFournisseur);
            usagerCourant.FournisseurService = fournisseur;
            usagerCourant.FournisseurService.AfficherService();
            Console.WriteLine("Entrer le numero de facture:");
            string numero = Console.ReadLine();
            // on cherche la facture dans la liste des factures
            int index = usagerCourant.FournisseurService.GetIndex(numero);
            Console.WriteLine("Entrer le montant de la facture:");
            string saisie = Console.ReadLine();
            bool resultatConversion = decimal.TryParse(saisie, out decimal montant);
            //compte1 as CompteCheque
            if (resultatConversion)
            {
                if(montant > 0)
                {
                    string compte = ChoisirCompte();
                    switch (compte)
                    {
                        case "1":
                            usagerCourant.CompteCheque.Retirer(montant + frais);
                            break;
                        case "2":
                            usagerCourant.CompteEpargne.Retirer(montant + frais);
                            break;
                        default:
                            Console.WriteLine("Votre choix de compte est invalide");
                            break;
                    }
                   

                }
                else
                {
                    Console.WriteLine("Le montant de la facture doit etre positif");

                }

            }
            else
            {
                Console.WriteLine("Entrer un montant de facture valide");
            }
            AppuyerEntrer();
        }
        // Fonction qui renvoie le fournisseur
        public string ChoixFournisseur()
        {
            string fournisseur = "";
            Console.WriteLine("Veuillez choisir un des fournisseurs suivant :");
            Console.WriteLine("1- Amazon");
            Console.WriteLine("2- Bell");
            Console.WriteLine("3- Vidéotron");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    fournisseur = "Amazon";
                    break;
                case "2":
                    fournisseur = "Bell";
                    break;
                case "3":
                    fournisseur = "Vidéotron";
                    break;

            }
            return fournisseur;

        }


    }
}
