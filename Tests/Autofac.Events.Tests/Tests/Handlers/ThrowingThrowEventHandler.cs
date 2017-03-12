﻿using System;

namespace Autofac.Events.Tests.Handlers
{
    public class ThrowingThrowEventHandler : IHandleEvent<ThrowEvent>
    {
        public bool ThrewException { get; private set; }

        public void Handle(ThrowEvent @event)
        {
            ThrewException = true;
            throw new InvalidOperationException("Intentional error for " + @event);
        }
    }
}