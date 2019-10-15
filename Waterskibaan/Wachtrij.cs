using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        public abstract int MAX_LENGTE_RIJ { get; }
        public Queue<Sporter> Rij { get; set; }
        public Wachtrij()
        {
            Rij = new Queue<Sporter>();
        }
        public List<Sporter> GetAlleSporters()
        {
            return Rij.ToList();
        }

        public void SporterNeemPlaatsInRij(Sporter sporter) {
            if (Rij.Count < MAX_LENGTE_RIJ)
            {
                Rij.Enqueue(sporter);
            }
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> LeftSporters = new List<Sporter>();

            for (int i = 0; i < aantal && Rij.Count > 0; i++) LeftSporters.Add(Rij.Dequeue());
            
            return LeftSporters;
        }

        public Sporter SporterVerlaatRij()
        {
            if (Rij.Count > 0)
            {
                return Rij.Dequeue();
            }
            return null;
        }

        public int GetFreeSpace()
        {
            return MAX_LENGTE_RIJ - Rij.Count;
        }

        public override string ToString()
        {
            return $"{Rij.Count} sporters in deze rij, {MAX_LENGTE_RIJ - Rij.Count} plaatsen.";
        }
    }
}
