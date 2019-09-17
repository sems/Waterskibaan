using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public Boolean IsStartPositieLeeg()
        {
            return true;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {

        }

        public void VerschuifLijnen()
        {
            
        }
        public Lijn VerwijderLijnVanKabel()
        {
            return new Lijn();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
