using UnityEngine;
using Soar.Events;

namespace Presentation.Animations
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] private GameEvent<int> onTargetDamaged;

        [SerializeField] private int damageAmount = 10;
        [SerializeField] private string targetTag = "Player";

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(targetTag))
            {
                onTargetDamaged.Raise(damageAmount);
            }
        }
    }
}