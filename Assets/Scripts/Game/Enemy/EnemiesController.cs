using Game.Events;
using Game.Turn;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class EnemiesController : MonoBehaviour
    {
        private Player _player;
        private ApplyDirectionHandler _movingHandler;
        private EventBus _eventBus;

        [Inject]
        public void Construct(PlayerProvider playerService, ApplyDirectionHandler movingHandler, EventBus eventBus)
        {
            _player = playerService.Player;
            _movingHandler = movingHandler;
            _eventBus = eventBus;
        }

        internal void HandleEnemies(IEnumerable<Enemy> enemies, Action onHandledCallback)
        {
            StartCoroutine(HandleEnemiesCoroutine(enemies, onHandledCallback));
        }

        private IEnumerator HandleEnemiesCoroutine(IEnumerable<Enemy> enemies, Action onHandledCallback)
        {
            var index = 0;
            foreach (var enemy in enemies)
            {
                if (enemy == null) continue;                
                yield return new WaitForSeconds(0.3f);
                _eventBus.PublishEvent(new TurnStartedEvent($"Enemy{index}"));
                HandleEnemy(enemy);
                yield return new WaitForSeconds(0.3f);
                index++;
            }

            onHandledCallback();
        }

        private void HandleEnemy(Enemy enemy)
        {
            var enemyCoords = enemy.Get<GridCoordinatesComponent>().GridCoordinates;
            var playerCoords = _player.Get<GridCoordinatesComponent>().GridCoordinates;


            var direction = playerCoords - enemyCoords;
            var deltaX = Mathf.Abs(direction.x);
            var deltaY = Mathf.Abs(direction.y);

            if (deltaX > deltaY)
            {
                direction.y = 0;
            }

            else
                direction.x = 0;


            if (direction.x != 0)
                direction.x /= (Mathf.Abs(direction.x));

            if (direction.y != 0)
                direction.y /= (Mathf.Abs(direction.y));


            _movingHandler.ApplyDirection(enemy, direction);
        }
    }
}
