using System;

namespace Survivor
{
    public class Banana : Item
    {
        
        public Banana(int expiry, int energyAmount)
        {
            // FIXME: this constructor should call parent constructor with multiple parameters using base(a, b, ...)
            base.Expiry = expiry;
            base.EnergyAmount = energyAmount;
            base.IsEdible = true;
        }
        
        public override void Update()
        {
            return Expiry--;
        }

        public override string ToString()
        {
            return "B"; 
        }
    }
}