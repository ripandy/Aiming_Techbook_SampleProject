using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Presentation.Animations
{
    public class AutoBlinkAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject blinkObject;
        
        private IDisposable subscription;

        private void Start()
        {
            subscription = Observable.Interval(TimeSpan.FromSeconds(3), destroyCancellationToken)
                .SubscribeAwait(async (_, token) => await TryUpdateAutoBlink(token));
        }
        
        private void OnDestroy()
        {
            subscription?.Dispose();
        }
        
        private async UniTask TryUpdateAutoBlink(CancellationToken token = default)
        {
            const float blinkChance = 0.4f;
            if (Random.value > blinkChance) return;
            
            blinkObject.SetActive(true);
            
            const float blinkDuration = 0.2f;
            await UniTask.Delay(TimeSpan.FromSeconds(blinkDuration), cancellationToken: token);
            
            blinkObject.SetActive(false);
        }
    }
}