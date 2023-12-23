using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Basics
{
    internal class ChessInfo
    {
        Tuple<string, int> Paiki = new Tuple<string, int>("paiki", 8);
        Tuple<string, int> Cxeni = new Tuple<string, int>("cxeni", 2);
        Tuple<string, int> Etli = new Tuple<string, int>("paiki", 2);
        Tuple<string, int> Mefe = new Tuple<string, int>("paiki", 1);

        public override string ToString()
        {
            return $"{Paiki.Item1}:{Paiki.Item2}, {Cxeni.Item1}:{Cxeni.Item2},{Etli.Item1}:{Etli.Item2},{Mefe.Item1}:{Mefe.Item2}";
        }
        public bool IsPoisiotnFree(Tuple<char, int> pos)
        {

            return true;
        }
    }
}
