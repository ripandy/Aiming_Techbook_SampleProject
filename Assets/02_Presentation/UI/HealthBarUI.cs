using System;
using Domain.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealthVariable playerHealthVariable;
        [SerializeField] private Slider slider;
        
        private IDisposable subscription;

        private void Start()
        {
            slider.value = playerHealthVariable.Value.Ratio;
            subscription = playerHealthVariable.Subscribe(UpdateHealthBar);
        }

        private void UpdateHealthBar(HealthDto health)
        {
            slider.value = health.Ratio;
        }

        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}