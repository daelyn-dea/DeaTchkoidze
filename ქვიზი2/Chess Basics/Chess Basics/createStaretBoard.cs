using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Basics
{
    public   class createStaretBoard
    {
        public static List<Tuple<char, int>> CreateBoard()
        {
            List < Tuple < List<Paiki>, char, int>> LoccationsList = new List<Tuple<char, int>>();
            List<Paiki> paikebilisti = new List<Paiki>();   
            Paiki paiki0 = new Paiki(('a', 2));
            paikebilisti.Add(paiki0);
            Paiki paiki1 = new Paiki(('b', 2));
            Paiki paiki2 = new Paiki(('c', 2));
            Paiki paiki3 = new Paiki(('d', 2));
            Paiki paiki4 = new Paiki(('e', 2));
            Paiki paiki5 = new Paiki(('f', 2));
            Paiki paiki6= new Paiki(('g', 2));
            Paiki paiki7 = new Paiki(('h', 2));
            LoccationsList.Add(paikebilisti, paiki0.CurrentPosition);
            LoccationsList.Add(paiki1.CurrentPosition);
            LoccationsList.Add(paiki2.CurrentPosition);
            LoccationsList.Add(paiki3.CurrentPosition);
            LoccationsList.Add(paiki4.CurrentPosition);
            LoccationsList.Add(paiki5.CurrentPosition);
            LoccationsList.Add(paiki6.CurrentPosition);
            LoccationsList.Add(paiki7.CurrentPosition);
            return LoccationsList;
        }
    }
}
