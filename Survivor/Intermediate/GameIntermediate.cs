using System;

namespace Survivor
{
    public class GameIntermediate: Game
    {
        protected God[] Gods;

        public GameIntermediate(Random random, int spawnRate, int daysLeft, int boardWidth, int boardHeight) : base (random, spawnRate, daysLeft, boardWidth, boardHeight)
        {
            Player player = new PlayerIntermediate(30, boardWidth/2, boardHeight/2);
            God gods = new God[3];
            gods[0] = new Demeter(Plum,Animal,4);
            gods[1] = new Hypnos(Coconut, Banana, 2);
            gods[2] = new Poseidon(Banana, Plum, 2);
            gods[3] = new Tyche(Animal, Coconut, 3);
        }

        public GameIntermediate()
        {
            throw new NotImplementedException("Delete This Constructor When Game Hard Is Implemented");
        }

        public void SetSpawnRate(int newSpawnRate)
        {
            SpawnRate = newSpawnRate;
        }
        
        public int GetSpawnRate()
        {
            return SpawnRate;
        }
        
        public Player GetPlayer()
        {
            return Player;
        }

        public void IncreaseDaysLeft(int days)
        {
            DaysLeft += days;
        }
        
        protected void MakeOffering()
        {
            Console.WriteLine("If you want to make an offering, select the god to whom you want to sacrifice. (quit with 'q').");
            string input = Console.ReadLine();
            if(input == 'q')
            {
                return;
            }
            else if ((int)(input)<Gods.GetLength(0) && (int)(input)>0)
            {
                Sacrifice(this, Gods[(int)(input)]);
            }
            else if (input == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                MakeOffering();
            }
        }
        
        protected override void SpawnItem(int x, int y)
    {
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
                if (Random.Next(0, 2) == 0)
                {
                    x2 = -x2;
                }
                if (Random.Next(0, 2) == 0)
                {
                    y2 = -y2;
                }
            }
            if (Board[x,y].GetContent() == null)
            {
                if (Board[x+x2,y+y2] is Forest)
                {
                    if (Random.Next(0, 5) == 1)
                    {
                        Board[x+x2,y+y2].SetContent(new Animal(12));
                    }
                    else
                    {
                        Board[x+x2,y+y2].SetContent(new Banana(3,7));
                    }
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
    }
        
        protected override bool NextDay()
        {
            if (DaysLeft == 0)
            {
                return false;
            }
            else
            {
                DaysLeft--;
                MakeOffering();
                for (int i = 0; i < Gods.GetLength(0); i++)
                {
                    Gods[i].Update();
                    if (Gods[i].GetPatience() == 0)
                    {
                        Gods[i].Disaster(this);
                    }
                }
                UpdateBoard();
                Spawn();
                return true;
            }    
        }
        
        protected override bool GetAction() 
        {
            
        }    
        
        protected void PrintGods()
        {
            throw new NotImplementedException();
        }

        protected void PrintInventory()
        {
            throw new NotImplementedException();
        }

        protected override void PrintAll()
        {
            throw new NotImplementedException();
        }
    }
}
