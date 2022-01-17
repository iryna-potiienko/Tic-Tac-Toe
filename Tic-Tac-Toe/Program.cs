using System;
using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            SignType sign = SignType.X;
            board.PrintBoard();

            while (!board.IsDrawAll())
            {
                // Console.WriteLine($"\nWhich row do you want to put {sign} ?");
                // var row = Convert.ToInt32(Console.ReadLine());
                // Console.WriteLine($"\nWhich column do you want to put {sign} ?");
                // var column = Convert.ToInt32(Console.ReadLine());
                // if (!board.Move(row, column, sign)) continue;
                
                Console.WriteLine($"\nWhere you want to put {sign} ? (write row,column)");
                var position = Console.ReadLine();
                if (position==null||!Regex.IsMatch(position.Trim(),"^[0-2],[0-2]$")) continue;
                
                var coords = position.Split(',');
                if (!board.Move(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]), sign)) continue;
                board.PrintBoard();
                
                if (board.IsWin(sign))
                {
                    Console.WriteLine($"\n{sign} is winner!!!");
                    break;
                }

                sign = board.ChangeCurrentSignType(sign);
            } 
            
            Console.WriteLine("\nGame is finished");
        }
    }
}