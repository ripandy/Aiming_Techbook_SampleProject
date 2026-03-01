using Domain.Interfaces;
using Soar.Events;
using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(fileName = "DamageDealerEvent", menuName = "Game/Events/DamageDealer")]
    public class DamageDealerEvent : GameEvent<int>, IDamageDealer { }
}