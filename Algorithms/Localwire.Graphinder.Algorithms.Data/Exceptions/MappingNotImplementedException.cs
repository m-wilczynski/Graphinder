namespace Localwire.Graphinder.Algorithms.DataAccess.Exceptions
{
    using System;
    using Core;
    using Entities;

    internal class MappingNotImplementedException : Exception
    {
        /// <summary>
        /// Entity that has no mapping (if applies)
        /// </summary>
        public readonly BaseEntity Entity;

        /// <summary>
        /// Domain model that has no mapping (if applies)
        /// </summary>
        public readonly BaseModel Model;

        public MappingNotImplementedException(BaseEntity entity)
            : base (message: "Mapper for provided entity model of type" + entity.GetType() + "not found")
        {
            Entity = entity;
        }

        public MappingNotImplementedException(BaseModel model)
            : base(message: "Mapper for provided domain model of type" + model.GetType() + " not found")
        {
            Model = model;
        }
    }
}