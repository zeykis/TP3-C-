using System;

namespace Survivor
{
    public class Hypnos : God
    {
        public Hypnos(Item favourite, Item hated, int maxPatience) : base(favourite, hated, maxPatience)
        {

        }
        

        public Hypnos()
        {
            throw new NotImplementedException("Delete This Constructor When HypnosAdvanced Is Implemented");
        }

        public override void Miracle(Game game)
        {
            PlayerIntermediate.SetEnergy(PlayerIntermediate.GetEnergy() + 5);
            Patience = MaxPatience;   
        }

        public override void Disaster(Game game)
        {
            PlayerIntermediate.SetEnergy(PlayerIntermediate.GetEnergy() - 3);
            Patience = MaxPatience;
        }
        
        public override string ToString()
        {
            return $"{GetType().Name} : {Patience}";
        }
    }
}

