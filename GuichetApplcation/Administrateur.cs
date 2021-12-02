using System;
namespace Guichet
{
    public class Administrateur:Client
    {
        private string administrateurId = "admin";
        private string administrateurPassword = "123456";
        private Guichet guichet; // parce que c'est l'administrateur qui manipule le guichet, pour acceder aux fonctions de l'objet
        // Le constructeur de la classe Guichets
        public Administrateur(Guichet guichet,string administrateurId, string administrateurPassword)
        {
            this.guichet = guichet;
            this.administrateurId = administrateurId;
            this.administrateurPassword = administrateurPassword;
        }
        // Fonction qui permet de remettre le guichet en fonction
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
        // Fonction qui permet de deposer un montant dans le guichet
        public void DeposerMontantGuichet()
        {
            Console.WriteLine("Entrer le montant du depot ");
            string saisie = Console.ReadLine();
            bool resulatConversion = decimal.TryParse(saisie, out decimal montant);
            decimal soldeCourant = guichet.getSoldeGuichet(); // le restant dans le guichet 5000$
            decimal somme = soldeCourant + montant;
            if(resulatConversion && somme == 10000)
            {
               guichet.setSoldeGuichet(somme);

            }
            else
            {
                while (!somme.Equals(10000)&& resulatConversion)
                {
                    Console.WriteLine("Le solde maximal du guichet doit etre 10000$");
                    Console.WriteLine("Entrer le montant du depot ");
                    saisie = Console.ReadLine();
                    resulatConversion = decimal.TryParse(saisie, out montant);
                    soldeCourant = guichet.getSoldeGuichet(); // le restant dans le guichet 5000$
                    somme = soldeCourant + montant;

                }
                guichet.setSoldeGuichet(somme);
            }
            
               

        }
        // Fonction qui Affiche le solde courant du Guichet
        public void VoirSoldeGuichet()
        {
            Console.WriteLine(guichet.getSoldeGuichet());

        }
        // Fonction qui Affiche la liste des comptes 
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