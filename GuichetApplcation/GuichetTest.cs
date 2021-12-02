using System;
using Xunit;

namespace Guichet
{
    public class GuichetTest
    {
        CompteCheque cheque;
        CompteEpargne epargne;
        [Fact]
        public void DeposerTest()
        {
            var cheque = new CompteCheque("Paul", 1200, EtatDuCompte.ACTIF, TypeDuCompte.Cheque);
            cheque.Deposer(500, DateTime.Now, "Depot");
            Assert.Equal(1700, cheque.Balance);
        }

    }
}
