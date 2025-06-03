using System.Collections.Generic;

namespace CreationalPatterns.Prototype.Domain
{
    public class Player
    {
        public Player()
        {
            Inventory = new List<Item>();
        }

        public ICollection<Item> Inventory { get; }
    }
}
