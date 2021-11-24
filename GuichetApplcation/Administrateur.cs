namespace Guichet
{
    public class Administrateur:Client
    {
        private string administrateurId = "admin";
        private string administrateurPassword = "123456";
        private Guichet guichet;
        private CompteClient compteClient;
        public Administrateur(Guichet guichet)
        {
            this.guichet = guichet;
        }
       public void RemettreGuichetEnFonction()
       {

       }
        // 
        public void DéposerArgent(decimal montant)
        {

        }
        // Affiche le solde courant du Guichet
        public void VoirSoldeGuichet()
        {

        }
        // Afficher la liste des comptes 
        public  void VoirListeDesCompte()
        {

            

        }
        public void RetournerMenuPrincipal()
        {

        }

    }
}