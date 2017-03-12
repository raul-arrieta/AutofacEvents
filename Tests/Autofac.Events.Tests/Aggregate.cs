using System;

namespace Autofac.Events
{
    public abstract class Aggregate
    {
        protected Aggregate()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}