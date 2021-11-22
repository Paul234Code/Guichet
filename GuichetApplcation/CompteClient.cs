using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public abstract class CompteClient
    {
        // attributs de la classe
        private static int numeroID = 1234567890;
        protected string numero;
        protected string nomProprietaire;
        protected decimal balance;
        protected EtatDuCompte etatDuCompte;
        // Les proprietes
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }
        // Le constructeur
        public CompteClient(string nomProprietaire, decimal balance, EtatDuCompte etatDuCompte)
        {
            numero = numeroID.ToString();
            this.nomProprietaire = nomProprietaire;
            this.balance = balance;
            this.etatDuCompte = etatDuCompte;
            numeroID++;

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }
    }
}
