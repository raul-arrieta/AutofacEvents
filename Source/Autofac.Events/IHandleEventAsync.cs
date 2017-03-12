﻿using System.Threading.Tasks;

namespace Autofac.Events
{
    /// <summary>
    /// Handle an event asynchronously
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    public interface IHandleEventAsync<in TEvent>
    {
        Task HandleAsync(TEvent @event);
    }
}