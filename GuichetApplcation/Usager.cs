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
        // pour changer le mot de passe
        public  void ChangerMotdePasse()
        {

        }
        // Fonction  qui permet de deposer un monant dans un compte
        public void DeposerMontant(decimal montant)
        {

        }
        // Fonction qui permet de retirer un montant
        public void RetirerMontant(decimal montant)
        {
            compteCheque.Retirer(montant, DateTime.Now, "Retrait ");
            //compteEpargne.Retirer(montant, DateTime.Now, "Retrait ");
            guichet.Debiter(montant);


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

        // Méthode pour changer de MotDePasse
        public void ChangerMotDePasse()
        {
            Console.WriteLine("Veuillez entrer votre nouveau mot de passe: ");
            char newPassword = Convert.ToChar(Console.ReadLine());

            if(newPassword == userPassword[4])
            {
                Console.WriteLine("Veuillez entrer un mot de passe valide");
            }
            else if (newPassword != userPassword[4])
            {
                newPassword = userPassword[4];
            }
            
        }

        // Méthode pour déposer un montant

        public void DéposerMontant()
        {
            Console.WriteLine("Veuillez entrer le montant à déposer: ");
            decimal montantDépôt = Convert.ToDecimal(Console.ReadLine());

            if(montantDépôt < 0)
            {
                Console.WriteLine("Veuillez entrer un montant positif");
            }
            else if(montantDépôt > 0)
            {
                Guichet.Solde = Guichet.Solde + montantDépôt;
            }//Pas finit !! Vous pouvez modifier si vous voulez faire autre chose
        }

    }
}
