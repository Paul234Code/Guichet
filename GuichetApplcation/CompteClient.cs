using System;
using System.Collections.Generic;
using System.Text;

namespace Guichet
{
    public abstract class CompteClient
    {
        // attributs de la classe
        private List<Transaction> allTransactions = new List<Transaction>();
        private static int numeroID = 1234567890; //permet de donner un nouveau num de compte à chaque fois.
        protected string numero;

        protected string nomProprietaire;
        protected decimal balance;
        // Les proprietes
        public string Numero {
            get => numero; 
        }
        public string NomProprietaire { 
            get => nomProprietaire;
        }
        
        public decimal Balance {
            get => balance;
            set => balance = value; 
        }



        // Le constructeur de la classe CompteClient
        public CompteClient(string nomProprietaire, decimal initialBalance)
        {
            numero = numeroID.ToString();
            this.nomProprietaire = nomProprietaire;
            numeroID++;
            balance = initialBalance;
        }
        // Methode qui depose un montant positif dans un compte

        public void Deposer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("montant du depot doit etre positif");
            }
            balance += amount;
        }
        // Methode qui retire un montant valide dans un compte
        public void Retirer(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("montant du retrait doit etre positif");
            }
            else if (balance < amount)
            {
                Console.WriteLine("Fonds insufisant");
            }
            else
            {
                balance -= amount;

            }

        }
        // Methode qui Affiche les informations d'un compte ( Cheque ou Epargne)
        public void AfficherCompte()
        {
            Console.WriteLine("Numero du compte: " + numero);
            Console.WriteLine("Nom proprietaire: " + nomProprietaire);
            Console.WriteLine("Solde :" + balance);
            
        }
        // Methode qui effectue un virement entre deux compte
        public void Virer(CompteClient Receiver, decimal amount)
        {
            // on debit le compte courant (this)
            Retirer(amount);
            Receiver.Deposer(amount);
        }
        // Fonction qui affiche l'historique du compte
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }
        // Fonction qui affiche seulement le solde du compte
        public void AfficherSoldeCompte()
        {
            Console.WriteLine("Solde du compte: " + balance);
        }

        

    }
}
