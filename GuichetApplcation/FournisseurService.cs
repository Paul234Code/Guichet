using System.Collections.Generic;
using System;

namespace Guichet
{
    public class FournisseurService
    {
        private string nomFournisseur;
        private List<Facture> listeFacture;
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
            foreach(Facture facture in listeFacture)
            {
                Console.WriteLine("\t"+facture.ToString());
            }

            
        }
        public void PayementDuService(decimal frais = 2)
        {
            Console.WriteLine("Enter le numero de la facture");
            string numero = Console.ReadLine();
            Console.WriteLine(numero);
            int index =  listeFacture.FindIndex(facture =>facture.NumeroFacture == numero);
            Console.WriteLine(index);
            Console.WriteLine("Enter le montant de la facture");
            string montant = Console.ReadLine();

        }


    }
}