namespace Localwire.Graphinder.Algorithms.DataAccess
{
    using System;

    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
