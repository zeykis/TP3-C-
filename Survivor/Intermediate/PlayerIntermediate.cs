using System;
namespace Survivor
{
    public class PlayerIntermediate : Player
    {
        protected Item[] Inventory; 
        protected readonly int SizeInventory;
        
        public PlayerIntermediate(int maxEnergy, int x, int y) : base(maxEnergy, x, y)
        {
            SizeInventory = 10;
            Inventory = new Item[SizeInventory];
        }
        
        public PlayerIntermediate()
        {
            throw new NotImplementedException("Delete This Constructor When Game Hard Is Implemented");
        }
        
        public void SetEnergy(int energy)
        {
            return Energy = energy;
        }

        public Item[] GetInventory()
        {
            return Inventory;
        }
 
        private static int SelectItem()
        {
            Console.WriteLine("Choose a slot to select (0-9) or 'q' to cancel.");
            string input = Console.ReadLine();
            if (input == "q")
            {
                return -1;
            }
            else if ((int)(input)<9 && (int)(input)>0)
            {
                return SelectItem();
            }
            else
            {
                return (int)(input);
            }
        }
        
        public void PickUp(Cell[,] board)
        {
            if (board[Coordinates.x, Coordinates.y].GetItem() == null)
            {
                throw new ArgumentNullException("The cell is empty.");
            }
            else
            {
                for (int i = 0; i < SizeInventory; i++)
                {
                    if (Inventory[i] == null)
                    {
                        Inventory[i] = board[Coordinates.x, Coordinates.y].GetItem();
                        board[Coordinates.x, Coordinates.y].SetItem(null);
                        break;
                    }
                }
            }
        }

        public void Drop(Cell[,] board)
        {
            int slot = SelectItem();
            if (slot == -1)
            {
                return;
            }
            else
            {
                if (Inventory[slot] == null)
                {
                    return;
                }
                else
                {
                    board[Coordinates.x, Coordinates.y].SetItem(Inventory[slot]);
                    Inventory[slot] = null;
                }
            }
        }
        
        public void Sacrifice(Game game, God god)
        {
            int slot = SelectItem();
            if (slot==-1 || Inventory[slot] == null)
            {
                return;
            }
            else
            {
                god.ReceiveOffering(game, Inventory[slot]);
                Inventory[slot] = null;
            }
        }
    }
}
