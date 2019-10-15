using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieAfgelopenArgs : EventArgs
    {
        public InstructieGroep InstructieGroep { get; set; }
        public WachtrijStarten WachtrijStarten { get; set; }

        public InstructieAfgelopenArgs(InstructieGroep instructieGroep, WachtrijStarten wachtrijStarten)
        {
            InstructieGroep = instructieGroep;
            WachtrijStarten = wachtrijStarten;
        }
    }
}