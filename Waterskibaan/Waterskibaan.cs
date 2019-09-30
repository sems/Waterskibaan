using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Waterskibaan
    {
        public LijnenVoorraad LijnenVoorraad { get; set; }
        public Kabel Kabel { get; set; }
        public Waterskibaan()
        {
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
            // init
            Lijn newLine = LijnenVoorraad.VerwijderEersteLijn();
            var R = new Random();
            int Rounds = R.Next(1, 3);

            //Give random amount of laps
            Color randomColor = Color.FromArgb(R.Next(256), R.Next(256), R.Next(256));
            sp.AantalRondenNogTeGaan = Rounds;
            sp.KledingKleur = randomColor;
            newLine.Sporter = sp;

            // Add line to cable
            Kabel.NeemLijnInGebruik(newLine);
        }

        //@Override
        public override string ToString()
        {
            return $"Lijnvoorraad {LijnenVoorraad}, Kabel {Kabel}.";
        }
    }
}
