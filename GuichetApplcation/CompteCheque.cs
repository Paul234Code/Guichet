﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class CompteCheque : CompteClient
    {

        public CompteCheque(string nomProprietaire,decimal balance,EtatDuCompte etatDuCompte):
            base(nomProprietaire, balance, etatDuCompte)
        {

        }
    }
}
