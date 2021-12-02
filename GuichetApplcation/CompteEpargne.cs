using System;

namespace Guichet
{
    public class CompteEpargne : CompteCheque
    {
        private TypeDuCompte typeCompte;
        public TypeDuCompte TypeCompte { get; set; }

        // Le constructeur de la classe Epargne
        public CompteEpargne(string nomProprietaire, decimal balance, EtatDuCompte etatDuCompte, TypeDuCompte typeCompte) :
            base(nomProprietaire, balance, etatDuCompte)
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
