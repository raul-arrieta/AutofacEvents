namespace Autofac.Events
{
    public abstract class LogEvent : InfrastructureEvent
    {
        public string Message { get; set; }
    }
}