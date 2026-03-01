using System;

namespace Domain.Interfaces
{
    [Serializable]
    public struct HealthDto
    {
        public int currentHP;
        public int maxHP;

        public float Ratio => maxHP > 0 ? (float)currentHP / maxHP : 0f;
    }
    
    public interface IHealthPresenter
    {
        HealthDto Value { set; }
    }
}