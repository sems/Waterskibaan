using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public Kabel()
        {
            _lijnen = new LinkedList<Lijn>();
        }

        public bool IsStartPositieLeeg()
        {
            if (_lijnen.Count() != 0)
            {
                if (_lijnen.First().PostitieOpdeKabel != 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PostitieOpdeKabel = 0;
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn item in _lijnen.ToList())
            {
                item.PostitieOpdeKabel += 1;
                if (item.PostitieOpdeKabel > 9)
                {
                    _lijnen.RemoveLast();
                    item.PostitieOpdeKabel = 0;
                    // opgave 7
                    item.Sporter.AantalRondenNogTeGaan--;
                    _lijnen.AddFirst(item);
                }
            }
        }
        public Lijn VerwijderLijnVanKabel()
        {
            var node = _lijnen.First;
            while (node != null)
            {
                var nextNode = node.Next;
                
                if (node.Value.PostitieOpdeKabel == 9)
                {
                    // opgave 7
                    if (node.Value.Sporter.AantalRondenNogTeGaan == 1)
                    {
                        _lijnen.Remove(node);
                        return node.Value;
                    }
                }
                node = nextNode;
            }
            return null;
        }
        public bool isEmpty()
        {
            return _lijnen == null;
        }
        public override string ToString()
        {
            if (isEmpty())
            {
                return "";
            }
            string result = "";

            foreach (var item in _lijnen)
            {
                result += item.PostitieOpdeKabel.ToString() + "|";
            }
            return result;
        }
    }
}
