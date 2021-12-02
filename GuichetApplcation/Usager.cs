using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Guichet
{
    public class Usager : Client
    {
        // Les attributs de la classe Usager
        private CompteCheque compteCheque;
        private CompteEpargne compteEpargne;
        private Guichet guichet;
        private FournisseurService fournisseurService;
        private string nomUtilisateur ;
        private string password ;
        // Les proprietes de la classe Usager
        public CompteClient getCompteCheque { get;  }
        public Guichet Guichet { get; set; }
        public FournisseurService getFournisseur { get; set; }  
        public  CompteClient  getCompteEpargne { get; } 
        public string Password { get; set; } 
        public string NomUtilisaeur { get; set; }
        // Le constructeur de la classe Usager
        public Usager(CompteEpargne compteEpargne,CompteCheque compteCheque,Guichet guichet,FournisseurService fournisseurService,string password, string nomUtilisateur)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.guichet = guichet;
            this.fournisseurService = fournisseurService;
            this.password = password;
            this.nomUtilisateur = nomUtilisateur;
        }  
        // Fonction qui permet de changer le mot de passe de l'usager
        public  void ChangerMotdePasse()
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
            else if(confirmation.Equals(nouveauMotPasse))
            {
                password = nouveauMotPasse;
                Console.WriteLine("Changement de mot de passe effectif");
                Console.WriteLine();               
            }
            else
            {
                while (!confirmation.Equals(nouveauMotPasse))
                {
                    Console.WriteLine("Veuillez confirmer le nouveau Mot de passe ");
                    confirmation = Console.ReadLine();
                    if(confirmation.Equals(nouveauMotPasse))
                    {
                        Console.WriteLine("Changement de mot de passe effecuté avec success");
                    }
                    else
                    {
                        Console.WriteLine("Mot de passe confirmation doit etre egale au nouveau mot de passe");
                    }
                }
            }
            MenuComptePersonnel();
        }
        // Fonction  qui permet de deposer un monant dans un compte
        public void DeposerMontant()
        {
            Console.WriteLine("Entrer le montant du depot:");
            string valeur = Console.ReadLine();
            bool resultat = decimal.TryParse(valeur, out decimal montant);
            if (resultat)
            {
                Console.WriteLine("dans quel compte le dépôt doit être effectué?");
                Console.WriteLine("1- Compte Cheque");
                Console.WriteLine("2- Compte Epargne");
                string compte = Console.ReadLine(); 
                switch (compte)
                {
                    case "1":                      
                        compteCheque.Deposer(montant, DateTime.Now, "Depot");                                           
                        Console.WriteLine("Nouveau Solde du compte cheque : " + compteCheque.Balance);
                        break;
                    case "2":                     
                        compteEpargne.Deposer(montant, DateTime.Now, "Depot");                   
                        Console.WriteLine("Nouveau Solde du compte epargne : " + compteEpargne.Balance);
                        break ;
                    default:
                        Console.WriteLine("Operation  invalide");
                        break;
                }
            }
            else
            {               
                while(!decimal.TryParse(valeur,out  montant))
                {
                    Console.WriteLine("Montant invalide!");
                    Console.WriteLine("Entrer le montant du depot: ");
                    valeur = Console.ReadLine();
                }
                Console.WriteLine("Dans quel compte le dépôt doit être effectué ?");
                string compte = Console.ReadLine();
                switch (compte)
                {
                    case "cheque":
                        compteCheque.Deposer(montant, DateTime.Now, "Depot");
                        Console.WriteLine("Nouveau Solde du compte cheque : " + compteCheque.Balance);
                        break;
                    case "epargne":
                        compteEpargne.Deposer(montant, DateTime.Now, "Depot");
                        Console.WriteLine("Nouveau Solde du compte epargne : " + compteEpargne.Balance);
                        break;
                    default:
                        Console.WriteLine("Operation  invalide");
                        break;
                }
            }
            Console.WriteLine();
            MenuComptePersonnel();
        }
        // Fonction qui permet de retirer un montant
        public void RetirerMontant(decimal montant)
        {
            Console.WriteLine("Veuillez choisir le compte à débiter");
            Console.WriteLine();
            Console.WriteLine("1- Compte Cheque");
            Console.WriteLine("2- Compte Epargne");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    guichet.DebiterGuichet(montant);
                    compteCheque.Retirer(montant, DateTime.Now, "Retrait");
                    compteCheque.AfficherSoldeCheque();
                    break;
                case "2":
                    guichet.DebiterGuichet(montant);
                    compteEpargne.Retirer(montant, DateTime.Now, "Retrait");
                    compteEpargne.AfficherSoldeEpargne();
                    break;
                default:
                    Console.WriteLine("Operation  invalide");
                    break;
            }          
            Console.WriteLine();
            MenuComptePersonnel();
        }
        // Methode qui permet de verouiller un compte
        public void VerrouillerCompte()
        {
            Console.WriteLine("Votre Compte est verouiller Veuillez contacter le service a la clientele!");
            while (true)
            {
               

            }
        }
        // Afficher le solde du compte Cheque ou Epargne
        public void AfficherSoldeCompte()
        {
            Console.WriteLine("solde du compte Chèque ou du compte Epargne?");
            Console.WriteLine("1- Cheque");
            Console.WriteLine("2- Epargne");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    compteCheque.AfficherSoldeCheque();
                    Console.WriteLine();
                    MenuComptePersonnel();
                    break;
                case"2":
                   compteEpargne.AfficherSoldeEpargne();
                    Console.WriteLine();
                    MenuComptePersonnel();
                   break ;
                default:
                    Console.WriteLine("Operation  invalide");
                    break;
            }
        }
        // Faire un virement entre deux compte
        public void FaireVirement(decimal montant )
        {           
            ValidationVirement(montant);
        }
        // Methode qui permet a l'usager de payer une facture
        public void PayerFacture()
        {
            // affiche les fournisseurs
            Console.WriteLine("Amazon");
            Console.WriteLine("Bell");
            Console.WriteLine("Vidéotron");
            Console.WriteLine("Veuillez choisir un des fournisseurs suivant :");
            string fournisseur = Console.ReadLine();
            switch (fournisseur)
            {
                case "Amazon":
                    Payer();                    
                    break;
                case "Bell":
                    Payer();
                    break;
                case "Videotron":
                    Payer();
                    break;
                default:
                    Console.WriteLine("Operation invalide");
                    break;
            }           
        }
        // fonction qui permet de retourner un numero de facture
        public void Payer(decimal frais = 2)
        {
            fournisseurService.AfficherService();
            Console.WriteLine("Entrer le numero de facture:");
            string numero = Console.ReadLine();
            // on cherche la facture dans la liste des factures
            int index = fournisseurService.GetIndex(numero);
            Console.WriteLine(index);
            Console.WriteLine("Entrer le montant de la facture:");
            string saisie = Console.ReadLine();
            bool resultatConversion =  decimal.TryParse(saisie, out  decimal montant);
            if (resultatConversion)
            {
                Console.WriteLine("Veuillez choisir le compte a debiter");
                Console.WriteLine("1- Cheque");
                Console.WriteLine("2- Epargne");
                string compte = Console.ReadLine();
                switch (compte)
                {
                    case "1":
                        compteCheque.Retirer(montant+frais, DateTime.Now, "payement facture");
                        break ;
                    case "2":
                        compteEpargne.Retirer(montant+frais, DateTime.Now, "payement facture");
                        break;
                    default :
                        Console.WriteLine("Votre choix de compte est invalide");
                        break;
                }
                // on supprime la facture dans la liste de facture
                fournisseurService.ListeFacture.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Entrer un montant de facture valide");
            }
        }       
        // Fonction qui ferme la session et retourne au menu principal de l'application
        public void FermerSession()
        {
            guichet.MenuPrincipal();
        }
        // Fonction qui permet de comparer l'egalite de deux chaines de caracteres
        public bool Egalite(string str1, string str2)
        {
            return str1.Equals(str2);
        }
        // Fonction qui valide la connection d'un usager
        public void ConnectionModeUtilisateur() 
        {
            int compteur = 0; 
            string usagerLogin;
            string password;
            while (compteur < 3) {
                 Console.WriteLine("Enter nom utilisateur:");
                  usagerLogin = Console.ReadLine();
                 Console.WriteLine("Entrer mot de passe:");
                 password = Console.ReadLine();
                 // Convertit la saisie en tableau de caractere ;                 
                if (Egalite(usagerLogin, nomUtilisateur) && Egalite(password,this.password))
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
        // Methode qui affiche le menu d'un compte usager
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
        // Fonction qui valide les virement dans un compte
        public void ValidationVirement(decimal montant)
        {           
            if(montant <= 1000)
            {
                Console.WriteLine("Veuillez choisir le compte de provenance");
                Console.WriteLine("Cheque");
                Console.WriteLine("Epargne");
                string choice = Console.ReadLine();
                TypeDuCompte compte = (TypeDuCompte)Enum.Parse(typeof(TypeDuCompte),choice);
                switch (compte)
                {
                    case TypeDuCompte.Cheque:
                        compteCheque.Virer(compteEpargne, montant);
                        compteCheque.AfficherSoldeCheque();
                        compteEpargne.AfficherSoldeEpargne();
                        break;
                    case TypeDuCompte.Epargne:
                        compteEpargne.Virer(compteCheque, montant);
                        compteCheque.AfficherSoldeCheque();
                        compteEpargne.AfficherSoldeEpargne();
                        break ;
                    default:
                        Console.WriteLine("Veuillez effectuer un choix valide");
                        break;
                }
            }
            else
            {
                ConnectionModeUtilisateur();
                Console.WriteLine("Veuillez choisir le compte de provenance");
                Console.WriteLine("Cheque");
                Console.WriteLine("Epargne");
                string choice = Console.ReadLine();
                TypeDuCompte compte = (TypeDuCompte)Enum.Parse(typeof(TypeDuCompte), choice);
                switch (compte)
                {
                    case TypeDuCompte.Cheque:
                        compteCheque.Virer(compteEpargne, montant);
                        compteCheque.AfficherSoldeCheque();
                        compteEpargne.AfficherSoldeEpargne();
                        break;
                    case TypeDuCompte.Epargne:
                        compteEpargne.Virer(compteCheque, montant);
                        compteCheque.AfficherSoldeCheque();
                        compteEpargne.AfficherSoldeEpargne();
                        break;
                    default:
                        Console.WriteLine("Veuillez effectuer un choix valide");
                        break;
                }
            }
        }
        // Fonction qui affiche le nom utilisateur et le mot de passe
        public void AfficherIdentifiantsUsager()
        {
            Console.WriteLine("Nom utilisateur = "+ nomUtilisateur);
            Console.WriteLine("Mot de passe =  " +password);
        }
    }
}
