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
            if (Random.Next(0, 2) == 1)
            {
                x2 = -x2;
            }
            if (Random.Next(0, 2) == 1)
            {
                y2 = -y2;
            }
            while (x + x2 < 0 || x + x2 >= Board.GetLength(0) || y + y2 < 0 || y + y2 >= Board.GetLength(1))
            {
                range = Random.Next(1, Board[x, y].GetSpawnRange());
                x2 = Random.Next(0, range);
                y2 = x2 - range;
                if (Random.Next(0, 2) == 1)
                {
                    x2 = -x2;
                }
                if (Random.Next(0, 2) == 1)
                {
                    y2 = -y2;
                }
            }
            // if the cell is forest spawn a banana, if sea coconut, if river, plum
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
                    int x = Random.Next(1, 100);
                    if (x <= SpawnRate * Player.GetLuck())
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
//             End the day of the player by calling SpendTheNight(). If there is no more days left or the player lost, end the game with a call to PrintEnd().
// Decrease the number of days left by 1 then update the board. Finally, call the method Spawn() to generate new items.
// Return true if the player can keep playing, false otherwise.
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
           /*  This method is at the heart of the game, because it is used as an interface between the inputs given by the user and the actions of the player.
You have to get the key pressed by the user.
Whatever the action asked by the user, if the player has no energy left, you have to end the day and return false.
'w' 'a' 's' 'd'	 	move.
'i'	 	eat or drink depending on the cell type.
'n'	 	sleep (to end the day).
'q'	 	quit the game; return false.

If the user chose to end the day ('n'), there is two possibilities: if the player is not thirsty, call NextDay(), otherwise display the following sentence:
"If you are still thirsty, you will die during the night. Do you still want to end the day? (y/n)"
As long as the user pushes another key than 'y' or 'n', ask the question again.
If the user chooses the key 'y', end the day with a call to NextDay().
If the user chooses the key 'n', return true.
In a more general way, return true if the player keeps playing, otherwise return false.
        */ 
       /*  If the player is on a river cell and presses 'i', call the method Drink().
Otherwise pressing 'i' will amount to calling the method Eat().
In the case where an item would be on a River the player tries to interract with, make the player drink first then eat. If the item is eaten, do not forget to reset the Content of the cell to null.

If the player presses another key than those authorised ('w', 'a', 's', 'd' for the moment but soon, more keys will be added to the list), do nothing.

More about the gameplay than how to code it, remember that the character looses energy each night so do not wait for them to get to 0 energy to end the day or your character will not wake up. 
         */
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
