﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Usager
    {
        private CompteClient compteCheque;
        private CompteEpargne compteEpargne;
        private static char[] nomUtilisateur = new char[7];
        private char[] userPassword = new char[3]; 
        // Le constructeur
        public Usager()
        {
            compteCheque = new CompteCheque();
            compteEpargne = new CompteEpargne();

        }
    }
}
