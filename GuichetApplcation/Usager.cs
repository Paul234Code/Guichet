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
        private  char[] nomUtilisateur = new char[8];
        private char[] userPassword = new char[4];
        // Les proprietes
        public CompteClient getCompteCheque { get;  }
        public Guichet Guichet { get; set; }
        public  CompteClient    getCompteEpargne { get; }
        // Le constructeur
        public Usager(CompteClient compteEpargne,CompteClient compteCheque,Guichet guichet)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.guichet = guichet;

        }
        // Retourne le mot de passe de l'usager
        public char[] GetUsagerPassword()
        {
            return userPassword;
        }
        // Methode qui retourne le le nom utilisateur de l'usager
        public char[] getUsagerId()
        {
            return nomUtilisateur;
        }
        // pour changer le mot de passe
        public  void ChangerMotdePasse()
        {

        }
        // Fonction  qui permet de deposer un monant dans un compte
        public void DeposerMontant(decimal montant)
        {

        }
        // Fonction qui permet de retirer un montant
        public void RetirerMontant(decimal montant)
        {
            compteCheque.Retirer(montant, DateTime.Now, "Retrait ");
            //compteEpargne.Retirer(montant, DateTime.Now, "Retrait ");
            guichet.Debiter(montant);


        }
        public void verrouillerCompte()
        {
            Console.WriteLine("Compte verouiller!!!");
            while (true)
            {

            }
        }
        // Afficher le solde du compte
        public void AfficherSoldeCompte()
        {



        }
        // Faire un virement entre deux compte
        public void FaireVirement(CompteCheque cheque, decimal montant)
        {
            // virer du compteEpargne vers compteCheque
           compteEpargne.Virer(cheque, montant);


        }
        // Payer une facture
        public void PayerFacture()
        {

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
                 char[] tab1 = usagerLogin.ToCharArray();
                 char[] tab2 = password.ToCharArray();
                if (Egalite(tab1, getUsagerId()) && Egalite(tab2, GetUsagerPassword()))
                {
                    Console.WriteLine("Bienvenue dans votre compte personnel");
                    MenuComptePersonnel();

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
                verrouillerCompte();
            }
            else
            {
                Console.WriteLine("Bienvenue dans votre compte personnel");
                MenuComptePersonnel();
            }


        }
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
