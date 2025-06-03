using System.Collections.Generic;
using CreationalPatterns.AbstractFactory.Domain;

namespace CreationalPatterns.AbstractFactory.Persistence.Database
{
    /// <summary>
    ///     Concrete Product
    /// </summary>
    public class ContractRepository : IContractRepository
    {
        public ICollection<Contract> Fetch() => new List<Contract> { new Contract(Source.Database) };
    }
}
