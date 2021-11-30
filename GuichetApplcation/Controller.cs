using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Guichet
{
    public class Controller
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            /*
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
            FournisseurService service1 = new FournisseurService("Bell");
            FournisseurService service2 = new FournisseurService("Amazon");
            FournisseurService service3 = new FournisseurService("Videotron");
            Console.WriteLine("==============================================================");
            service1.AjouterFacture(facture1);
            service1.AjouterFacture(facture2);
            service1.AjouterFacture(facture3);
            service1.AfficherService(); */
            /*;
           
            guichet.MenuPrincipal();
            string choice = Console.ReadLine();
            guichet.SelectionCompte(choice); */
            Guichet guichet = new (5000, EtatDuSysteme.ACTIF) ;
            CompteEpargne paulEpargne = new ("Paul Faye", 2000, EtatDuCompte.ACTIF, TypeDuCompte.Epargne);
            //paulEpargne.AfficherCompte();
            FournisseurService service1 = new ("Bell");
            //service1.AfficherService();
            CompteCheque paulCheque = new ("Paul Faye", 8000, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            //paulCheque.AfficherCompte();
            Usager usager =  new (paulEpargne,paulCheque,guichet,service1,"1234","paul1988");
            Administrateur admin = new (guichet,"admin","123456");
            //usager.AfficherIdentifiantsUsager();
            guichet.MenuPrincipal();
            guichet.AfficherEtatGuichet();
            //string choice = Console.ReadLine();
            //guichet.SelectionCompte(choice,admin,usager);
            //admin.ConnectionModeAdministrateur();
            //usager.ConnectionModeUtilisateur();
            //Console.WriteLine("solde du guichet = "+guichet.Solde);
            admin.DeposerMontantGuichet();
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
            //paulCheque.AfficherSoldeCheque();
            //paulEpargne.AfficherSoldeEpargne();
            //usager.FaireVirement(1000);
            Point p =  new () { X =  50, Y = 70};
            List<Point> points = new () {
                new Point{X= 10,Y= 20},
                new Point{X = 20, Y = 10},
                new Point{X = 20, Y =  30},
                new Point{X = 40, Y = 50},
                new Point{X = 50, Y = 70},
            }; 
            // creation d'un predicate
             bool pointFind = points.Exists(p =>(p.X,p.Y) == (50,70));
            //Console.WriteLine("pointFind = "+ pointFind);
            
           




        }
        

        

    }
    public class Point
    {
        public delegate bool Predicate<in Point>(Point obj);
        public int X { get; set; }
        public int Y { get; set; }
        public Point()
        {
            X = 0;
            Y = 0;
        }
        public bool FindPoints(int x, int y)
        {
            return  X.Equals(y) && Y.Equals(x);
            

        }
    }
}
