using System;

namespace Survivor
{
    public class Plum : Item
    {
        public Plum(int expiry, int energyAmount)
        {
            // FIXME: this constructor should call parent constructor with multiple parameters using base(a, b, ...)
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        
        public override string ToString()
        {
            return "P";
        }
    }
}