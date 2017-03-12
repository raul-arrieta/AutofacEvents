namespace Autofac.Events
{
    /// <summary>
    /// Publishes an event
    /// </summary>
    public interface IEventPublisher
    {
        void Publish(object @event);
    }
}
