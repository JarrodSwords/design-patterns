using System.Collections.Generic;

namespace CreationalPatterns.AbstractFactory.Domain
{
    public interface IRepository<T>
    {
        ICollection<T> Fetch();
    }
}
