using System;
using Presentation.Animations;
using Soar.Events;
using Soar.Variables;
using UnityEngine;

namespace Presentation.Damage
{
    public class DamageUI : MonoBehaviour
    {
        [SerializeField] private GameEvent<int> onPlayerDamaged;
        [SerializeField] private Variable<Transform> playerTransform;
        [SerializeField] private DamageTextAnimation damageAnimationPrefab;

        private IDisposable subscription;

        private void Start()
        {
            subscription = onPlayerDamaged.Subscribe(ShowDamageNumber);
        }

        private void ShowDamageNumber(int damage)
        {
            var transformRef = playerTransform.Value ?? transform;
            var damageNumber = Instantiate(damageAnimationPrefab, transformRef.position, Quaternion.identity, transform);
            damageNumber.Play(damage).Forget();
        }
        
        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}