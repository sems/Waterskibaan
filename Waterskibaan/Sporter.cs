using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public int Score { get; set; }
        public List<IMoves> Moves { get; set; }

        public Sporter(List<IMoves> moves)
        {
            AantalRondenNogTeGaan = 0;
            Moves = moves;
        }
    }
}
