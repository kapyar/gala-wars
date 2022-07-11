using GameState.Ships;
using UnityEngine;

namespace Game
{
    public abstract class AbstractShipController : MonoBehaviour
    {
        public abstract ShipDto GetShipDto();
    }
}