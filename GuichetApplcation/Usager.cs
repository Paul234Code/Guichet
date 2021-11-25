using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Usager:Client
    {
        private CompteClient compteCheque;
        private CompteClient compteEpargne;
        private Guichet guichet;
        private static char[] nomUtilisateur = new char[8];
        private char[] userPassword = new char[4]; 
        // Le constructeur
        public Usager()
        {
            compteCheque = new CompteCheque();
            compteEpargne = new CompteEpargne();
            guichet = new Guichet();

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

        // Méthode pour retirer un montant d'un compte

        public void RetirerMontant()
        {
            Console.WriteLine("Veuillez entrer le montant à retirer: ");
            decimal montantRetrait = Convert.ToDecimal(Console.ReadLine());
        }

        // Méthode pour Afficher le solde du compte chèque ou épargne

        public void AfficherSoldeCompte()
        {
            Console.WriteLine("Solde de votre compte: ");
            Console.WriteLine()
        }

        // Méthode pour effectuer un virement entre les comptes

        public void FaireVirement()
        {

        }

        // Méthode  pour payer facture

        public void PayerFacture()
        {

        }

        // Méthode pour fermer la session

        public void FermerSession()
        {

        }


    }
}
