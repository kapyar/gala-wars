using System.Linq;
using GameState.Bullet;
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

        public GameObject GetShip(string shipId)
        {
            return _prefabsMapDto.Ships.FirstOrDefault(x => x.Id == shipId).Prefab;
        }

        public GameObject GetFX(string fxId)
        {
            return _prefabsMapDto.FxDto.FirstOrDefault(x => x.Id == fxId).Prefab;
        }
    }
}