using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get; } = 100;

        public WachtrijInstructie(Game game) : base()
        {
            game.NieuweBezoeker += NieuweBezoekerHandler;
            game.InstructieAfgelopen += InstructieAfgelopenHandler;
        }

        public void NieuweBezoekerHandler(NieuweBezoekerArgs args)
        {
            SporterNeemPlaatsInRij(args.Sporter);
        }

        public void InstructieAfgelopenHandler(InstructieAfgelopenArgs args)
        {
            foreach (var item in args.InstructieGroep.SportersVerlatenRij(args.WachtrijStarten.GetFreeSpace()))
            {
                args.WachtrijStarten.SporterNeemPlaatsInRij(item);
            }

            foreach (var item in SportersVerlatenRij(args.InstructieGroep.GetFreeSpace()))
            {
                args.InstructieGroep.SporterNeemPlaatsInRij(item);
            }
        }
    }
}
