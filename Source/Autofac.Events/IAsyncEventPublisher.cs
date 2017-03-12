using System.Threading.Tasks;

namespace Autofac.Events
{
    /// <summary>
    /// Publishes an event asynchronously
    /// </summary>
    public interface IAsyncEventPublisher
    {
        Task PublishAsync(object @event);
    }
}