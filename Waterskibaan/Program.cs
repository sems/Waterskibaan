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
            TestOpdracht12();
            Console.ReadLine();
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

        private static void TestOpdracht8()
        {
            //Waterskibaan w = new Waterskibaan();
            Sporter s = new Sporter(Movecollection.GetWillekeurigeMoves());

            //s.Zwemvest = new Zwemvest();
            //s.Skies = new Skies();

            //w.SporterStart(s);
        }

        private static void TestOpdracht10()
        {
            Sporter s = new Sporter(Movecollection.GetWillekeurigeMoves());
            s.Zwemvest = new Zwemvest();
            s.Skies = new Skies();

            Sporter s1 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s1.Zwemvest = new Zwemvest();
            s1.Skies = new Skies();

            InstructieGroep ig = new InstructieGroep();
            ig.SporterNeemPlaatsInRij(s);
            ig.SporterNeemPlaatsInRij(s1);

            Console.WriteLine(ig);

            ig.SportersVerlatenRij(1);

            Console.WriteLine(ig);

            Sporter s2 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s2.Zwemvest = new Zwemvest();
            s2.Skies = new Skies();

            Sporter s3 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s3.Zwemvest = new Zwemvest();
            s3.Skies = new Skies();

            Sporter s4 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s4.Zwemvest = new Zwemvest();
            s4.Skies = new Skies();

            Sporter s5 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s5.Zwemvest = new Zwemvest();
            s1.Skies = new Skies();

            Sporter s6 = new Sporter(Movecollection.GetWillekeurigeMoves());
            s6.Zwemvest = new Zwemvest();
            s6.Skies = new Skies();

            ig.SporterNeemPlaatsInRij(s);
            ig.SporterNeemPlaatsInRij(s2);
            ig.SporterNeemPlaatsInRij(s3);
            ig.SporterNeemPlaatsInRij(s4);
            
            // Deze passen niet
            ig.SporterNeemPlaatsInRij(s5);
            ig.SporterNeemPlaatsInRij(s6);

            var sporters = ig.GetAlleSporters();
            foreach (var sporter in sporters)
            {
                Console.WriteLine(sporter);
            }
        }

        private static void TestOpdracht11()
        {
            Game g = new Game();
            g.Initialize();
        }

        private static void TestOpdracht12()
        {
            Game g = new Game();
            g.Initialize();
        }
    }
}
