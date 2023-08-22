using Game.Entities;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class ApplyDirectionHandler
    {
        [Inject] private GameGrid _gameGrid;

        public void ApplyDirection(IEntity entity, Vector2Int direction)
        {
            var rotate = entity.Get<RotateComponent>();
            rotate.RotateTo(direction, () =>
                    HandleDirection(entity, direction));
        }

        private void HandleDirection(IEntity entity, Vector2Int direction)
        {
            var coords = entity.Get<GridCoordinatesComponent>();
            var targetCoords = coords.GridCoordinates + direction;


            if (!_gameGrid.IsTileExists(targetCoords))
            {
                Fall(entity, targetCoords);
                return;
            }

            if (_gameGrid.IsTileReserved(targetCoords))
            {
                Attack(entity, targetCoords);
                return;
            }

            Move(entity, targetCoords);
        }

        private void Fall(IEntity entity, Vector2Int targetCoords)
        {
            entity.Get<FallComponent>().FallTo(_gameGrid.GetPositionOf(targetCoords));
            _gameGrid.ReleaseTile(entity.Get<GridCoordinatesComponent>().GridCoordinates);
        }

        private void Attack(IEntity entity, Vector2Int targetCoords)
        {
            if (entity.TryGet<MeleeAttackComponent>(out var meleeAttack))
            {
                meleeAttack.Attack(targetCoords);
            }
        }

        private void Move(IEntity entity, Vector2Int targetCoords)
        {
            var gridCoords = entity.Get<GridCoordinatesComponent>();
            var coords = _gameGrid.GetPositionOf(targetCoords);
            var move = entity.Get<MoveComponent>();

            _gameGrid.ReleaseTile(gridCoords.GridCoordinates);
            _gameGrid.ReserveTile(targetCoords, entity);
            gridCoords.GridCoordinates = targetCoords;

            move.MoveTo(coords);
        }
    }
}
