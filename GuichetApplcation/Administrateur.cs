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
            if(montant < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant),"Le montant doit etre positif");
            }
            if(montant > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Le montant maximal doit etre 10000");

            }
            if(guichet.Solde+ montant > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(montant),"Invalide operation");
            }
            if(guichet.Solde + montant < 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Invalide operation");

            }
            if(montant+guichet.Solde == 10000)
            {
                guichet.Solde += montant;

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