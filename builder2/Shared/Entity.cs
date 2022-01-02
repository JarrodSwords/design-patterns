using System;

namespace DesignPatterns.Builder2.Shared
{
    public abstract class Entity
    {
        #region Creation

        protected Entity(Guid id = default)
        {
            Id = id == default ? Guid.NewGuid() : id;
        }

        #endregion

        #region Public Interface

        public Guid Id { get; }

        #endregion
    }
}
