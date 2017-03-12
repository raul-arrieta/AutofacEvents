using Autofac.Events.Tests.Handlers;
using Xunit;

namespace Autofac.Events.Tests
{
    public class InfrastructureEventTests : UnitTests
    {
        [Fact]
        public void AllInfrastructureEventsAreReceived()
        {
            using (var scope = BeginScope())
            {
                var @event = new DebugEvent()
                {
                    Message = "Test"
                };
                scope.PublishEvent(@event);
                var handler = scope.Resolve<InfrastructureEventHandler>();
                Assert.Equal(@event, handler.LastEvent);
            }
        }
    }
}
