using DG.Tweening;
using Game.Movement;
using Game.Movement.States;
using GameConfig;
using UnityEngine;
using Zenject;

namespace Game.Enemy
{
    public class EnemyAIMovementSystem : AbstractMovementSystem
    {
        protected virtual void Start()
        {
            base.Start();

            _currentState = new MovementMoveState(this);

            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => Direction, x => Direction = x, new Vector2(0, 1), 1));
            sequence.Append(DOTween.To(() => Direction, x => Direction = x, new Vector2(-1, -1), 1));
            sequence.Append(DOTween.To(() => Direction, x => Direction = x, new Vector2(-1, 1), 1));
            sequence.Append(DOTween.To(() => Direction, x => Direction = x, new Vector2(1, 1), 1));
            sequence.SetLoops(5);
        }


        [Inject]
        public void Construct(SignalBus signalBus, GameStateController gameStateController)
        {
            base.Construct(signalBus, gameStateController);
        }
    }
}