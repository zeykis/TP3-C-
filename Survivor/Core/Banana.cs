﻿using System;

namespace Survivor
{
    public class Banana : Item
    {
        
        public Banana(int expiry, int energyAmount) : base(expiry,energyAmount,true)
        {
        }
        
        public override void Update()
        {
            Expiry--;
        }

        public override string ToString()
        {
            return "B"; 
        }
    }
}