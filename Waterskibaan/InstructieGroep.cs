using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get; } = 5;
    }
}
