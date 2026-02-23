using System;
using Soar.Variables;
using UnityEngine;

namespace Presentation.Animations
{
    public class MoveAnimation : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        
        [SerializeField] private Variable<Vector2> moveInput;
        [SerializeField] private Transform rootTransform;
        [SerializeField] private Animator animator;
        
        private Vector3 defaultScale;
        
        private IDisposable subscription;

        private void Start()
        {
            if (animator == null)
                animator = GetComponentInChildren<Animator>();
            
            defaultScale = rootTransform.localScale;
            
            subscription = moveInput.Subscribe(OnMoveInputChanged);
        }
        
        private void OnMoveInputChanged(Vector2 inputVector)
        {
            var isMoving = Mathf.Abs(inputVector.x) > 0.01f;
            animator.SetBool(IsMoving, isMoving);
            
            if (inputVector.x == 0) return;
            
            var scale = defaultScale;
            scale.x *= inputVector.x < 0 ? -1 : 1;
            rootTransform.localScale = scale;
        }
        
        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}