using Soar.Variables;
using UnityEngine;

namespace PyrasLab.TransformManagement
{
    /// <summary>
    /// Assign target transform to a TransformVariable instance.
    /// If target is null, make own transform as target.
    /// </summary>
    public class TransformVariableAssigner : MonoBehaviour
    {
        [SerializeField] private Variable<Transform> transformVariable;
        [Tooltip("Target transform to assign. Fallback to own transform if not found.")]
        [SerializeField] private Transform target;

        private void Awake()
        {
            if (target == null)
            {
                target = transform;
            }
            
            transformVariable.Value = target;
        }
    }
}