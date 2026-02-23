using System;
using Presentation.Player;
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
            slider.value = playerHealthVariable.Ratio;
            subscription = playerHealthVariable.Subscribe(UpdateHealthBar);
        }

        private void UpdateHealthBar()
        {
            slider.value = playerHealthVariable.Ratio;
        }

        private void OnDestroy()
        {
            subscription?.Dispose();
        }
    }
}