using Soar.Variables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PyrasLab.InputSystemHandler
{
    public class InputSystemVariable<T> : Variable<T> where T : struct
    {
        [SerializeField] private EventTypeFlag eventRaisePhase;
        
        public void Raise(InputAction.CallbackContext context)
        {
            if (!ShouldRaise()) return;
            
            var valueToRaise = context.ReadValue<T>();
            Raise(valueToRaise);

            bool ShouldRaise() =>
                context.started && eventRaisePhase.HasFlag(EventTypeFlag.Started) ||
                context.performed && eventRaisePhase.HasFlag(EventTypeFlag.Performed) ||
                context.canceled && eventRaisePhase.HasFlag(EventTypeFlag.Canceled);
        }
    }
}