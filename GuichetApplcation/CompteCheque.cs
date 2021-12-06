using System;

namespace Guichet
{
    public class CompteCheque : CompteClient
    {
        private TypeDuCompte typeCompte;
        public TypeDuCompte TypeCompte { get; set; }

        public CompteCheque(string nomProprietaire, decimal balance, TypeDuCompte typeCompte) :
            base(nomProprietaire, balance)
        {
            this.typeCompte = typeCompte;

        }
        // Fonction qui affiche le solde du compte Cheque
        public void AfficherSoldeCheque()
        {
            Console.WriteLine("Solde du compte Cheque : " + Balance);

        }
    }
}
