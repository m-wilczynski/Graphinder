namespace Localwire.Graphinder.Core
{
    using System;

    public abstract class BaseModel
    {
        public readonly Guid Id;

        protected BaseModel(Guid? id)
        {
            if (id.HasValue && id.Value != Guid.Empty)
                Id = id.Value;
            else
                Id = Guid.NewGuid();
        }
    }
}
