using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public LijnenVoorraad LijnenVoorraad { get; set; }
        public Kabel Kabel { get; set; }
        public Waterskibaan()
        {
            LijnenVoorraad = new LijnenVoorraad();
            Kabel = new Kabel();
            for (int i = 0; i < 15; i++)
            {
                LijnenVoorraad.LijnToevoegenAanRij(new Lijn());
            }
        }
        public void VerplaatsKabel()
        {
            Lijn tempLijn = Kabel.VerwijderLijnVanKabel();
            if (tempLijn != null)
            {
                LijnenVoorraad.LijnToevoegenAanRij(tempLijn);
            }
            Kabel.VerschuifLijnen();
        }

        public void SporterStart(Sporter sp)
        {
            if (sp.Zwemvest != null && sp.Skies != null)
            {
                // init
                Lijn newLine = LijnenVoorraad.VerwijderEersteLijn();
                var R = new Random();
                int Rounds = R.Next(1, 3);

                //Give random amount of laps
                Color randomColor = Color.FromArgb(R.Next(256), R.Next(256), R.Next(256));
                sp.AantalRondenNogTeGaan = Rounds;
                sp.KledingKleur = randomColor;
                if (newLine == null)
                    return;
                newLine.Sporter = sp;

                // Add line to cable
                Kabel.NeemLijnInGebruik(newLine);
            }
            else
            {
                throw new ArgumentNullException("Geen zwemvest en skies");
            }
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        //@Override
        public override string ToString()
        {
            return $"Lijnvoorraad {LijnenVoorraad}, Kabel {Kabel}.";
        }
    }
}
