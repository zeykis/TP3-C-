using System;

namespace Survivor
{
    public class Player
    {
        protected readonly int MaxEnergy;
        protected int Energy;
        protected bool Thirst;
        protected double Luck;
        protected (int x, int y) Coordinates;

        public Player(int maxEnergy, int x, int y)
        {
            MaxEnergy = maxEnergy;
            Energy = maxEnergy;
            Thirst = false;
            Luck = 0.5;
            Coordinates = (x, y);
        }
        public Player()
        {
            throw new NotImplementedException("Delete This Constructor When Player Hard Is Implemented");
        }

        public double GetLuck()
        {
            return Luck;
        }

        public void SetLuck(double luck)
        {
            Luck = luck;
        }

        public (int x, int y) GetCoordinates()
        {
            return Coordinates;
        }

        public int GetEnergy()
        {
            return Energy;
        }

        public bool GetThirst()
        {
            return Thirst;
        }

        public virtual void Move(Game game, char key)
        {
            if (key == 'w')
            {
                Coordinates.y--;
            }
            else if (key == 'a')
            {
                Coordinates.x--;
            }
            else if (key == 's')
            {
                Coordinates.y++;
            }
            else if (key == 'd')
            {
                Coordinates.x++;
            }
            
        }

        public bool SpendTheNight()
        {
            Console.WriteLine("You spend the night on the ground.");
            Energy = Energy-2;
            if (Energy>0 && Thirst == False)
            {
                return true;
            }
            Thirst = true;
            return false;

        }
        
        public bool Eat(Item food)
        {
            if (food == null)
            {
                throw new ArgumentNullException("There is no food to eat.");
                if (Energy + food.GetEnergyAmount() > MaxEnergy)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        
        public void Drink()
        {
            Thirst = false;
        }

        public override string ToString()
        {
            return "^";
        }
    }
}
