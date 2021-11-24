using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guichet
{
    public class Guichet
    {
       
        
        private EtatDuSysteme mode;
        private decimal Solde;



        // Menu principal
        public void MenuPincipal()
        {
            Console.WriteLine("1-Se connecter à votre compte"); //ajouter consolereadline + switch pour choix de menu
            Console.WriteLine("2- Se connecter comme administrateur");
            Console.WriteLine("3- Quitter");
        }

        // créer menu personnel

        public void MenuPersonnel()
        {
            //consolewriteline+consolereadline+switch choix de menu

        }
          // creer menu administrateur
        public void MenuAdmin()
        {
         //consolewriteline + consolereadline + switch choix de menu
        }
        // methode qui retourne le solde du guichet
        public decimal getSoldeGuichet()
        {
            return Solde;
        }
        // Affiche le solde du guichet
        public void AfficherSoldeGuichet()
        {

        }
        // Methode pour debiter un montant du Guichet
        public void Debiter(decimal montant)
        {

        }
    }
}
