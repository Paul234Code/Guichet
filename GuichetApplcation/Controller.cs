using System;
using System.Collections.Generic;


namespace Guichet
{
    public class Controller
    {
        static void Main()
        {
            Guichet guichet = new Guichet(10000, EtatDuSysteme.ACTIF)
            {
                ListeUsager = new List<Usager>()
            };
            Administrateur administrateur = new(guichet, "admin", "123456");
            //classe CompteEpargne
            CompteEpargne paulEpargne = new CompteEpargne("Paul Faye", 2000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);
            CompteEpargne firdaousEpargne = new CompteEpargne("Firdaous El Mabrooki", 2000, EtatDuCompte.VEROUILLE, TypeDuCompte.Epargne);
            CompteEpargne jonamEpargne = new CompteEpargne("Jonam Dessureault", 2000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);
            CompteEpargne simonEpargne = new CompteEpargne("Simon Bugeaud",3000,EtatDuCompte.ACTIF,TypeDuCompte.Epargne);
            CompteEpargne katiaEpargne = new CompteEpargne("Katia Duschenau", 4000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);
            // des comptes cheques
            CompteCheque paulCheque = new CompteCheque("Paul Faye", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteCheque firdaousCheque = new CompteCheque("Firdaous El Mabrooki", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteCheque jonamCheque = new CompteCheque("Jonam Dessureault", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteCheque simonCheque = new CompteCheque("Simon Bugeaud", 3000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            CompteCheque katiaCheque = new CompteCheque("Katia Duschenau", 4000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            // Creation d'un service
            FournisseurService service = new("Bell")
            {
                ListeFacture = new List<Facture>()
            };
            //Creation de 5 usagers
            Usager paul = new Usager(paulEpargne, paulCheque, guichet, service,"paul1988", "1234");
            Usager jonam = new Usager(jonamEpargne, jonamCheque, guichet, service, "jonam123", "1235");
            Usager firdaous = new Usager(firdaousEpargne, firdaousCheque, guichet, service, "firdaous", "1236");
            Usager simon = new Usager(simonEpargne, simonCheque, guichet, service, "simonbug", "1237");
            Usager katia = new Usager(katiaEpargne, katiaCheque, guichet, service, "katiadus", "1238");
            // Ajouter les 5 usagers dans la liste
            guichet.AjouterUsager(paul);
            guichet.AjouterUsager(jonam);
            guichet.AjouterUsager(firdaous);
            guichet.AjouterUsager(simon);
            guichet.AjouterUsager(katia);
            string choice;
            do
            {
                guichet.MenuPrincipal();
                choice =  Console.ReadLine();

            }while(choice != "3");



            /*paulEpargne.AfficherCompte();
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

            Guichet guichet = new Guichet(); // 10000$
            Console.WriteLine("Solde initial guichet:  "+ guichet.getSoldeGuichet()); //10000$
            Console.WriteLine("Etat initial:  "+ guichet.Mode);
            Console.WriteLine("==============================================================");

          
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
            Facture facture1 = new Facture("Telephone", 200,DateTime.Now);
            Facture facture2 = new Facture("Internet", 300,DateTime.Now);
            Facture facture3 = new Facture("Television", 400,DateTime.Now);
            Console.WriteLine(facture1.ToString());
            Console.WriteLine(facture2.ToString());
            Console.WriteLine(facture3.ToString());
            facture1.AfficherInformationFacture();
            // Class Fournisseur de Services
             */
            /*;
           
            guichet.MenuPrincipal();
            string choice = Console.ReadLine();
            guichet.SelectionCompte(choice); */

            guichet.AfficherEtatGuichet();
            Console.WriteLine("----------------------------------------------------");
            CompteEpargne paulEpargne1 = new("Paul Faye", 2000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);
            //paulEpargne.AfficherCompte(); 
            
            //service1.AfficherService();
           
            //paulCheque.AfficherCompte();
           /* 
            Facture facture1 = new("Telephone", 200, DateTime.Now);
            Facture facture2 = new("Internet", 300, DateTime.Now);
            Facture facture3 = new("Television", 2000, DateTime.Now);
            Console.WriteLine("==============================================================");
            service.AjouterFacture(facture1);
            service.AjouterFacture(facture2);
            service.AjouterFacture(facture3);
            foreach (Facture facture in service.ListeFacture)
            {
                Console.WriteLine(facture);
            }

            Usager usager = new(paulEpargne, paulCheque, guichet, service, "1234", "paul1988");
            */
            //usager.AfficherIdentifiantsUsager();
            //guichet.MenuPrincipal();
            //string choice = Console.ReadLine();
            //guichet.SelectionCompte(choice,admin,usager);
            //admin.ConnectionModeAdministrateur();
            //usager.ConnectionModeUtilisateur();
            //Console.WriteLine("solde du guichet = "+guichet.Solde);
            //admin.DeposerMontantGuichet2();
            //Console.WriteLine("------------------------------------------------------");
            //guichet.AfficherEtatGuichet();
            //Console.WriteLine("Nouveau solde du guichet = " + guichet.Solde);
            // usager.DeposerMontant();
            //usager.AfficherSoldeCompte();
            //Console.WriteLine("nom utilisateur = "+ usager.NomUtilisaeur);
            //Console.WriteLine("password actuel = " + usager.Password);
            //usager.ChangerMotdePasse();
            //Console.WriteLine();
            //usager.AfficherIdentifiantsUsager();
            //Console.WriteLine(" nouveau password  = " + usager.Password);
            //Console.WriteLine("------------------------------------------------------");
            //paulCheque.AfficherSoldeCheque();
            //paulEpargne.AfficherSoldeEpargne();
            //Console.WriteLine("------------------------------------------------------");
            //usager.FaireVirement(4000);
            //Console.WriteLine("------------------------------------------------------");
            //Console.WriteLine("------------------------------------------------------");
            ////usager.PayerFacture();
            //paulCheque.AfficherSoldeCheque();
            //paulEpargne.AfficherSoldeEpargne();

        }
    }
}
