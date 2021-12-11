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
            string format = string.Format("{0:0,0.00}", balance);
            string chaine = format.Replace(',', '.');
            Console.WriteLine($"Solde du compte Cheque : {chaine}" );

        }
    }
}
