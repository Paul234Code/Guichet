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

    }
}