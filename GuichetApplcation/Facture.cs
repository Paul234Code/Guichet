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
        public string NumeroFacture { get;  }
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
        // Methode qui affiche les informations sur une facture
        public void AfficherInformationFacture()
        {

        }
    }
}
