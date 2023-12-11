using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject1
{
    internal class Program
    {
        static void CereateObject(Board objB, string[] text)
        {
            int count = 0;
            int N = 10;
            foreach (var line in text)
            {
                if (count == N)
                    throw new ArgumentOutOfRangeException("Вы объяявили больше 10 фигур");
                string[] values = line.Split(' ');
                Tuple<string, int, int> pair = new Tuple<string, int, int>(values[0], Convert.ToInt32(values[1]), Convert.ToInt32(values[2]));
                Piece obj;
                switch (pair.Item1)
                {
                    case "king":
                        obj = new King(pair.Item2, pair.Item3);
                        break;
                    case "queen":
                        obj = new Queen(pair.Item2, pair.Item3);
                        break;
                    case "rook":
                        obj = new Rook(pair.Item2, pair.Item3);
                        break;
                    case "bishop":
                        obj = new Bishop(pair.Item2, pair.Item3);
                        break;
                    case "knight":
                        obj = new Knight(pair.Item2, pair.Item3);
                        break;
                    default:
                        throw new ArgumentException("Нет такой фигуры");
                }
                objB.AddBoard(obj);
                count++;
            }


        }
          static public void Mains()
        {
            Board obj2 = new Board();
            var dir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"SharedProject1\TextFile1.txt");
            try
            {
                string[] text = File.ReadAllLines(dir);
                CereateObject(obj2, text);
                obj2.DrawBoard();
                obj2.cuts();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {dir}");
            }
        }
    }
}
