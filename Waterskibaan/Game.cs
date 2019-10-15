using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
    public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
    public delegate void LijnenVerplaatstHandler();
    public class Game
    {
        public Waterskibaan Waterskibaan { get; set; }
        public WachtrijInstructie WachtrijInstructie { get; set; }
        public InstructieGroep InstructieGroep { get; set; }
        public WachtrijStarten WachtrijStarten { get; set; }

        private Timer GameTimer;
        private Timer WachtrijTimer;
        private Timer InstructieGroepTimer;
        private Timer LijnenVerplaatsenTimer;

        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public event LijnenVerplaatstHandler LijnenVerplaatst;

        public void Initialize()
        {
            Waterskibaan = new Waterskibaan(this);
            WachtrijInstructie = new WachtrijInstructie(this);
            InstructieGroep = new InstructieGroep();
            WachtrijStarten = new WachtrijStarten();

            GameTimer = new Timer(1000)
            {
                AutoReset = true,
                Enabled = true
            };
            GameTimer.Elapsed += GameLoop;

            InstructieGroepTimer = new Timer(20000)
            {
                AutoReset = true,
                Enabled = true
            };
            InstructieGroepTimer.Elapsed += InstructieGroepLoop;

            WachtrijTimer = new Timer(3000)
            {
                AutoReset = true,
                Enabled = true
            };
            WachtrijTimer.Elapsed += WachtrijLoop;

            LijnenVerplaatsenTimer = new Timer(4000)
            {
                AutoReset = true,
                Enabled = true
            };
            LijnenVerplaatsenTimer.Elapsed += LijnenVerplaatsenLoop;
        }

        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            if (Waterskibaan.Kabel.IsStartPositieLeeg())
            {
                Waterskibaan.SporterStart(WachtrijStarten.SporterVerlaatRij());
            }
            Sporter s = new Sporter(Movecollection.GetWillekeurigeMoves())
            {
                Skies = new Skies(),
                Zwemvest = new Zwemvest()
            };
            WachtrijStarten.SporterNeemPlaatsInRij(s);
            Console.WriteLine($"{Waterskibaan}\n");
            Console.WriteLine($"WachtrijInstructie: {WachtrijInstructie.Rij.Count}");
            Console.WriteLine($"InstructieGroep: {InstructieGroep.Rij.Count}");
            Console.WriteLine($"WachtrijStarten: {WachtrijStarten.Rij.Count}");
        }

        private void WachtrijLoop(object sender, ElapsedEventArgs e)
        {
            Sporter s = new Sporter(Movecollection.GetWillekeurigeMoves())
            {
                Skies = new Skies(),
                Zwemvest = new Zwemvest()
            };
            NieuweBezoeker?.Invoke(new NieuweBezoekerArgs(s));
        }

        private void LijnenVerplaatsenLoop(object sender, ElapsedEventArgs e)
        {
            LijnenVerplaatst?.Invoke();
        }

        private void InstructieGroepLoop(object sender, ElapsedEventArgs e)
        {
            InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs(InstructieGroep, WachtrijStarten));
        }
    }
}
