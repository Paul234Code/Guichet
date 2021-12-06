using System;
using System.Collections.Generic;

namespace Guichet
{
    public class FournisseurService
    {
        private string nomFournisseur;
        private List<Facture> listeFacture = new List<Facture>();
        // Les proprietes
        public string NomFournisseur {
            get => nomFournisseur;
            set => nomFournisseur = value;
        }
        public List<Facture> ListeFacture {
            get => listeFacture;
            set => listeFacture = value;
        }
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
        public int GetIndex(string numero)
        {
            int index = 0;
            for (int i = 0; i < listeFacture.Count; i++)
            {
                if (listeFacture[i].NumeroFacture == numero)
                {
                    index = i;
                }
            }
            return index;
        }
        // Fonction qui retourne un fournisseur de service
        public FournisseurService GetFournisseurService(string nom)
        {
           
            return new FournisseurService(nom) { listeFacture = new List<Facture>() };

        }
    }
}