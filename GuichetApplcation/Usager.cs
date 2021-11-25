using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Usager : Client
    {
        private CompteClient compteCheque;
        private CompteClient compteEpargne;
        private Guichet guichet;
        private static char[] nomUtilisateur = new char[8];
        private char[] userPassword = new char[4];
        // Les proprietes
        public CompteClient getCompteCheque { get;  }
        public Guichet Guichet { get; set; }
        public  CompteClient    getCompteEpargne { get; }
        // Le constructeur
        public Usager(CompteClient compteEpargne,CompteClient compteCheque,Guichet guichet)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.guichet = guichet;

        }
        // Fonction qui permet de changer le mot de passe

        public void ChangerMotDePasse()
        {
            Console.WriteLine("Veuillez entrer votre nouveau mot de passe: ");
            char newPassword = Convert.ToChar(Console.ReadLine());

            if (newPassword == userPassword[4])
            {
                Console.WriteLine("Veuillez entrer un mot de passe valide");
            }
            else if (newPassword != userPassword[4])
            {
                newPassword = userPassword[4];
            }

        }
        // Fonction  qui permet de déposer un montant dans un compte
        public void DéposerMontant(decimal amount)
        {
            compteCheque.Deposer(amount, DateTime.Now, "depot");
            compteEpargne.Deposer(amount, DateTime.Now, "depot");
        }

        // Fonction qui permet de retirer un montant dans un compte
        public void RetirerMontant(decimal amount)
        {
            compteCheque.Retirer(amount, DateTime.Now, "retrait");
            compteEpargne.Retirer(amount, DateTime.Now, "depot");
        }
        // Afficher le solde du compte
        public void AfficherSoldeCompte()
        {

        }
        // Faire un virement entre deux compte
        public void FaireVirement()
        {

        }
        // Payer une facture
        public void PayerFacture()
        {

        }
        public void FermerSession()
        {

        }
            

    }
}
