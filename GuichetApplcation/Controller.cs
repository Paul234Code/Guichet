using System;
using System.Collections.Generic;

namespace Guichet
{
    public class Controller
    {
        static void Main()
        {
            Administrateur administrateur = new("admin", "123456");
            Guichet guichet = new(10000, EtatDuSysteme.ACTIF, administrateur)
            {
                ListeUsager = new List<Usager>()
            };
            //classe CompteEpargne
            CompteEpargne paulEpargne = new("Paul Faye", 2000, TypeDuCompte.Epargne);
            CompteEpargne firdaousEpargne = new("Firdaous El Mabrooki", 2000, TypeDuCompte.Epargne);
            CompteEpargne jonamEpargne = new("Jonam Dessureault", 2000, TypeDuCompte.Epargne);
            CompteEpargne simonEpargne = new("Simon Bugeaud", 3000, TypeDuCompte.Epargne);
            CompteEpargne katiaEpargne = new("Katia Duschenau", 4000, TypeDuCompte.Epargne);
            // des comptes cheques
            CompteCheque paulCheque = new("Paul Faye", 8000, TypeDuCompte.Cheque);
            CompteCheque firdaousCheque = new("Firdaous El Mabrooki", 8000, TypeDuCompte.Cheque);
            CompteCheque jonamCheque = new("Jonam Dessureault", 8000, TypeDuCompte.Cheque);
            CompteCheque simonCheque = new("Simon Bugeaud", 3000, TypeDuCompte.Cheque);
            CompteCheque katiaCheque = new("Katia Duschenau", 4000, TypeDuCompte.Cheque);
            // Creation d'un service
            FournisseurService service = new("Bell")
            {
                ListeFacture = new List<Facture>()
                {
                    new Facture("Telephone",200,DateTime.Now),
                    new Facture("Internet",300,DateTime.Now),
                    new Facture("Television",400, DateTime.Now),
                }
            };
            //Creation de 5 usagers
            Usager paul = new(paulEpargne, paulCheque, service, "paul1988", "1234", EtatDuCompte.ACTIF);
            Usager jonam = new(jonamEpargne, jonamCheque, service, "jonam123", "1235", EtatDuCompte.ACTIF);
            Usager firdaous = new(firdaousEpargne, firdaousCheque, service, "firdaous", "1236", EtatDuCompte.ACTIF);
            Usager simon = new(simonEpargne, simonCheque, service, "simonbug", "1237", EtatDuCompte.ACTIF);
            Usager katia = new(katiaEpargne, katiaCheque, service, "katiadus", "1238", EtatDuCompte.ACTIF);
            // Ajouter les 5 usagers dans la liste
            guichet.AjouterUsager(paul);
            guichet.AjouterUsager(jonam);
            guichet.AjouterUsager(firdaous);
            guichet.AjouterUsager(simon);
            guichet.AjouterUsager(katia);
            guichet.MenuPrincipal();
            guichet.StartApplication();



        }
    }
}