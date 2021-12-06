using System;

namespace Guichet
{
    public class CompteEpargne : CompteClient
    {
        private TypeDuCompte typeCompte;
        public TypeDuCompte TypeCompte { get; set; }

        // Le constructeur de la classe Epargne
        public CompteEpargne(string nomProprietaire, decimal balance, TypeDuCompte typeCompte) :
            base(nomProprietaire, balance)
        {
            this.typeCompte = typeCompte;


        }
        // Fonction qui affiche le solde du compte Epargne
        public void AfficherSoldeEpargne()
        {
            Console.WriteLine("Solde du compte Epargne: " + balance);

        }
    }
}
