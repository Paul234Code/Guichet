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

        public void DeposerArgent(decimal montant)
        {
            decimal nouveau = guichet.getSoldeGuichet();
            decimal  difference = 10000 - (nouveau + montant);
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
                Console.WriteLine(client);
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