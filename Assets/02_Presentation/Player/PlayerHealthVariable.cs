using Domain.Interfaces;
using Soar.Variables;
using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(fileName = "PlayerHealthVariable", menuName = "Game/Variables/PlayerHealth")]
    public class PlayerHealthVariable : Variable<HealthDto>, IHealthPresenter { }
}