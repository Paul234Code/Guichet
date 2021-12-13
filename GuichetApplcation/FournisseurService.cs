using System;
using System.Collections.Generic;

namespace Guichet
{
    public class FournisseurService
    {
        private static int numero = 1;
        private string nomFournisseur;
        private string numeroFournisseur;
        private List<Facture> listeFacture = new List<Facture>();
        // Les proprietes
        public string NomFournisseur
        {
            get => nomFournisseur;
            set => nomFournisseur = value;
        }
        public string NumeroFournisseur {
            get => numeroFournisseur;
            set => numeroFournisseur = value; } 
        public List<Facture> ListeFacture
        {
            get => listeFacture;
            set => listeFacture = value;
        }
        // Le  Constructeur de la classe Fournisseur
        public FournisseurService(string nomFournisseur)
        {
            numeroFournisseur=  numero.ToString();
            this.nomFournisseur = nomFournisseur;
            listeFacture = new List<Facture>();
            numero++;
        }
        // Ajouter une facture dans la liste des factures
        public void AjouterFacture(Facture facture)
        {
            listeFacture.Add(facture);
        }
        // Affichage de la liste des factures et le nom du fournisseur
        public void AfficherService()
        {
            Console.WriteLine(nomFournisseur.ToUpper());
            Console.WriteLine("----------------------------------");
            if (listeFacture.Count == 0)
            {
                Console.WriteLine("Aucune facture  a payer");
            }
            else
            {
                foreach (Facture facture in listeFacture)
                {
                    Console.WriteLine("  " + facture.ToString());
                }
                Console.WriteLine();
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
        public int GetFactureByAmount(decimal montant)
        {
            int index = 0;
            for (int i = 0; i < listeFacture.Count; i++)
            {
                if (listeFacture[i].MontantFacture == montant)
                {
                    index = i;
                }
            }
            return index;


        }
    }
}