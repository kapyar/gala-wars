using System;
using GameState.Bullet;
using UnityEngine;

namespace GameState.Prefabs
{
    //TODO (yk): it is better to create Resource loader and load from resources or adrressable loader
    // maybe later will add that service
    [Serializable]
    public class PrefabBulletEntryDto
    {
        public BulletType Id;
        public GameObject Prefab;
    }
}