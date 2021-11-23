namespace Guichet
{
    public class Administrateur
    {
        private string administrateurId = "admin";
        private string administrateurPassword = "123456";
        private Guichet guichet;
        public Administrateur(Guichet guichet)
        {
            this.guichet = guichet;
        }
       public void RemettreGuichetEnFonction()
       {

       }
        public void DéposerArgent(decimal montant)
        {

        }
        public void VoirSoldeGuichet()
        {

        }
        public void RetournerMenuPrincipal()
        {

        }

    }
}