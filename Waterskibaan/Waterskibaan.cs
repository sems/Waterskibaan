using System;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return $"Lijnvoorraad {LijnenVoorraad}, Kabel {Kabel}.";
        }
    }
}
