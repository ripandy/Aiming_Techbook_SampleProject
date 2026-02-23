using Cysharp.Threading.Tasks;
using LitMotion;
using TMPro;
using UnityEngine;

namespace Presentation.Animations
{
    public class DamageTextAnimation : MonoBehaviour
    {
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private float floatUpDistance = 1f;
        [SerializeField] private float duration = 1f;

        public async UniTaskVoid Play(int damageAmount)
        {
            damageText.text = damageAmount.ToString();
            var startPosition = transform.position;
            var endPosition = startPosition + Vector3.up * floatUpDistance;

            await LMotion.Create(startPosition, endPosition, duration)
                .Bind(position => transform.position = position)
                .ToUniTask(destroyCancellationToken);

            Destroy(gameObject);
        }
    }
}