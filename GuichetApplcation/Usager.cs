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
        private static char[] nomUtilisateur = new char[7];
        private char[] userPassword = new char[3];
        // Reference pour debiter le Guichet pendant un retrait
        private Guichet guichet;
        // une reference pour payer ses factures chez un fournisseur
        private FournisseurService fournisseur;
    }
}
