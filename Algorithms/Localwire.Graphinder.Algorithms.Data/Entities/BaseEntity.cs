namespace Localwire.Graphinder.Algorithms.DataAccess.Entities
{
    using System;

    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            if (Id.Equals(Guid.Empty))
                Id = Guid.NewGuid();
        }
    }
}
