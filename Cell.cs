using System;

namespace Survivor
{
    public abstract class Cell : IUpdate
    {
        protected Item Content;
        protected int SpawnRange;
        protected int MoveCost;

        protected Cell(int moveCost, int spawnRange)
        {
            throw new NotImplementedException();
        }

        protected Cell()
        {
            throw new NotImplementedException("Delete This Constructor When Game Hard Is Implemented");
        }

        public Item GetContent()
        {
            throw new NotImplementedException();
        }
        
        public void SetContent(Item item)
        {
            throw new NotImplementedException();
        }
        
        public int GetSpawnRange()
        {
            throw new NotImplementedException();
        }
        
        public int GetMoveCost()
        {
            throw new NotImplementedException();
        }
        
        public void SetMoveCost(int cost)
        {
            throw new NotImplementedException();
        }
        
        public virtual void Update()
        {
            throw new NotImplementedException();
        }
    }
}