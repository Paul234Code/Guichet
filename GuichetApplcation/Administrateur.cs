namespace Guichet
{
    public class Administrateur
    {
        //Attributs
        private string administrateurId;
        private string administrateurPassword;
        // Les proprietées
        public string AdministrateurId
        {
            get => administrateurId;
            set => administrateurId = value;
        }
        public string AdministrateurPassword
        {
            get => administrateurPassword;
            set => administrateurPassword = value;
        }
        // Le constructeur de la classe Guichet
        public Administrateur(string administrateurId, string administrateurPassword)
        {

            this.administrateurId = administrateurId;
            this.administrateurPassword = administrateurPassword;
        }



    }
}