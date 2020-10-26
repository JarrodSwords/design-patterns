using System.Collections.Generic;

namespace DesignPatterns.Builder.Domain.SuperMarioRpg
{
    public class Party
    {
        #region Public Interface

        public ICollection<Combatant> Active { get; }
        public ICollection<Combatant> Inactive { get; }

        #endregion
    }
}
