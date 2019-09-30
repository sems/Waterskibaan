using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class TurnMove : IMoves
    {
        public int Move()
        {
            var R = new Random();
            int succeed = R.Next(1, 3);

            // If succeed
            if (succeed == 1)
                return 20;
            //failed
            return 0;
        }
    }
}
