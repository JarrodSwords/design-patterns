using System.Collections.Generic;
using DesignPatterns.AbstractFactory.Domain;

namespace DesignPatterns.AbstractFactory.Persistence.Database
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        #region IContractRepository

        public ICollection<Contract> Fetch()
        {
            return new List<Contract> {new Contract(Source.Database)};
        }

        #endregion
    }
}
