using System;

namespace Survivor
{
    public class Game
    {
        public Random Random;
        protected int SpawnRate;
        protected int DaysLeft;
        protected Cell[,] Board;
        protected Player Player;
        public Game(Random random, int spawnRate, int daysLeft, int boardWidth, int boardHeight)
        {   
            throw new NotImplementedException();
        }
        
        public Game()
        {
            throw new NotImplementedException("Delete This Constructor When Game Hard Is Implemented");
        }
        
        public Cell[,] GetBoard()
        {
            throw new NotImplementedException();
        }

        protected virtual void SpawnItem(int x, int y)
        {
            throw new NotImplementedException();
        }

        protected void Spawn()
        {
            throw new NotImplementedException();
        }

        protected virtual void PrintBoard()
        {
            ConsoleColor bg = Console.BackgroundColor;
            ConsoleColor fg = Console.ForegroundColor;
            for (int y = 0; y < Board.GetLength(1); y++)
            {
                Console.Write("|");
                for (int x = 0; x < Board.GetLength(0); x++)
                {
                    switch (Board[x, y])
                    {
                        case Forest:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;
                        case River:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case Sea:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            break;
                        default:
                            Console.BackgroundColor = bg;
                            break;
                    }

                    if (Player.GetCoordinates().x == x && Player.GetCoordinates().y == y)
                        Console.Write("X");
                    else
                        Console.Write(Board[x, y]);
                }
                Console.BackgroundColor = bg;
                Console.ForegroundColor = fg;
                Console.WriteLine("|");
            }
        }
        
        protected void PrintStats()
        {
            throw new NotImplementedException();
        }
        
        protected virtual void PrintAll()
        {
            throw new NotImplementedException();
        }

        protected void PrintEnd(bool win)
        {
            throw new NotImplementedException();
        }
        protected virtual void UpdateBoard()
        {
            throw new NotImplementedException();
        }
        
        protected virtual bool NextDay()
        {
            throw new NotImplementedException();
        }
        
        protected virtual bool GetAction()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        

        protected virtual Cell[,] CreateBoard(int width, int height)
        {
            Cell[,] board = new Cell[width, height];
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (x == 0 || x == board.GetLength(0) - 1 || y == 0 || y == board.GetLength(1) - 1)
                        board[x, y] = new Sea(1, 2);
                    else if (x == 2 * y)
                        board[x, y] = new River(2, 2); 
                    else
                        board[x, y] = new Forest(1, 2);
                }
            }

            return board;
        }
    }
}
