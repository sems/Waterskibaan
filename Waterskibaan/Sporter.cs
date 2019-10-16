using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public int Score { get; set; }
        public List<IMoves> Moves { get; set; }
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves)
        {
            AantalRondenNogTeGaan = 0;
            Moves = moves;
        }

        public void DoeMove()
        {
            Random r = new Random(DateTime.Now.Second);
            HuidigeMove = Moves[r.Next(0, Moves.Count)];
            Score += HuidigeMove.Move();
        }
    }
}
