using System.Collections.Generic;

namespace Guichet
{
    public class FournisseurService
    {
        private string nomFournisseur;
        private List<Facture> listeFacture;

        public string NomFournisseur { get; set; }
        public List<Facture> ListeFacture { get; set; } 


    }
}