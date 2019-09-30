using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    static class Movecollection
    {
        static public List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            var R = new Random();

            for (int i = 0; i < 6; i++)
            {
                int RandomMove = R.Next(1, 5);
                switch (RandomMove)
                {
                    case 1:
                        moves.Add(new JumpMove());
                        break;
                    case 2:
                        moves.Add(new OneHandMove());
                        break;
                    case 3:
                        moves.Add(new OneLeggMove());
                        break;
                    case 4:
                        moves.Add(new TurnMove());
                        break;
                    default:
                        break;
                }
            }
            return moves;
        }
    }
}
