using System;

namespace Survivor
{
    public class Plum : Item
    {
        public Plum(int expiry, int energyAmount) : base(expiry,energyAmount,true)
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
            return "P";
        }
    }
}