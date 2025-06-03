using System.Collections.Generic;

namespace CreationalPatterns.Builder.Domain.SuperMarioRpg
{
    public class Party
    {
        public ICollection<Combatant> Active { get; }
        public ICollection<Combatant> Inactive { get; }
    }
}
