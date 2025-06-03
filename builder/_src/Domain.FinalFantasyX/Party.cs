using System;
using System.Collections.Generic;

namespace CreationalPatterns.Builder.Domain.FinalFantasyX
{
    public class Party
    {
        public ICollection<Combatant> Active { get; }
        public ICollection<Combatant> Inactive { get; }

        public void Swap(Combatant active, Combatant inactive)
        {
            throw new NotImplementedException();
        }
    }
}
