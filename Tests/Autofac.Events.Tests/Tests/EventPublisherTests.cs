﻿using System;
using System.Threading.Tasks;
using Autofac.Events.Tests.Handlers;
using Xunit;

namespace Autofac.Events.Tests
{
    public class EventPublisherTests : UnitTests
    {
        [Fact]
        public void EventPublisherPublishes()
        {
            using (var scope = BeginScope())
            {
                var start = new StartEvent();
                var stop = new StopEvent();
                var pub = scope.Resolve<IEventPublisher>();
                pub.Publish(start);
                pub.Publish(stop);
                var syncHandler = scope.Resolve<InfrastructureEventHandler>();
                Assert.Equal(2, syncHandler.Events.Count);
                Assert.Equal(start, syncHandler.Events[0]);
                Assert.Equal(stop, syncHandler.Events[1]);
                var asyncHandler = scope.Resolve<AsyncInfrastructureEventHandler>();
                Assert.Equal(2, asyncHandler.Events.Count);
                Assert.Equal(start, asyncHandler.Events[0]);
                Assert.Equal(stop, asyncHandler.Events[1]);
            }
        }

        [Fact]
        public void ThrowingHandlerThrowsAndAllHandlersAreCalled()
        {
            using (var scope = BeginScope())
            {
                var thrower = scope.Resolve<ThrowingThrowEventHandler>();
                var handler = scope.Resolve<NonThrowingThrowEventHandler>();
                var exception = Assert.Throws<AggregateException>(() => scope.PublishEvent(new ThrowEvent()));
                Assert.Equal(1, handler.Events.Count);
                Assert.True(thrower.ThrewException);
                Assert.Equal(2, exception.InnerExceptions.Count);
                Assert.True(exception.InnerExceptions[0].Message.StartsWith("Intentional error for "));
            }
        }

        [Fact]
        public async Task AsyncEventPublisherPublishes()
        {
            using (var scope = BeginScope())
            {
                var start = new StartEvent();
                var stop = new StopEvent();
                var pub = scope.Resolve<IAsyncEventPublisher>();
                await pub.PublishAsync(start);
                await pub.PublishAsync(stop);
                var syncHandler = scope.Resolve<InfrastructureEventHandler>();
                Assert.Equal(2, syncHandler.Events.Count);
                Assert.Equal(start, syncHandler.Events[0]);
                Assert.Equal(stop, syncHandler.Events[1]);
                var asyncHandler = scope.Resolve<AsyncInfrastructureEventHandler>();
                Assert.Equal(2, asyncHandler.Events.Count);
                Assert.Equal(start, asyncHandler.Events[0]);
                Assert.Equal(stop, asyncHandler.Events[1]);
            }
        }

        [Fact]
        public void ThrowingAsyncHandlerThrowsAndAllHandlersAreCalled()
        {
            using (var scope = BeginScope())
            {
                var thrower = scope.Resolve<AsyncThrowingThrowEventHandler>();
                var handler = scope.Resolve<NonThrowingThrowEventHandler>();
                var exception = Assert.Throws<AggregateException>(() => scope.PublishEvent(new ThrowEvent()));
                Assert.Equal(1, handler.Events.Count);
                Assert.True(thrower.ThrewException);
                Assert.Equal(2, exception.InnerExceptions.Count);
                Assert.True(exception.InnerExceptions[0].Message.StartsWith("Intentional error for "));
            }
        }
    }
}

