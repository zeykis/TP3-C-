using System;

namespace Survivor
{
    public abstract class Item : IUpdate
    { 
        protected int Expiry;
        protected int EnergyAmount;
        protected bool IsEdible;
        
        protected Item(int expiry, int energyAmount, bool isEdible)
        {
            throw new NotImplementedException();
        }
        
        protected Item()
        {
            throw new NotImplementedException("Delete This Constructor When All Items are Implemented");
        }
        
        public abstract void Update();
        
        public int GetEnergyAmount()
        {
            throw new NotImplementedException();
        }
        
        public int GetExpiry()
        {
            throw new NotImplementedException();
        }
        
        public bool GetIsEdible()
        {
            throw new NotImplementedException();
        }
    }
}