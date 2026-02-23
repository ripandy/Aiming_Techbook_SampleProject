using System;
using Soar.Events;
using UnityEngine;

namespace Presentation.Player
{
    public class PlayerHealthManager : MonoBehaviour
    {
        [SerializeField] private PlayerHealthVariable playerHealthVariable;
        [SerializeField] private GameEvent<int> onPlayerDamaged;

        private IDisposable subscription;
        
        private void Start()
        {
            playerHealthVariable.ResetHealth();
            subscription = onPlayerDamaged.Subscribe(ApplyDamage);
        }

        private void ApplyDamage(int damage)
        {
            playerHealthVariable.Value = Mathf.Max(0, playerHealthVariable.Value - damage);
        }

        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}