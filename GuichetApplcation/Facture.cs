using System;

namespace Guichet
{
    public class Facture
    {
        private static int identifiantFacture = 123; //pour donner un nouveau numero à chaque nouvelle facture
        private string numeroFacture;
        private string nomFacture;
        private decimal montantFacture;
        private DateTime dateFacture;
        // Les proprietes
        public string NumeroFacture {
            get => numeroFacture;
            set => numeroFacture = value;
        } 
        public decimal MontantFacture {
            get => montantFacture;
            set => montantFacture = value;
        }
        public string NomFacture {
            get => nomFacture;
            set => nomFacture = value;
        }
        public DateTime DateFacture {
            get => dateFacture; 
            set => dateFacture = value; 
        }

        // Le constructeur de la classe Facture
        public Facture(string nomFacture, decimal montantFacture, DateTime dateFacture)
        {
            numeroFacture = identifiantFacture.ToString();
            this.nomFacture = nomFacture;
            this.montantFacture = montantFacture;
            this.dateFacture = dateFacture;
            identifiantFacture++;
        }
        public override string ToString()
        {
            return $"{numeroFacture} \t{nomFacture}\t{montantFacture}";
        }
        // Methode qui affiche les informations sur une facture
        public void AfficherInformationFacture()
        {
            Console.WriteLine("numero\t nom Facture\tmontantFacture");
            Console.WriteLine($"{numeroFacture}\t{nomFacture}\t{montantFacture}\t{dateFacture}");
        }
        
    }
}
