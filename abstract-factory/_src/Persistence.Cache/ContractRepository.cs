using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Cache
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        #region IContractRepository

        public ICollection<Contract> Fetch()
        {
            return new List<Contract> {new Contract(Source.Cache)};
        }

        #endregion
    }
}
