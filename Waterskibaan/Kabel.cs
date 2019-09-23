using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    class Kabel
    {
        private LinkedList<Lijn> _lijnen;

        public Kabel()
        {
            _lijnen = new LinkedList<Lijn>();
        }

        public bool IsStartPositieLeeg()
        {
            var node = _lijnen.First;
            if (node == null)
            {
                return true;
            }
            while (node != null)
            {
                var nextNode = node.Next;
                if (node.Value.PostitieOpdeKabel == 0)
                {
                    return false;
                }
                node = nextNode;
            }
            return true;

            // Old code
            //if (_lijnen.First.Value.PostitieOpdeKabel != 0 || _lijnen.First == null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                _lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen()
        {
            foreach (Lijn item in _lijnen)
            {
                item.PostitieOpdeKabel += 1;
                if (item.PostitieOpdeKabel > 9)
                {
                    item.PostitieOpdeKabel = 0;
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
                    return node.Value;
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
            else
            {
                var node = _lijnen.First;
                while (node != null)
                {
                    return $"{ node.Value.PostitieOpdeKabel}|";
                }
            }
            return "";
        }
    }
}
