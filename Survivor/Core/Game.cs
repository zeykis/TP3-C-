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
            Random = random;
            SpawnRate = spawnRate;
            DaysLeft = daysLeft;
            if (boardHeight < 5 || boardWidth<5)
            {
                throw new ArgumentException("Board size must be at least 5x5");
            } 
            else
            {
                Board = CreateBoard(boardWidth, boardHeight);
            }
            Player = new Player(30, boardWidth/2, boardHeight/2);
            
        }
        
        public Game()
        {
            throw new NotImplementedException("Delete This Constructor When Game Hard Is Implemented");
        }
        
        public Cell[,] GetBoard()
        {
            return Board;
        }

        protected virtual void SpawnItem(int x, int y)
        {
            
            int range = Random.Next(1, Board[x, y].GetSpawnRange());
            int x2 = Random.Next(0, range);
            int y2 = x2 - range;
            if (Random.Next(0, 2) == 0)
            {
                x2 = -x2;
            }
            if (Random.Next(0, 2) == 0)
            {
                y2 = -y2;
            }
            while (x + x2 < 0 || x + x2 >= Board.GetLength(0) || y + y2 < 0 || y + y2 >= Board.GetLength(1))
            {
                range = Random.Next(1, Board[x, y].GetSpawnRange());
                x2 = Random.Next(0, range);
                y2 = x2 - range;
                if (Random.Next(0, 2) == 0)
                {
                    x2 = -x2;
                }
                if (Random.Next(0, 2) == 0)
                {
                    y2 = -y2;
                }
            }
            if (Board[x+x2,y+y2].GetContent() == null)
            {
                if (Board[x+x2,y+y2] is Forest)
                {
                    Board[x+x2,y+y2].SetContent(new Banana(3,7));
                }
                else if (Board[x+x2,y+y2] is Sea)
                {
                    Board[x+x2,y+y2].SetContent(new Coconut(4,5));
                }
                else if (Board[x+x2,y+y2] is River)
                {
                    Board[x+x2,y+y2].SetContent(new Plum(2,9));
                }
            }
        }       
        
        protected void Spawn()
        {   
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Random.Next(0, SpawnRate) == 0)
                    {
                        SpawnItem(i, j);
                    }
                }
            }
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
            Console.WriteLine("Days left: " + DaysLeft);
            Console.WriteLine("Energy: " + Player.GetEnergy());
            Console.WriteLine("Thirst: " + Player.GetThirst());
        }
        
        protected virtual void PrintAll()
        {
            PrintBoard();
            PrintStats();
        }

        protected void PrintEnd(bool win)
        {
            if (win)
            {
                Console.WriteLine("You survived the journey!");
            }
            else
            {
                Console.WriteLine("You died.");
            }
        }
        protected virtual void UpdateBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j].Update();
                }
            }
        }
        
        protected virtual bool NextDay()
        {
            if (Player.SpendTheNight())
            {
                if (Player.GetEnergy() <= 0 || Player.GetThirst())
            {
                PrintEnd(false);
                return false;
            }
            else if (DaysLeft == 0)
            {
                PrintEnd(true);
                return false;
            }
            else
            {
                DaysLeft--;
                UpdateBoard();
                Spawn();
                return true;
            }
            }
            else
            {
                PrintEnd(false);
                return false;
            }


        }
        
        protected virtual bool GetAction()
        {
            char key = (char)Console.Read();
            if (Player.GetEnergy() <= 0)
            {
                return false;
            }
            else
            {
                switch (key)
                {
                    case 'w':
                        Player.Move(this, 'w');
                        break;
                    case 'a':
                        Player.Move(this, 'a');
                        break;
                    case 's':
                        Player.Move(this, 's');
                        break;
                    case 'd':
                        Player.Move(this, 'd');
                        break;
                    case 'i':
                        if (Board[Player.GetCoordinates().x, Player.GetCoordinates().y] is River)
                        {
                            Player.Drink();
                            if (Board[Player.GetCoordinates().x, Player.GetCoordinates().y].GetContent() != null)
                            {
                                Player.Eat( Board[Player.GetCoordinates().x, Player.GetCoordinates().y].GetContent());
                                Board[Player.GetCoordinates().x, Player.GetCoordinates().y].SetContent(null);
                            }
                        }
                        else
                        {
                            Player.Eat(Board[Player.GetCoordinates().x, Player.GetCoordinates().y].GetContent());
                            Board[Player.GetCoordinates().x, Player.GetCoordinates().y].SetContent(null);
                        }
                        break;
                    case 'n':
                        if (Player.GetThirst() == false)
                        {
                            Console.WriteLine("If you are still thirsty, you will die during the night. Do you still want to end the day? (y/n)");
                            char key2 = (char)Console.Read();
                            if (key2 == 'y')
                            {
                                return false;
                            }
                            else if (key2 == 'n')
                            {
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    case 'q':
                        return false;
                    default:
                        return true;
                }
                return true;
            }

        }

        public void Play()
        {
            while (true)
            {
                PrintAll();
                if (!GetAction())
                {
                    if (!NextDay())
                    {
                        break;
                    }
                }
            }
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
