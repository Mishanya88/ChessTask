using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject1
{
    public class King : Piece
    {
        public King(int x, int y) : base(x, y){}
        public override  char PrintSymbol()
        {
            return 'K';
        }
        public override bool IsAttacking(Piece otherPiece)
        {
            return Math.Abs(X - otherPiece.X) <= 1 && Math.Abs(Y - otherPiece.Y) <= 1;
        }

    }
    public class Queen : Piece
    {
        public Queen(int x, int y) : base(x, y)
        {
        }
        public override char PrintSymbol()
        {
            return 'Q';
        }
        public override bool IsAttacking(Piece otherPiece)
        {
            return X == otherPiece.X || Y == otherPiece.Y || Math.Abs(X - otherPiece.X) == Math.Abs(Y - otherPiece.Y);
        }
    }
    public class Rook : Piece
    {
        public Rook(int x, int y) : base(x, y)
        {
        }
        public override char PrintSymbol()
        {
            return 'R';
        }
        public override bool IsAttacking(Piece otherPiece)
        {
            return X == otherPiece.X || Y == otherPiece.Y;
        }
    }
    public class Bishop : Piece
    {
        public Bishop(int x, int y) : base(x, y)
        {
        }
        public override char PrintSymbol()
        {
            return 'B';
        }
        public override bool IsAttacking(Piece otherPiece)
        {
            return Math.Abs(X - otherPiece.X) == Math.Abs(Y - otherPiece.Y);
        }

    }
    public class Knight : Piece
    {
        public Knight(int x, int y) : base(x, y)
        {
        }
        public override char PrintSymbol()
        {
            return 'H';
        }
        public override bool IsAttacking(Piece otherPiece)
        {
            return Math.Abs(X - otherPiece.X) == 2 && Math.Abs(Y - otherPiece.Y) == 1 || Math.Abs(X - otherPiece.X) == 1 && Math.Abs(Y - otherPiece.Y) == 2;
        }
    }
}
