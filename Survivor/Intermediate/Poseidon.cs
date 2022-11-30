using System;

namespace Survivor
{
    public class Poseidon : God
    {
        public Poseidon(Item favourite, Item hated, int maxPatience) : base (favourite, hated, maxPatience)
        {
            
        }
        
        public Poseidon()
        {
            throw new NotImplementedException("Delete This Constructor When PoseidonAdvanced Is Implemented");
        }

        public override void Miracle(Game game)
        {
            Random (x,y) = (new Random(),new Random());
            if (board[x,y] is Forest)
            {
                board[x,y] = new River(2,3);
                if(board[x,y].GetContent() != null)
                {
                    board[x,y].SetContent(null);
                }
            }
            Patience = MaxPatience;      
        }  
        public override void Disaster(Game game)
        {
            game.SetDaysLeft(game.GetDaysLeft() + 1);
            Patience = MaxPatience;
        }
        public override string ToString()
        {
            return $"{GetType().Name} : {Patience}";
        }
    }
}
