using GameConfig;
using UnityEngine;
using Zenject;

namespace Factories
{
    public class BulletFactory : IFactory<GameObject>
    {
        private GameStateController _gameStateController;

        public BulletFactory(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public GameObject Create()
        {
            return null;
        }
    }
}