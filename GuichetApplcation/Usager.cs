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
        private static char[] nomUtilisateur = new char[7];
        private char[] userPassword = new char[3]; 
        // Le constructeur
        public Usager()
        {
            compteCheque = new CompteCheque();
            compteEpargne = new CompteEpargne();
            guichet = new Guichet();

        }
    }
}
