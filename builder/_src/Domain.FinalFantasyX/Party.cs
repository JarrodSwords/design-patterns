using System;
using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.FinalFantasyX
{
    public class Party
    {
        #region Public Interface

        public ICollection<Combatant> Active { get; }
        public ICollection<Combatant> Inactive { get; }

        public void Swap(Combatant active, Combatant inactive)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
