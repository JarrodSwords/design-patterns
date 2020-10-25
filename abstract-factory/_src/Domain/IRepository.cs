using System.Collections.Generic;

namespace DesignPatterns.AbstractFactory.Domain
{
    public interface IRepository<T>
    {
        ICollection<T> Fetch();
    }
}
