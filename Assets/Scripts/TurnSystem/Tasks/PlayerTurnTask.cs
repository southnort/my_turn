using Game.Events;
using UnityEngine;

namespace Game.Turn
{
    internal sealed class PlayerTurnTask : Task
    {
        private readonly KeyboardInput _input;
        private readonly Player _player;
        private readonly ApplyDirectionHandler _movingHandler;
        private readonly EventBus _eventBus;

        public PlayerTurnTask(KeyboardInput input, PlayerProvider playerService,
            ApplyDirectionHandler movingHandler, EventBus eventBus)
        {
            _input = input;
            _player = playerService.Player;
            _movingHandler = movingHandler;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            _eventBus.PublishEvent(new TurnStartedEvent("Player"));
            _input.MovePerformed += Moving;
            _input.ActionPerformed += Shooting;
        }

        protected override void OnFinish()
        {
            _input.MovePerformed -= Moving;
            _input.ActionPerformed -= Shooting;
        }

        private void Moving(Vector2Int direction)
        {
            if (!_player) return;

            _movingHandler.ApplyDirection(_player, direction);
            Finish();
        }

        private void Shooting(Vector2Int direction)
        {
            if (!_player) return;

            var shootDirection = new Vector3(direction.x, 0, direction.y);
            _player.Get<RotateComponent>().RotateTo(direction, () =>
            {
                _player.Get<IShootable>().ShootInDirection(shootDirection);
                Finish();
            });
        }
    }
}
