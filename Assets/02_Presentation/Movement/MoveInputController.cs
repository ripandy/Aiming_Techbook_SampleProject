using System;
using R3;
using Soar.Variables;
using UnityEngine;

namespace Presentation.Movement
{
    public class MoveInputController : MonoBehaviour
    {
        [SerializeField] private Variable<Vector2> moveInput;
        
        [SerializeField] private Transform rootTransform;
        [SerializeField] private float moveSpeed = 5f;
        
        private IDisposable subscriptions;

        private void Start()
        {
            if (rootTransform == null)
                rootTransform = transform;
            
            subscriptions = Observable
                .EveryUpdate(UnityFrameProvider.FixedUpdate, destroyCancellationToken)
                .Subscribe(_ => MoveBee(moveInput.Value));
        }
        
        private void MoveBee(Vector2 inputVector)
        {
            var moveVector = new Vector3(inputVector.x, 0, 0) * moveSpeed;
            rootTransform.Translate(moveVector * Time.fixedDeltaTime);
        }
        
        private void OnDestroy()
        {
            subscriptions?.Dispose();
        }
    }
}