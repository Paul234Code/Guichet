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

        }

        // Méthode pour déposer un montant

        public void DéposerMontant()
        {

        }

        // Méthode pour retirer un montant d'un compte

        public void RetirerMontant()
        {

        }

        // Méthode pour Afficher le solde du compte chèque ou épargne

        public void AfficherSoldeCompte()
        {

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
