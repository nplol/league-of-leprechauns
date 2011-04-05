
namespace LoL
{
    public delegate void ActivatedEvent();

    interface IActivator
    {
        event ActivatedEvent ActivatedEvent;
    }
}
