using Domain.Player;
using Soar.Variables;
using UnityEngine;

namespace Presentation.Player
{
    public class PlayerHealthVariable : Variable<int>
    {
        [SerializeField] private PlayerData playerData;
        
        public float Ratio => (float)Value / playerData.maxHP;

        public void ResetHealth()
        {
            Value = playerData.maxHP;
        }
    }
}