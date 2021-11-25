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
            CompteClient paul = new CompteEpargne("Paul Faye",200,EtatDuCompte.ACTIF);
            CompteClient jonam = new CompteEpargne("Firdaous El Mabrooki", 200, EtatDuCompte.ACTIF);
            CompteClient firdaous = new CompteEpargne("Jonam Dessureault", 200, EtatDuCompte.ACTIF);
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

            Guichet guichet = new Guichet();
            Console.WriteLine(guichet.getSoldeGuichet());
            Console.WriteLine(guichet.Mode);
            Console.WriteLine("==============================================================");

            //List<Client> ListeClients = new List<Client>();
            guichet.ListeClients.

            Administrateur admin  =  new Administrateur(guichet);
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
