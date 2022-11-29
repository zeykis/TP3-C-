using System;

namespace Survivor
{
    public class Coconut : Item

    {
        public Coconut(int expiry, int energyAmount) : base(expiry,energyAmount,true)
        {
            Expiry = expiry;
            EnergyAmount = energyAmount;
        }
        
        public override void Update()
        {
            Expiry--;
        }
        
        public override string ToString()
        {
            return "C";
        }
    }
}