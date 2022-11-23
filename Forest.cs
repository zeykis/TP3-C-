using System;

namespace Survivor
{
    public class Forest : Cell
    {
        public Forest(int moveCost, int spawnRange)
        {
            // FIXME: this constructor should call parent constructor with multiple parameters using base(a, b, ...)
            base.MoveCost = moveCost;
            base.SpawnRange = spawnRange;
            
        }
        
        public override string ToString()
        {
            return (Content != null ? Content.ToString() : " ");
        }

    }
}


