using System;
using System.Collections.Generic;

namespace GameState.Prefabs
{
    [Serializable]
    public class PrefabsMapDto
    {
        public List<PrefabBulletEntryDto> Bullets = new List<PrefabBulletEntryDto>();
        public List<PrefabShipEntry> Ships = new List<PrefabShipEntry>();
        public List<FxDto> FxDto = new List<FxDto>();
    }
}