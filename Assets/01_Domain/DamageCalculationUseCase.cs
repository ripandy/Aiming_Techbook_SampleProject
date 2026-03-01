using System;
using Domain.Interfaces;

namespace Domain.UseCase
{
    public class DamageCalculationUseCase : IDisposable
    {
        private readonly Player player;
        private readonly IHealthPresenter healthPresenter;
        private readonly IDisposable subscription;

        public DamageCalculationUseCase(
            Player player,
            IDamageDealer damageDealer,
            IHealthPresenter healthPresenter)
        {
            this.player = player;
            this.healthPresenter = healthPresenter;
            
            PushHealthBar();
            subscription = damageDealer.Subscribe(OnDamaged);
        }

        private void OnDamaged(int damage)
        {
            player.ApplyDamage(damage);
            PushHealthBar();
        }

        private void PushHealthBar()
        {
            healthPresenter.Value = new HealthDto
            {
                currentHP = player.CurrentHP,
                maxHP = player.MaxHP
            };
        }

        public void Dispose() => subscription?.Dispose();
    }
}