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
            throw new NotImplementedException();
        }
        public Player()
        {
            throw new NotImplementedException("Delete This Constructor When Player Hard Is Implemented");
        }

        public double GetLuck()
        {
            throw new NotImplementedException();
        }

        public void SetLuck(double luck)
        {
            throw new NotImplementedException();
        }

        public (int x, int y) GetCoordinates()
        {
            throw new NotImplementedException();
        }

        public int GetEnergy()
        {
            throw new NotImplementedException();
        }

        public bool GetThirst()
        {
            throw new NotImplementedException();
        }

        public virtual void Move(Game game, char key)
        {
            throw new NotImplementedException();
        }

        public bool SpendTheNight()
        {
            throw new NotImplementedException();
        }
        
        public bool Eat(Item food)
        {
            throw new NotImplementedException();
        }
        
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "^";
        }
    }
}
