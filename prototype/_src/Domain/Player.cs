using System.Collections.Generic;

namespace DesignPatterns.Prototype.Domain
{
    public class Player
    {
        #region Core

        public Player()
        {
            Inventory = new List<Item>();
        }

        #endregion

        #region Public Interface

        public ICollection<Item> Inventory { get; }

        #endregion
    }
}
