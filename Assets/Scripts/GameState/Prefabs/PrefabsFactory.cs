using System.Linq;
using UnityEngine;

namespace GameState.Prefabs
{
    public class PrefabsFactory 
    {
        private readonly PrefabsMapDto _prefabsMapDto;

        public PrefabsFactory(PrefabsMapDto dto)
        {
            _prefabsMapDto = dto;
        }

        public GameObject GetBullet(BulletType id)
        {
            return _prefabsMapDto.Bullets.FirstOrDefault(x => x.Id == id).Prefab;
        }
    }
}