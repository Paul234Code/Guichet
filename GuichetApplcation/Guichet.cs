using System;
using System.Collections.Generic;

namespace Guichet
{
    public class Guichet
    {
        // Attributs de la classe Guichet
        private List<Usager> listeUsager;
        private EtatDuSysteme mode;
        private List<Administrateur> listeAdministrateur;
        private static Usager usagerCourant;
        private  static Administrateur administrateurCourant;
        private decimal solde;
        // Les proprietes
        public List<Usager> ListeUsager
        {
            get => listeUsager;
            set => listeUsager = value;
        }
        public List<Administrateur> ListeAdministrateur
        {
            get => listeAdministrateur;
            set => listeAdministrateur = value;
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
            listeAdministrateur =  new List<Administrateur>();
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
        // Fonction qui permet d'ajouter un Administrateur
        public void AjouterAdministrateur(Administrateur administrateur)
        {
            listeAdministrateur.Add(administrateur);
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
        // Fonction qui determine la connection
        public void Connection()
        {
            if(Solde == 0 ||  Mode == EtatDuSysteme.PANNE)
            {
                Console.WriteLine("Systeme Hors service, guichet en PANNE");
            }
            else
            {
                ConnectionModeUtilisateur();
            }
            AppuyerEntrer();
            MenuPrincipal();
        }
        // Fonction qui va lancer l'application
        public void StartApplication()
        {           
            do
            {
                Console.Clear();
                MenuPrincipal();
                while(usagerCourant != null)
                {
                    MenuComptePersonnel();
                    if (usagerCourant == null)
                    {
                        MenuPrincipal();
                        break;
                    }                   
                    else
                    {
                        MenuComptePersonnel();
                    } 
                } 
                while (administrateurCourant != null)
                {
                    MenuAdmin();
                    if (administrateurCourant == null)
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
            Console.WriteLine("1- Se connecter à votre compte ");
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
            Console.WriteLine("Bienvenue dans votre compte administrateur  ");
            Console.WriteLine();
            Console.WriteLine("1- Remettre le guichet en fonction");
            Console.WriteLine("2- Déposer de l'argent dans le guichet");
            Console.WriteLine("3- Voir le solde du guichet");
            Console.WriteLine("4- Voir la liste des comptes ");
            Console.WriteLine("5- Retourner au menu principal");
            string ChoixAdmin = Console.ReadLine();
            SelectOperationsAdmin(ChoixAdmin);
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
            
            Console.WriteLine($"Solde Guichet :  {Solde}");
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
            if (solde == 0)
            {
                MettreGuichetEnPanne();
                AppuyerEntrer();
                MenuPrincipal();
            }
            else
            {
                //MettreGuichetEnMarche();
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
                    RetournerMenuPrincipal();
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
                    Connection(); //ModeUtilisateur();
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
                Console.WriteLine("========================================================");
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
                    Console.WriteLine();
                    Console.WriteLine("Votre compte est verrouiller, contactez un administrateur paul");
                    Console.WriteLine();                  
                }
                else
                {                   
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
        // Fonction qui valide le mot de passe et le nom utilisateur de l'admin
        public bool ValidationAdministrateur(string userAdmin, string password)
        {
            bool trouve = false;
            IEnumerator<Administrateur> monEnumarateur = listeAdministrateur.GetEnumerator();
            while (monEnumarateur.MoveNext())
            {
                if (monEnumarateur.Current.AdministrateurId == userAdmin && monEnumarateur.Current.AdministrateurPassword == password)
                {
                    trouve = true;
                    administrateurCourant = monEnumarateur.Current;
                    break;
                }
                else
                {
                    trouve = false;
                }
            }
            return trouve;
        }
        // Fonction qui permet de rechercher un  usager dans la liste des usagers
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
                DeposerGuichet(montant);
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
            administrateurCourant = null;
            MenuPrincipal();
        }
        public bool ValidationFormatMdp(string str)
        {
            bool resultatConversion = false;
            for (int i = 0; i < str.Length; i++)
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
                if(montant> 0)
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
                    Console.WriteLine("Le montant du depot doit etre positif");
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
                string compte = ChoisirCompte();
                if(compte == "1")
                {
                    if(montant <= usagerCourant.CompteCheque.Balance)
                    {
                        usagerCourant.CompteCheque.Retirer(montant);
                        usagerCourant.CompteCheque.AfficherSoldeCheque();
                        DebiterGuichet(montant);
                    }
                    else
                    {
                        Console.WriteLine("Fonds insuffisants");
                    }
                }
                else if(compte == "2")
                {
                    if(montant <= usagerCourant.CompteEpargne.Balance)
                    {
                        usagerCourant.CompteEpargne.Retirer(montant);
                        usagerCourant.CompteEpargne.AfficherSoldeEpargne();
                        DebiterGuichet(montant);
                    }
                    else
                    {
                        Console.WriteLine("Fonds insuffisants");
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
                if(montant > 0 && montant <= solde)
                { 
                    RetirerMontant(montant);                  
                }
                else
                {
                    Console.WriteLine("Le montant du retrait doit positif et inferieur au solde du guichet");
                }               
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
                if (montant > 0)
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
            return password.Equals(usagerCourant.Password);
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
        public void AppuyerEntrer()  //simple fonction pour avoir un délai quand le systéme affiche un msg
        {
            Console.WriteLine("Appuyer sur la touche ENTER pour retourner au menu ");
            Console.ReadLine();
        }
        // Fonction qui permet de fermer la session
        public void FermerSession()
        {          
            MenuPrincipal();
            usagerCourant = null;
        }
        // Methode qui permet a l'usager de payer une facture       
        public void PayerFacture(decimal frais = 2)
        {
            Console.WriteLine("Veuillez choisir un des fournisseurs suivant :");
            // Affiche la liste des fournissers
            foreach(FournisseurService service in usagerCourant.FournisseurService)
            {
                Console.WriteLine(service.NumeroFournisseur+"- "+service.NomFournisseur);
            }
            string choice = Console.ReadLine();
            FournisseurService fournisseurCourant = usagerCourant.FournisseurService.Find(fournisseur =>fournisseur.NumeroFournisseur == choice);
            if(fournisseurCourant.ListeFacture.Count == 0)
            {
                Console.WriteLine("Aucune facture a payer liste factures vide");
                Console.WriteLine();
            }
            else
            {
                fournisseurCourant.AfficherService();
                Console.WriteLine("Entrer le numero de facture:");
                string numero = Console.ReadLine();
                // on cherche la facture dans la liste des factures
                int index = fournisseurCourant.GetIndex(numero);
                Console.WriteLine("Entrer le montant de la facture:");
                string saisie = Console.ReadLine();
                bool resultatConversion = decimal.TryParse(saisie, out decimal montant);
                if (resultatConversion)
                {
                    if (montant > 0)
                    {
                        ValidationPayement(montant);
                        // on supprime la facture payée dans la liste des factures
                        fournisseurCourant.ListeFacture.RemoveAt(index);                                        
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
            }
            AppuyerEntrer();
        }
        // Fonction qui valide une transaction de payement
        public void ValidationPayement(decimal montant, decimal frais = 2)
        {
            string choice = ChoisirCompte();
            if (choice.Equals("1"))
            {
                if (montant + frais > usagerCourant.CompteCheque.Balance)
                {
                    Console.WriteLine("Fonds insuffisants");
                    ChangerTransaction();
                }
                else
                {
                    usagerCourant.CompteCheque.Retirer(montant + frais);
                    Console.WriteLine("Payement effectuer avec sucess");
                }
            }
            else if (choice.Equals("2"))
            {
                if(montant + frais > usagerCourant.CompteEpargne.Balance)
                {
                    Console.WriteLine("Fonds insuffisants");
                    ChangerTransaction();
                }
                else
                {
                    usagerCourant.CompteEpargne.Retirer(montant + frais);
                    Console.WriteLine("Payement effectuer avec sucess");
                }
            }
            else
            {
                Console.WriteLine("Choix de compte invalide");
            }           
        }
        // Fonction qui permet de retourner au menu du compte
        public void RetournerMenu()
        {
            MenuComptePersonnel();
        }
        // Fonction qui change la transaction
        public void ChangerTransaction()
        {
            Console.WriteLine("Voulez-vous changer le montant de la transaction ou retourner au menu ?");
            Console.WriteLine("1- Changer transaction");
            Console.WriteLine("2- Retourner au menu");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ModifierTransaction();
                    break;
                case "2":
                    RetournerMenu();
                    break;

            }
            
        }
        public void ModifierTransaction()
        {
            Console.WriteLine("Enter le montant de la facture");
            string saisie = Console.ReadLine();
            bool result = decimal.TryParse(saisie, out decimal montant);
            
            if (result)
            {
                if(montant > 0)
                {
                   


                }
                else
                {
                    Console.WriteLine("Le montant de la facture doit etre positif");
                }

            }
            else
            {
                Console.WriteLine("Enter un montant valide");
            }

        }
    }
}
