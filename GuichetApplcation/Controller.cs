using System;
using System.Collections.Generic;
using System.Threading;

namespace Guichet
{
    public class Controller
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================================");

            //classe CompteEpargne
            CompteClient paulEpargne = new CompteEpargne("Paul Faye",2000,EtatDuCompte.ACTIF,TypeDuCompte.Epargne);
            CompteClient firdaousEpargne = new CompteEpargne("Firdaous El Mabrooki", 2000, EtatDuCompte.VEROUILLE, TypeDuCompte.Epargne);
            CompteClient jonamEpargne = new CompteEpargne("Jonam Dessureault", 2000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);

            // des comptes cheques
            CompteClient paulCheque = new CompteCheque("Paul Faye", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteClient firdaousCheque = new CompteCheque("Firdaous El Mabrooki", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteClient jonamCheque = new CompteCheque("Jonam Dessureault", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);

            paulEpargne.AfficherCompte();
            Console.WriteLine("-------------------------------------------------------------");
            paulCheque.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaousEpargne.AfficherCompte();
            Console.WriteLine("==============================================================");         
            jonamEpargne.AfficherCompte();
            Console.WriteLine();

            Console.WriteLine("Deposer 2000$ pour jonam , paul et Firdaous:");
            paulEpargne.Deposer(2000, DateTime.Now, "Payment salaire");
            firdaousEpargne.Deposer(2000, DateTime.Now, "Payment salaire");
            jonamEpargne.Deposer(2000, DateTime.Now, "Depot");

            Console.WriteLine("Les nouveaux soldes apres un depot de 2000$ : ");
            paulEpargne.AfficherCompte();
            Console.WriteLine("==============================================================");
            jonamEpargne.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaousEpargne.AfficherCompte();

            Console.WriteLine("Retirer 500$ pour jonam , paul et Firdaous:");
            paulEpargne.Retirer(500, DateTime.Now, "Retrait");
            firdaousEpargne.Retirer(500, DateTime.Now, "Retrait");
            jonamEpargne.Retirer(500, DateTime.Now, "Retrait");

            Console.WriteLine("Les nouveaux soldes apres un retrait de 500$ : ");
            paulEpargne.AfficherCompte();
            Console.WriteLine("==============================================================");
            jonamEpargne.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaousEpargne.AfficherCompte();



            //classes Guichet
            Console.WriteLine("==============================================================");

            Guichet guichet = new Guichet() { }; // 10000$
            Console.WriteLine("Solde initial guichet:  "+ guichet.getSoldeGuichet()); //10000$
            Console.WriteLine("Etat initial:  "+ guichet.Mode);
            Console.WriteLine("==============================================================");

            //List<Client> ListeClients = new List<Client>();
            Usager usager =  new Usager(paulEpargne,paulCheque,guichet);
           
             usager.RetirerMontant(200);
                       
            Console.WriteLine("nouveau solde guichet: "+ guichet.getSoldeGuichet()); //9800$

            Administrateur admin  =  new Administrateur(guichet);  //9800$   

           
           
            admin.DeposerArgent(200); //10000$ ????
            Console.WriteLine("solde guichet dans try :" + guichet.Solde);

            Console.WriteLine("nouveau solde guichet deuxieme: " + guichet.getSoldeGuichet());
            Console.WriteLine("==============================================================");
            Console.WriteLine(admin.GetAdministrateurId());
            Console.WriteLine(admin.GetAdministrateurPassword());
            Console.WriteLine("==============================================================");
            // class Facture
            Facture factureBell1 = new Facture("Telephone", 200);
            Facture factureBell2 = new Facture("Internet", 300);
            Facture factureBell3 = new Facture("Television", 400);
            Facture factureAmazon1 = new Facture("Telephone", 201);
            Facture factureAmazon2 = new Facture("Internet", 301);
            Facture factureAmazon3 = new Facture("Television", 401);
            Facture factureVideotron1 = new Facture("Telephone", 202);
            Facture factureVideotron2 = new Facture("Internet", 302);
            Facture factureVideotron3 = new Facture("Television", 402);

            Console.WriteLine(factureBell1.ToString());
            Console.WriteLine(factureBell2.ToString());
            Console.WriteLine(factureBell3.ToString());
            Console.WriteLine(factureAmazon1.ToString());
            Console.WriteLine(factureAmazon2.ToString());
            Console.WriteLine(factureAmazon3.ToString());
            Console.WriteLine(factureVideotron1.ToString());
            Console.WriteLine(factureVideotron2.ToString());
            Console.WriteLine(factureVideotron3.ToString());

            factureBell1.AfficherInformationFacture();
            // Class Fournisseur de Services
            FournisseurService service1 = new FournisseurService("Bell");
            FournisseurService service2 = new FournisseurService("Amazon");
            FournisseurService service3 = new FournisseurService("Videotron");
            Console.WriteLine("==============================================================");
            service1.AjouterFacture(factureBell1);
            service1.AjouterFacture(factureBell2);
            service1.AjouterFacture(factureBell3);

            service2.AjouterFacture(factureAmazon1);
            service2.AjouterFacture(factureAmazon2);
            service2.AjouterFacture(factureAmazon3);

            service3.AjouterFacture(factureVideotron1);
            service3.AjouterFacture(factureVideotron2);
            service3.AjouterFacture(factureVideotron3);

            service1.AfficherService();

            //Cré
           


        }

    }
}
