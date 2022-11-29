using System;

namespace Survivor
{
    public class Demeter : God
    {
        public Demeter(Item favourite, Item hated, int maxPatience) : base (favourite, hated, maxPatience)
        {

        }
        
        public override void Miracle(Game game)
        {
            game.SpawnRate += 5;
            Patience = MaxPatience;
        }

        public override void Disaster(Game game)
        {
            game.SpawnRate -= 3;
            Patience = MaxPatience;
        }
        
        public override string ToString()
        {
            return $"{GetType().Name} : {Patience}";
        }
    }
}

