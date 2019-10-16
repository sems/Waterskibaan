using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Logger
    {
        public List<Sporter> Bezoekers { get; set; }
        public Kabel Kabel { get; set; }

        readonly Func<Color, int> CheckLightColor = (Color a) => (a.R * a.R) + (a.G * a.G) + (a.B * a.B);

        public Logger(Kabel kabel)
        {
            Bezoekers = new List<Sporter>();
            Kabel = kabel;
        }

        public void NieuwBezoeker(NieuweBezoekerArgs args)
        {
            if (args.Sporter != null)
                Bezoekers.Add(args.Sporter);
        }

        public int GetTotaalBezoekers()
        {
            return (from x in Bezoekers select x).Count();
        }

        public int GetHoogsteScore()
        {
            if (Bezoekers.Count != 0)
            {
                IEnumerable<Sporter> query = Bezoekers.OrderByDescending(sporter => sporter.Score);
                int total = 0;
                foreach (var item in query)
                {
                    total += item.Score;
                }
                //Console.WriteLine($"total {total}");
                return query.First().Score;
            }
            return 0;
        }

        private bool ColorsAreClose(Color a, Color z, int threshold = 100)
        {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= threshold * threshold;
        }

        public int GetAantalBezoekersMetRood()
        {
            int AantalRood = 0;
            foreach (Sporter sporter in Bezoekers)
            {
                if (ColorsAreClose(sporter.KledingKleur, Color.FromArgb(255,50,50)))
                    AantalRood++;
            }
            return AantalRood;
        }

        public SortedList<int, Color> SorteerOpLichsteKleur()
        {
            SortedList<int, Color> SportersOpKleur = new SortedList<int, Color>();
            foreach (Sporter sporter in Bezoekers)
            {
                int colorHue = CheckLightColor(sporter.KledingKleur);
                SportersOpKleur.Add(colorHue, sporter.KledingKleur);
            }
            return SportersOpKleur;
        }

        public int GetTotaalAantalRondjes()
        {
            int total = 0;
            foreach (Sporter sporter in Bezoekers)
            {
                total += sporter.AantalRondenAlGedaan;
            }
            return total;
        }

        public string AlleHuidigeMoves()
        {
            string namenMoves = "";
            foreach (Lijn lijn in Kabel.GetLijnen())
            {
                Sporter sporter = lijn.Sporter;
                if (sporter.HuidigeMove != null)
                {
                    namenMoves += ($"- {sporter.HuidigeMove.ToString()}\n");
                }
            }
            return namenMoves;
        }

    }
}
