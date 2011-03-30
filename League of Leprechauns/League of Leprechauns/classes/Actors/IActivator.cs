using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL
{
    public delegate void ActivatedEvent();

    interface IActivator
    {
        event ActivatedEvent ActivatedEvent;
    }
}
