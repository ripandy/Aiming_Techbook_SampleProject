using Domain;
using Soar.Variables;
using UnityEngine;

namespace Presentation
{
    [CreateAssetMenu(fileName = "PlayerMasterData", menuName = "Game/MasterData/Player")]
    public class PlayerMasterData : JsonableVariable<PlayerData>
    {
    }
}