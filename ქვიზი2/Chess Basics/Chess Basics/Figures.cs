using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Basics
{
    public  class Figures
    {
        public Tuple<char, int> CurrentPosition { get; set; }
        public Tuple<char, int> NextPosition()
        {
            Tuple<char, int> position = new Tuple<char, int>('a', 1);
            return position;
        }
    }
    internal class Paiki : Figures
    {
        public Paiki(Tuple<char, int> currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        public Paiki((char, int) value)
        {
            Value = value;
        }

        public (char, int) Value { get; }
        public Tuple<char, int> CurrentPosition { get; set; }

        public Tuple<char, int> NextPosition(Tuple<char, int> nextmove, List<Tuple<char,int>> positionofFigures)
        {
            char nextMoveChar = nextmove.Item1;
            int nextMoveInt = nextmove.Item2;

            if (nextmove.Item1 > 'h' || nextmove.Item1 < 'a' || nextmove.Item2 > 8 || nextmove.Item2 < 1)
            {
                return CurrentPosition;
            }
            if (nextMoveChar < CurrentPosition.Item1 || nextMoveChar > CurrentPosition.Item1 || nextMoveInt < CurrentPosition.Item2 || nextMoveInt - 1 > CurrentPosition.Item2)
            {
                Console.WriteLine("paiki gadaadgildeba mxolod win, mxolod erti ujrit");
                return CurrentPosition;
            }
            if (positionofFigures.Contains(nextmove))
            {
                positionofFigures.Remove(CurrentPosition);
                CurrentPosition = nextmove;
                return nextmove;

            }
            else
            {
                CurrentPosition = nextmove;
                Console.WriteLine($"Paiki dgas {nextmove.Item1}:{nextmove.Item2}");
                return CurrentPosition;
            }

        }
    }
    internal class cxeni : Figures
    {
        public cxeni(Tuple<char, int> currentPosition)
        {
            CurrentPosition = currentPosition;
        }

        public cxeni((char, int) value)
        {
            Value = value;
        }

        public (char, int) Value { get; }
        public Tuple<char, int> CurrentPosition { get; set; }

        public Tuple<char, int> NextPosition(Tuple<char, int> nextmove)
        {
            char nextMoveChar = nextmove.Item1;
            int nextMoveInt = nextmove.Item2;

            if (nextMoveChar > 'h' || nextMoveChar < 'a' || nextMoveInt > 8 || nextMoveInt < 1)
            {
                Console.WriteLine("dafas ar udna gasce");
                return CurrentPosition;
            }
            else
            {
                CurrentPosition = nextmove;
                Console.WriteLine($"cxeni dgas {nextmove.Item1}:{nextmove.Item2}");
                return CurrentPosition;
            }

        }
    }
        internal class Etli : Figures
        {
            public Etli(Tuple<char, int> currentPosition)
            {
                CurrentPosition = currentPosition;
            }

            public Etli((char, int) value)
            {
                Value = value;
            }

            public (char, int) Value { get; }
            public Tuple<char, int> CurrentPosition { get; set; }
            public void MoveMethod()
            {

            }
        public Tuple<char, int> NextPosition(Tuple<char, int> nextmove)
        {

            if (nextmove.Item1 > 'h' || nextmove.Item1 < 'a' || nextmove.Item2 > 8 || nextmove.Item2 < 1)
            {
                throw new Exception("dafas ar udna gasce");
            }
            else
            {
                CurrentPosition = nextmove;
                Console.WriteLine($"cxeni dgas {nextmove.Item1}:{nextmove.Item2}");
                return CurrentPosition;
            }

        }
    }
}
