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

            //classe CompteClient
            CompteClient paul = new CompteEpargne("Paul Faye",2000,EtatDuCompte.ACTIF);
            CompteClient jonam = new CompteEpargne("Firdaous El Mabrooki", 200, EtatDuCompte.ACTIF);
            CompteClient firdaous = new CompteEpargne("Jonam Dessureault", 200, EtatDuCompte.ACTIF);

            // des comptes cheques
            CompteClient paulCheque = new CompteCheque("Paul Faye", 2000, EtatDuCompte.ACTIF);
            CompteClient jonamCheque = new CompteCheque("Firdaous El Mabrooki", 3000, EtatDuCompte.ACTIF);
            CompteClient firdaousCheque = new CompteCheque("Jonam Dessureault", 8000, EtatDuCompte.ACTIF);

            paul.AfficherCompte();
            Console.WriteLine("==============================================================");
            jonam.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaous.AfficherCompte();
            Console.WriteLine();

            Console.WriteLine("Deposer 2000$ pour jonam , paul et Firdaous:");
            paul.Deposer(2000, DateTime.Now, "Payment salaire");
            firdaous.Deposer(2000, DateTime.Now, "Payment salaire");
            jonam.Deposer(2000, DateTime.Now, "Depot");

            Console.WriteLine("Les nouveaux soldes apres un depot de 2000$ : ");
            paul.AfficherCompte();
            Console.WriteLine("==============================================================");
            jonam.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaous.AfficherCompte();

            Console.WriteLine("Retirer 500$ pour jonam , paul et Firdaous:");
            paul.Retirer(500, DateTime.Now, "Retrait");
            firdaous.Retirer(500, DateTime.Now, "Retrait");
            jonam.Retirer(500, DateTime.Now, "Retrait");

            Console.WriteLine("Les nouveaux soldes apres un retrait de 500$ : ");
            paul.AfficherCompte();
            Console.WriteLine("==============================================================");
            jonam.AfficherCompte();
            Console.WriteLine("==============================================================");
            firdaous.AfficherCompte();



            //classes Guichet
            Console.WriteLine("==============================================================");

            Guichet guichet = new Guichet() { }; // 10000$
            Console.WriteLine("Solde initial guichet:  "+ guichet.getSoldeGuichet()); //10000$
            Console.WriteLine("Etat initial:  "+ guichet.Mode);
            Console.WriteLine("==============================================================");

            //List<Client> ListeClients = new List<Client>();
            Usager usager =  new Usager(paul,paulCheque,guichet);
           
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
            Facture facture1 = new Facture("Telephone", 200);
            Facture facture2 = new Facture("Internet", 300);
            Facture facture3 = new Facture("Television", 400);
            Console.WriteLine(facture1.ToString());
            Console.WriteLine(facture2.ToString());
            Console.WriteLine(facture3.ToString());
            facture1.AfficherInformationFacture();
            // Class Fournisseur de Services
            FournisseurService service1 = new FournisseurService("Bell");
            FournisseurService service2 = new FournisseurService("Amazon");
            FournisseurService service3 = new FournisseurService("Videotron");
            Console.WriteLine("==============================================================");
            service1.AjouterFacture(facture1);
            service1.AjouterFacture(facture2);
            service1.AjouterFacture(facture3);
            service1.AfficherService();



        }

    }
}
