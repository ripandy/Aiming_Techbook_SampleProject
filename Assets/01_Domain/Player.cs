using System;

namespace Domain
{
    public class Player
    {
        public int CurrentHP { get; private set; }
        public int MaxHP { get; }

        public Player(PlayerData data)
        {
            MaxHP = data.maxHP;
            CurrentHP = data.maxHP;
        }

        public void ApplyDamage(int damage)
        {
            CurrentHP = Math.Max(0, CurrentHP - damage);
        }
    }
}