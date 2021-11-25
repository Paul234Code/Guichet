using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Facture
    {
        private static int identifiantFacture = 123;
        private string numeroFacture;
        private string nomFacture;
        private decimal montantFacture;
        // Les proprietes
        public string NumeroFacture { get;  } // On inscrit seulement le get car nous n'avons pas besoin de modifier les paramètres de la facture  (num, montant, nom)
        public decimal MontantFacture { get; }
        public string NomFacture { get; } 
        // Le constructeur de la classe
        public Facture( string nomFacture,decimal montantFacture)
        {
            numeroFacture = identifiantFacture.ToString();
            this.nomFacture = nomFacture;
            this.montantFacture = montantFacture;
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
            Console.WriteLine($"{numeroFacture}\t{nomFacture}\t{montantFacture}");
            

        }
    }
}
