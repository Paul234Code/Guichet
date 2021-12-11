using System;


namespace Guichet
{
    public class Usager
    {
        // Les attributs de la classe Usager
        private CompteCheque compteCheque;
        private CompteEpargne compteEpargne;
        private FournisseurService fournisseurService;
        private EtatDuCompte etat;
        private string nomUtilisateur;
        private string password;
        // Les proprietes de la classe Usager
        public CompteCheque CompteCheque
        {
            get => compteCheque;
        }
        public EtatDuCompte Etat
        {
            get => etat;
            set => etat = value;
        }
        public FournisseurService FournisseurService
        {
            get => fournisseurService;
            set => fournisseurService = value;
        }
        public CompteEpargne CompteEpargne
        {
            get => compteEpargne;
        }
        public string Password
        {
            get => password;
            set => password = value;
        }
        public string NomUtilisateur
        {
            get => nomUtilisateur;
            set => nomUtilisateur = value;
        }
        // Le constructeur de la classe Usager
        public Usager(CompteEpargne compteEpargne, CompteCheque compteCheque, FournisseurService fournisseurService, string nomUtilisateur, string password, EtatDuCompte etat)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.fournisseurService = fournisseurService;
            this.password = password;
            this.nomUtilisateur = nomUtilisateur;
            this.etat = etat;
        }
        // Fonction qui permet de verouiller le compte
        public void Verrouiller()
        {
            etat = EtatDuCompte.VEROUILLE;

        }
        // Fonction qui permet de deverouiller un compte
        public void Deverrouiller()
        {
            etat = EtatDuCompte.ACTIF;
        }
        // Fonction qui affiche le nom utilisateur et le mot de passe
        public void AfficherIdentifiantsUsager()
        {
            Console.WriteLine("Nom utilisateur = " + nomUtilisateur);
            Console.WriteLine("Mot de passe =  " + password);
        }
    }
}