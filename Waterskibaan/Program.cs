using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.TestOpdracht2();
            //Program.TestOpdracht3();
        }

        private static void TestOpdracht2()
        {
            Kabel cable = new Kabel();

            Lijn l1 = new Lijn();
            cable.NeemLijnInGebruik(l1);
            cable.VerschuifLijnen();

            Lijn l2 = new Lijn();
            cable.NeemLijnInGebruik(l2);
            cable.VerschuifLijnen();

            Lijn l3 = new Lijn();
            cable.NeemLijnInGebruik(l3);
            cable.VerschuifLijnen();

            Console.WriteLine(cable);
        }

        private static void TestOpdracht3()
        {
            LijnenVoorraad lv1 = new LijnenVoorraad();
            Lijn l1 = new Lijn();
            Lijn l2 = new Lijn();
            Lijn l3 = new Lijn();

            lv1.LijnToevoegenAanRij(l1);
            lv1.LijnToevoegenAanRij(l2);
            lv1.LijnToevoegenAanRij(l3);

            Console.WriteLine($"Aantal in rij: {lv1.GetAantalLijnen()}");

            lv1.VerwijderEersteLijn();

            Console.WriteLine($"Aantal in rij: {lv1.GetAantalLijnen()}");

            Console.WriteLine(lv1);
        }
    }
}
