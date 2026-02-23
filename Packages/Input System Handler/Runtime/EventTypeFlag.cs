using System;

namespace PyrasLab.InputSystemHandler
{
    [Flags]
    internal enum EventTypeFlag
    {
        Started = 1,
        Performed = 1 << 1,
        Canceled = 1 << 2
    }
}