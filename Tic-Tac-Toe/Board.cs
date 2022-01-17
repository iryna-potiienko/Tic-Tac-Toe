using System;
using System.Linq;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public SignType[,] Squares;
        public SignType CurrentSignType;

        public Board()
        {
            Squares = new SignType[3,3];
        }
        
        public void PrintBoard()
        {
            // for (int i = 0; i < Squares.Length; i += 2)
            // {
            //     Console.WriteLine($" {Squares[i]} | {Squares[i+1]} | {Squares[i+2]} ");
            //     Console.WriteLine("---+---+---");
            // }
            
            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var cross = Squares[i,j];
                    Console.Write(cross != SignType.Empty ? $" {cross} |" : "   |");
                }

                if (i != 2) Console.WriteLine("\n---+---+---");
            }

            // Console.WriteLine("   | X |   " +
            //                   "---+---+---" +
            //                   "   | O | X " +
            //                   "---+---+---" +
            //                   " O |   |   ");
        }
        
        public bool Move(int squareRow,int squareCol, SignType sign)
        {
            if (squareCol is < 0 or > 2) return false;
            if (squareRow is < 0 or > 2) return false;
            if (Squares[squareRow, squareCol] != SignType.Empty) return false;
            
            Squares[squareRow, squareCol] = sign;
            return true;
        }

        public bool IsDrawAll()
        {
            var isDrawAll = Squares.Cast<SignType>().All(square => square != SignType.Empty);
            if(isDrawAll) Console.WriteLine("\nBoard is full");
            return isDrawAll;
        }

        public bool IsWin(SignType sign)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Squares[i, 0] == sign && Squares[i, 0] == Squares[i, 1] && Squares[i, 1] == Squares[i, 2]
                ) return true;
            }
            
            for (int j = 0; j < 3; j++)
            {
                if (Squares[0,j] == sign && Squares[0, j] == Squares[1, j] && Squares[1, j] == Squares[2, j]) 
                    return true;
            }
            
            if (Squares[0, 0]==sign && Squares[0, 0] == Squares[1, 1] && Squares[1, 1] == Squares[2, 2]) return true;
            if (Squares[0, 2]==sign && Squares[0, 2] == Squares[1, 1] && Squares[1, 1] == Squares[2, 0]) return true;

            return false;
        }

        public SignType ChangeCurrentSignType(SignType sign)
        {
            switch (sign)
            {
                case SignType.X:
                    return SignType.O;
                case SignType.O:
                    return SignType.X;
                default:
                    return SignType.Empty;
            }
        }
    }
}