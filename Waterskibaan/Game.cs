using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Waterskibaan
{
    public class Game
    {
        public Waterskibaan Waterskibaan { get; set; }
        public WachtrijInstructie WachtrijInstructie { get; set; }
        public InstructieGroep InstructieGroep { get; set; }
        public WachtrijStarten WachtrijStarten { get; set; }

        private Timer GameTimer;

        public void Initialize()
        {
            Waterskibaan = new Waterskibaan();
            WachtrijInstructie = new WachtrijInstructie();
            InstructieGroep = new InstructieGroep();
            WachtrijStarten = new WachtrijStarten();

            GameTimer = new Timer(1000);
            GameTimer.Elapsed += GameLoop;
            GameTimer.AutoReset = true;
            GameTimer.Enabled = true;
        }

        private void GameLoop(object sender, ElapsedEventArgs e)
        {
            Sporter s = new Sporter(Movecollection.GetWillekeurigeMoves())
            {
                Skies = new Skies(),
                Zwemvest = new Zwemvest()
            };

            Waterskibaan.SporterStart(s);
            Waterskibaan.VerplaatsKabel();
            Console.WriteLine($"{Waterskibaan}\n");
        }
    }
}
