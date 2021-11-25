using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class CompteCheque : CompteClient
    {
        private TypeDuCompte typeCompte;
        public TypeDuCompte TypeCompte { get; set; }

        public CompteCheque(string nomProprietaire,decimal balance,EtatDuCompte etatDuCompte,TypeDuCompte typeCompte):
            base(nomProprietaire, balance, etatDuCompte)
        {
            this.typeCompte = typeCompte;

        }
    }
}
