﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string NumeroFacture { get;  } //mettre get sans set parcq on a pas besoin de modifier le nom et le montant
        public decimal MontantFacture { get; }
        public string NomFacture { get; } 
        // Le constructeur de la classe
        public Facture( string nomFacture,decimal montantFacture,DateTime dateFacture)
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
        // Fonction qui retourne le numero de la facture
        public string GetNumeroFacture()
        {
            return numeroFacture;
        }
    }
}
