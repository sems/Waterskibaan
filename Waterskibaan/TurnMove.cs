using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class TurnMove : IMoves
    {
        public int Move()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int random = rand.Next(0, 2);

            if (random == 0)
                return 20;
            else
                return 0;
        }

        public override string ToString()
        {
            return "Turn";
        }
    }
}
