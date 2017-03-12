﻿using System;
using System.Threading.Tasks;

namespace Autofac.Events.Tests.Handlers
{
    public class AsyncThrowingThrowEventHandler : IHandleEventAsync<ThrowEvent>
    {
        public bool ThrewException { get; private set; }

        public async Task HandleAsync(ThrowEvent @event)
        {
            ThrewException = true;
            throw new InvalidOperationException("Intentional error for " + @event);
        }

    }
}