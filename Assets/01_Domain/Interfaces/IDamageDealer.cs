using System;

namespace Domain.Interfaces
{
    public interface IDamageDealer
    {
        IDisposable Subscribe(Action<int> onDamaged);
    }
}