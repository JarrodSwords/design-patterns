using System;

namespace CreationalPatterns.Builder2.Shared
{
    public abstract class Entity
    {
        protected Entity(Guid id = default)
        {
            Id = id == default ? Guid.NewGuid() : id;
        }

        public Guid Id { get; }
    }
}
