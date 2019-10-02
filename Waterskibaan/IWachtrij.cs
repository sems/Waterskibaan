using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public interface IWachtrij
    {
        void SporterNeemPlaatsInRij(Sporter sporter);
        List<Sporter> GetAlleSporters();
        List<Sporter> SportersVerlatenRij(int aantal);
    }
}
