using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Guichet
{
    public class Usager : Client
    {
        private CompteClient compteCheque;
        private CompteClient compteEpargne;
        private Guichet guichet;
        private FournisseurService fournisseurService;
        private  char[] nomUtilisateur = new char[8] {'p','a','u','l','1','9','8','8'};
        private char[] userPassword = new char[4] {'1','2','3','4'};
        // Les proprietes
        public CompteClient getCompteCheque { get;  }
        public Guichet Guichet { get; set; }
        public  CompteClient    getCompteEpargne { get; }
        // Le constructeur de la classe Usager
        public Usager(CompteClient compteEpargne,CompteClient compteCheque,Guichet guichet,FournisseurService fournisseurService)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.guichet = guichet;
            this.fournisseurService = fournisseurService;

        }
        // Retourne le mot de passe de l'usager
        public char[] GetUsagerPassword()
        {
            return userPassword;
        }
        // Methode qui modifie le mot de passe
        public void SetUsagerPassword(char[] password)
        {
           
          Array.Copy(password, userPassword,  userPassword.Length);
        }
        // Methode qui retourne le le nom utilisateur de l'usager
        public char[] getUsagerId()
        {
            return nomUtilisateur;
        }
        // Fonction qui permet de changer le mot de passe de l'usager
        public  void ChangerMotdePasse()
        {
            Console.WriteLine("Entrer le mot de passe actuel:");
            char[] actuelMotPasse = Console.ReadLine().ToArray();
            Console.WriteLine("Entrer le nouveau mot de passe:");
            char[] nouveauMotPasse = Console.ReadLine().ToArray();
            Console.WriteLine("Confirmer le nouveau mot de passe :");
            char[] confirmation = Console.ReadLine().ToArray();

            if (!nouveauMotPasse.Length.Equals(actuelMotPasse.Length))
            {
                Console.WriteLine("Le format du nouveau mot de passe est incorrect");
            }
            else if (nouveauMotPasse.SequenceEqual(actuelMotPasse))
            {
                Console.WriteLine("Le nouveau de mot de passe doit etre different de l'actuel mot de passe");
            }
            else if(confirmation.SequenceEqual(nouveauMotPasse))
            {
                Array.Copy(nouveauMotPasse, actuelMotPasse, actuelMotPasse.Length);
                Console.WriteLine("Changement de mot de passe effectif");
                MenuComptePersonnel();
            }
            else
            {
                Console.WriteLine("Veuillez le nouveau Mot de passe ");
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
                Console.WriteLine("dans quel compte le dépôt doit être effectué?");
                Console.WriteLine("1- Compte Cheque");
                Console.WriteLine("2- Compte Epargne");
                string compte = Console.ReadLine(); 
                switch (compte)
                {
                    case "1":
                        try
                        {
                            compteCheque.Deposer(montant, DateTime.Now, "Depot");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("Nouveau Solde du compte cheque : " + compteCheque.Balance);
                        break;
                    case "2":
                        try
                        {
                            compteEpargne.Deposer(montant, DateTime.Now, "Depot");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
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
        }
        // Fonction qui permet de retirer un montant
        public void RetirerMontant(decimal montant)
        {
             Console.WriteLine("Veuillez choisir lecompte à débiter");
            Console.WriteLine();
            Console.WriteLine("1- Compte Cheque");
            Console.WriteLine("2- Compte Epargne");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    guichet.DebiterGuichet(montant);
                    compteCheque.Retirer(montant, DateTime.Now, "Retrait");
                    break;
                case "2":
                    guichet.DebiterGuichet(montant);
                    compteEpargne.Retirer(montant, DateTime.Now, "Retrait");
                    break;
                default:
                    Console.WriteLine("Operation  invalide");
                    break;
            }
             compteCheque.Retirer(montant, DateTime.Now, "Retrait ");
            //compteEpargne.Retirer(montant, DateTime.Now, "Retrait ");
            guichet.DebiterGuichet(montant);
        }
     }
        // Afficher le solde du compte
        public void AfficherSoldeCompte()
        {
            Console.WriteLine("solde du compte Chèque ou du compte Epargne?");
            Console.WriteLine("1- Cheque");
            Console.WriteLine("2- Epargne");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    compteCheque.AfficherSoldeCompte();
                    MenuComptePersonnel();
                    break;
                case"2":
                   compteEpargne.AfficherSoldeCompte();
                    MenuComptePersonnel();
                   break ;
                default:
                    Console.WriteLine("Operation  invalide");
                    break;
            }
        }
        // Faire un virement entre deux compte
        public void FaireVirement(CompteCheque cheque, decimal montant)
        {
            // virer du compteEpargne vers compteCheque
           compteEpargne.Virer(cheque, montant);


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
                    fournisseurService.AfficherService();
                    break;
                case "Bell":
                    fournisseurService.AfficherService();
                    break;
                case "Videotron":
                    fournisseurService.AfficherService();
                    break ;
                default :
                    Console.WriteLine("Operation invalide");
                    break ;


            }



        }
        public void FermerSession()
        {
            

        }
        // Fonction qui permet de comparer l'egalite de deux tableaux de caraetres
        private bool Egalite(char[] tab1, char[] tab2)
        {
            return tab1.SequenceEqual(tab2);
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
                 char[] tabLogin = usagerLogin.ToCharArray();
                 char[] tabPassword = password.ToCharArray();
                if (Egalite(tabLogin, getUsagerId()) && Egalite(tabPassword, GetUsagerPassword()))
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
    }
}
