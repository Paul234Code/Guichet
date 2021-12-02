using System;
using System.Collections.Generic;

namespace Guichet
{
    public class FournisseurService
    {
        private string nomFournisseur;
        private List<Facture> listeFacture =  new List<Facture>();
        // Les proprietes
        public string NomFournisseur { get; set; }
        public List<Facture> ListeFacture { get; set; }
        // Le  Constructeur de la classe Fournisseur
        public FournisseurService(string nomFournisseur)
        {
            this.nomFournisseur = nomFournisseur;
            listeFacture = new List<Facture>();
        }
        // Ajouter une facture 
        public void AjouterFacture(Facture facture)
        {
            listeFacture.Add(facture);
        }
        // Affichage de la liste des factures et le nom du fournisseur
        public void AfficherService()
        {
            Console.WriteLine(nomFournisseur);
            foreach (Facture facture in listeFacture)
            {
                Console.WriteLine("\t" + facture.ToString());
            }
        }
        public void GetIndex(string numero)
        {
            
            foreach (var facture in listeFacture)
            {
                string numerofacture = facture.NumeroFacture;
                if (numerofacture.Equals(numero))
                {
                    listeFacture.Remove(facture);
                }
                else
                {
                    continue;
                }
            }
        }
    }
}