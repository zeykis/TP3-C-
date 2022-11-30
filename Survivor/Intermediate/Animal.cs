using System;

namespace Survivor
{
    public class Animal: Item
    {
        private bool _isDead;
        
        public Animal(int energyAmount) : base(energyAmount)
        {
            Expiry = 1;
            _isDead = false;
            isEdible = false;

        }

        public void Kill()
        {
            _isDead = true;
            isEdible = true;

        }
        
        public override void Update()
        {
            Expiry--;
        }

        public override string ToString()
        {
            return _isDead ? "D" : "A";
        }
    }
}