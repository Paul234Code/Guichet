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
            Console.WriteLine("Voulez-vous remettre le systeme en fonction (O/N)?");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "O":
                    break;
                
                case "N":
                    Console.WriteLine("Systeme Hors Service,guichet en " + EtatDuSysteme.PANNE);
                    break;
                default:
                    Console.WriteLine("Operation invalide");
                    break;
            }

       }
        // 
        public void DeposerArgent()
        {
            Console.WriteLine("Entrer le montant du depot du guichet");
            string saisie = Console.ReadLine();
            bool resulatConversion = decimal.TryParse(saisie, out decimal montant);
            decimal soldeCourant = guichet.getSoldeGuichet(); // le restant dans le guichet 5000$
            while(resulatConversion)
            {
                if(soldeCourant + montant > 10000 || soldeCourant + montant < 10000)
                {
                    Console.WriteLine("Montant le montant maximal doit etre 10000$");              
                    Console.WriteLine("Enter le montant du depot");
                    saisie = Console.ReadLine();
                    resulatConversion = decimal.TryParse(saisie, out montant);
                    
                }
                else
                {
                    guichet.Solde += montant;
                    break;
                }
               
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
        public bool ValidationAdministrateur(string userAdmin, string password)
        {
            return password.Equals(GetAdministrateurPassword()) && userAdmin.Equals(GetAdministrateurId());
        }
        // Fonction qui valide la connection d'un administrateur
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
                if(!ValidationAdministrateur(userAdmin, password))
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
                    DeposerArgent();
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
        

        public void seconnecteradmin()
        {
            int compteur = 0;
            Console.WriteLine("Enter votre nom Utilisateur: ");
            string userAdmin = Console.ReadLine();
            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            if (userAdmin.Equals(string.Empty) || (password.Equals(string.Empty))) ;
            {
                Console.WriteLine("userAdmin or password invalide");
            }
            if (!userAdmin.Equals(GetAdministrateurId()) || !password.Equals(GetAdministrateurPassword()))
            {
                Console.WriteLine("userAdmin or password invalide");
            }while(!userAdmin.Equals(GetAdministrateurId()) || !password.Equals(GetAdministrateurPassword()) && compteur < 3)
            {
                Console.WriteLine("Enter votre nom Utilisateur: ");
                userAdmin = Console.ReadLine();
                Console.WriteLine("Enter your password");
                password = Console.ReadLine();
                compteur++;
            }
            
            if(compteur == 3)
            {
                Console.WriteLine("Trop de tentatives, votre compte est vérouillé");
            }
            
        }

    }
}