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
        // Le constructeur
        public Usager(CompteEpargne compteEpargne,CompteCheque compteCheque,Guichet guichet)
        {
            this.compteCheque = compteCheque;
            this.compteEpargne = compteEpargne;
            this.guichet = guichet;

        }
        // pour changer le mot de passe
        public  void ChangerMotdePasse()
        {

        }
        // 

    }
}
