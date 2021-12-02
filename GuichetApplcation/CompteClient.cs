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
        protected EtatDuCompte etatDuCompte;
        // Les proprietes
        public string Numero { get; }
        public string NomProprietaire { get; }
        public EtatDuCompte EtatDuCompte { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        // Le constructeur de la classe CompteClient
        public CompteClient(string nomProprietaire, decimal initialBalance, EtatDuCompte etatDuCompte)
        {
            numero = numeroID.ToString();
            this.nomProprietaire = nomProprietaire;
            this.etatDuCompte = etatDuCompte;
            numeroID++;
            Deposer(initialBalance, DateTime.Now, "Solde initial");
        }
        // Methode qui depose un montant positif dans un compte

        public void Deposer(decimal amount, DateTime date, string information)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("montant du depot doit etre positif");
            }
            var depot = new Transaction(amount, date, information);
            allTransactions.Add(depot);
        }
        // Methode qui retire un montant valide dans un compte
        public void Retirer(decimal amount, DateTime date, string information)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("montant du retrait doit etre positif");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Fonds insufisant pour le retrait");
            }
            var retrait = new Transaction(-amount, date, information);
            allTransactions.Add(retrait);
        }
        // Methode qui Affiche les informations d'un compte ( Cheque ou Epargne)
        public void AfficherCompte()
        {
            Console.WriteLine("Numero du compte: " + numero);
            Console.WriteLine("Nom proprietaire: " + nomProprietaire);
            Console.WriteLine("Solde :" + Balance);
            Console.WriteLine("Etat du Compte : " + etatDuCompte);
        }
        // Methode qui effectue un virement entre deux compte
        public void Virer(CompteClient Receiver, decimal amount)
        {
            // on debit le compte courant (this)
            Retirer(amount, DateTime.Now, "Retrait");
            Receiver.Deposer(amount, DateTime.Now, "Depot");
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
            Console.WriteLine("Solde du compte: " + Balance);
        }
    }
}
