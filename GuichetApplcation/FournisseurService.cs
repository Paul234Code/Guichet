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
                Console.WriteLine("\t" + facture.ToString());
            }

        }


        public FournisseurService(string nomFournisseur, List<Facture> listeFacture)
        {
        }

        public void AjouterNoFacture(Facture facture)
        {
            ListeFacture.Add(facture);
        }
        public void PayementDuService(decimal frais = 2)
        {
            Console.WriteLine("Entrer le numéro de la facture");
            string numero = Console.ReadLine();
            Console.WriteLine(numero);
            int index =  listeFacture.FindIndex(facture =>facture.NumeroFacture == numero);
            Console.WriteLine(index);
            Console.WriteLine("Entrer le montant de la facture");
            string saisie = Console.ReadLine();
            bool resultat = decimal.TryParse(saisie, out decimal montant);
            if (resultat)
            {
                //CompteClient.Retirer(saisie);
            }
            if (!resultat)
            {
                Console.WriteLine("Veuillez entrer un montant valide.");
                while (!resultat)
                {
                    Console.WriteLine("Veuillez entrer un montant valide.");
                }

            }
        }


    }
}