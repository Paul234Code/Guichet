using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class CompteEpargne : CompteClient
    {
        // Le constructeur de la classe Epargne
        public CompteEpargne(string nomProprietaire, decimal balance, EtatDuCompte etatDuCompte) :
            base(nomProprietaire, balance, etatDuCompte)
        {

        }
    }
}
