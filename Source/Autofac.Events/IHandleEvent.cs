﻿namespace Autofac.Events
{
    /// <summary>
    /// Handle an event
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IHandleEvent<in TEvent>
    {
        void Handle(TEvent @event);
    }
}
