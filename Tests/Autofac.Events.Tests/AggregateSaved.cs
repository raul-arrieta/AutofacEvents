namespace Autofac.Events
{
    public class AggregateSaved<TAggregate> : AggregateEvent<TAggregate>
        where TAggregate : Aggregate
    {
        public AggregateSaved(TAggregate aggregate)
            : base(aggregate)
        {
        }

        public AggregateSaved()
        {
        }
    }
}