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
        }

        private static void TestOpdracht2()
        {
            Kabel cable = new Kabel();

            Lijn l1 = new Lijn();
            l1.PostitieOpdeKabel = 0;
            Lijn l2 = new Lijn();
            l1.PostitieOpdeKabel = 5;
            Lijn l3 = new Lijn();
            l1.PostitieOpdeKabel = 6;

            cable.NeemLijnInGebruik(l1);
            cable.NeemLijnInGebruik(l2);
            cable.NeemLijnInGebruik(l3);

            cable.VerschuifLijnen();

            Console.WriteLine(cable);
        }
    }
}
