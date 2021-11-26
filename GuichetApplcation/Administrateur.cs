using System;
namespace Guichet
{
    public class Administrateur:Client
    {
        private string administrateurId = "admin";
        private string administrateurPassword = "123456";
        private Guichet guichet;
        // Le constructeur de la classe Guichet
        public Administrateur(Guichet guichet)
        {
            this.guichet = guichet;
        }
       public void RemettreGuichetEnFonction()
       {

       }
        // 
        public void DeposerArgent(decimal montant)
        {
            decimal nouveau = guichet.getSoldeGuichet(); // le restant dans le guichet 5000$
            decimal  difference = 10000 - (nouveau + montant); // 4000$
            if (difference == 0)
            {
                guichet.Solde += montant;
            }
            else if(difference > 0)
            {
                guichet.Solde += difference;

            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(montant),"Invalide operation montant eleve");
            }
               

        }
        // Affiche le solde courant du Guichet
        public void VoirSoldeGuichet()
        {
            Console.WriteLine(guichet.getSoldeGuichet());

        }
        // Afficher la liste des comptes 
        public  void VoirListeDesCompte()
        {
            foreach (var client in guichet.ListeClients)
            {
                //Usager usager = client as Usager;
                if(client is Usager usager)
                {
                    usager.getCompteCheque.AfficherCompte();
                    usager.getCompteEpargne.AfficherCompte();
                }

            }

            

        }
        public void RetournerMenuPrincipal()
        {

        }
        // Methode qui retourne le nom utilisateur du compte admin
        public string GetAdministrateurId()
        {
            return administrateurId;
        }
        // retourne le mot de passe 
        public string GetAdministrateurPassword()
        {
            return administrateurPassword;
        }
        // Fonction qui valide le mot de passe et le nom utilisateur
        public bool Validation(string userAdmin, string password)
        {
            return password.Equals(GetAdministrateurPassword()) && userAdmin.Equals(GetAdministrateurId());
        }
        // Fonction qui valide la connection d'un administrateur
        public void seconnecterAdmin()
        {
            int compteur = 0;
            string userAdmin;
            string password;
            while (compteur < 3) 
            {
                Console.WriteLine("Enter  Administrator Username");
                userAdmin = Console.ReadLine();
                Console.WriteLine("Enter Administrator password");
                password = Console.ReadLine();
                if(!Validation(userAdmin, password))
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
                guichet.MenuAdmin();
            }
        }
        // Les choix des operations de l'administrateur
        public void SelectChoixAdmin(string choixadmin)
        {
            switch (choixadmin)
            {
                case "1":
                    RemettreGuichetEnFonction();
                    break;
                case "2":
                    DeposerArgent(800);
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
        public void SelectionCompte(string choix)
        {
            switch (choix)
            {
                case "1":
                    seconnecterUtilisateur();
                    break;
                case "2":
                    seconnecterAdmin();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

            }
        }

    }
}