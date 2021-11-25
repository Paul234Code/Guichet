using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class CompteEpargne : CompteClient
    {
        private TypeDuCompte typeCompte;
        public TypeDuCompte TypeCompte  { get; set; } 

        // Le constructeur de la classe Epargne
        public CompteEpargne(string nomProprietaire, decimal balance, EtatDuCompte etatDuCompte,TypeDuCompte typeDuCompte) :
            base(nomProprietaire, balance, etatDuCompte)
        {


        }
    }
}
