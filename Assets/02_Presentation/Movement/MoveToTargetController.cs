using System;
using R3;
using Soar.Variables;
using UnityEngine;

namespace Presentation.Movement
{
    public class MoveToTargetController : MonoBehaviour
    {
        [SerializeField] private Variable<Transform> targetTransform;
        [SerializeField] private Transform rootTransform;
        [SerializeField] private Rigidbody2D physicsBody;
        [SerializeField] private float moveSpeed = 3f;

        private const string TargetTag = "Player";

        private Rigidbody2D PhysicsBody => physicsBody ??= GetComponent<Rigidbody2D>();
        
        private Vector3 defaultScale;
        private Vector3 moveVector;

        private IDisposable subscription;
        
        private void Start()
        {
            if (rootTransform == null)
                rootTransform = transform;
            
            defaultScale = rootTransform.localScale;
            
            subscription = Observable.EveryUpdate(UnityFrameProvider.FixedUpdate, destroyCancellationToken)
                .Subscribe(_ => MoveToTarget(targetTransform.Value));
        }

        private void MoveToTarget(Transform targetTransformValue)
        {
            if (targetTransformValue == null) return;
            
            var direction = (targetTransformValue.position - rootTransform.position).normalized;
            moveVector = direction * moveSpeed;
            rootTransform.Translate(moveVector * Time.fixedDeltaTime);
            
            if (moveVector.x == 0) return;
            
            var scale = defaultScale;
            scale.x *= moveVector.x < 0 ? 1 : -1;
            rootTransform.localScale = scale;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(TargetTag)) return;
            
            const float bounceForce = -5f;
            var bounceVector = moveVector;
            bounceVector.y *= moveVector.y > 0 ? -1 : 1;
            var force = bounceVector * bounceForce;
            PhysicsBody.AddForce(force, ForceMode2D.Impulse);
        }

        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}