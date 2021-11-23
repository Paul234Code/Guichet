using System;
using System.Collections.Generic;
using System.Threading;

namespace Guichet
{
    public class Controller
    {
        static void Main(string[] args)
        {
            Guichet guichet = new Guichet();
            List<CompteClient> ListeClients = new List<CompteClient>();
            bool mode = true;
            while (mode)
            {
                Thread.Sleep(200);
            }
        }
    }
}
