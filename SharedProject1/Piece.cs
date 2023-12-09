using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject1
{
    public abstract class Piece
    {
        public int X {get;set;}
        public int Y { get;set;}

        public Piece(int x, int y)
        {
            X = x;
            Y = y;
        }
        public abstract char PrintSymbol();
        public abstract bool IsAttacking(Piece otherPiece);

    }
    public class Board
    {
        private List<Piece> pieces = new List<Piece>();
        private char[,] arr;
        int N = 8;
        public Board()
        {
            arr = new char[N, N];
        }
        public void AddBoard(Piece piece)
        {
            if (!IsValidPosition(piece.X, piece.Y))
            {
                throw new ArgumentException($"Нет позиции {piece.X},{piece.Y} ");
            }

            if (arr[piece.X, piece.Y] != '-' && arr[piece.X, piece.Y] != '\0')
            {
                throw new InvalidOperationException($"Позиция {piece.X},{piece.Y} занята {piece.PrintSymbol()}");
            }

            pieces.Add(piece);
            arr[piece.X, piece.Y] = piece.PrintSymbol();
        }
        public void DrawBoard()
        {

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (arr[i, j] == '\0')
                        Console.Write("  *  ");
                    else
                        Console.Write($"  { arr[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        private bool IsValidPosition(int x , int y)
        {
            return x < 8 && y < 8 && y >= 0 && x >= 0;
        }
        public void cuts()
        {
           foreach(var figura1 in pieces)
           {
                foreach (var figura2 in pieces)
                {
                    if(figura1 != figura2 && figura1.IsAttacking(figura2))
                    {
                        Console.WriteLine($"{figura1.GetType().Name}({figura1.PrintSymbol()}) ({figura1.X},{figura1.Y}) рубит " +
                            $"{figura2.GetType().Name}({figura2.PrintSymbol()}) ({figura2.X},{figura2.Y})");   
                    }
                }

           }

        }


    }
    


}
