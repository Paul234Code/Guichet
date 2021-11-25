using System;
using System.Collections.Generic;
using System.Threading;

namespace Guichet
{
    public class Controller
    {
        static void Main(string[] args)
        {
            Guichet guichet = new ();
            List<Client> ListeClients = new List<Client>();
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
