namespace Localwire.Graphinder.Core
{
    using System;

    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }

        protected BaseEntity(Guid? id)
        {
            if (id.HasValue && id.Value != Guid.Empty)
                Id = id.Value;
            else
                Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
    }
}
