using UnityEngine;
using Soar.Events;

namespace Presentation.Damage
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private GameEvent<int> onTargetDamaged;

        [SerializeField] private int damageAmount = 1;
        [SerializeField] private string targetTag = "Player";

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(targetTag)) return;
            onTargetDamaged.Raise(damageAmount);
        }
    }
}