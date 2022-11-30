using System;

namespace Survivor
{
    public class Tyche : God
    {
        public Tyche(Item favourite, Item hated, int maxPatience) : base(favourite, hated, maxPatience)
        {
            
        }


        public override void Miracle(Game game)
        {
            Player.SetLuck(Player.GetLuck() + 0.25);
            Patience = MaxPatience;
        }
        
        public override void Disaster(Game game)
        {
            Player.SetLuck(Player.GetLuck() - 0.25);
        }
        
        public override string ToString()
        {
            return $"{GetType().Name} : {Patience}";
        }
    }
}

