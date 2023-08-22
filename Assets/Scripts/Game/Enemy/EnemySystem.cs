using Game.Events;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Game
{
    internal sealed class EnemySystem : MonoBehaviour
    {
        [SerializeField] private EnemySpawner spawner;
        [SerializeField] private int enemiesCount = 3;
        [Inject] private EventBus _eventBus;


        private List<Enemy> _enemies = new List<Enemy>();

        internal void StartSystem()
        {
            SpawnRandomEnemy();
            _eventBus.Subscribe<DestroyEvent>(HandleDestroy);
        }

        private void HandleDestroy(DestroyEvent evnt)
        {
            Debug.Log("OnDestroy");
            if (evnt.Entity is Enemy enemy)
            {
                _enemies.Remove(enemy);
            }
        }

        internal void SpawnRandomEnemy()
        {
            if (_enemies.Count >= enemiesCount) return;

            var enemy = spawner.SpawnEnemy();
            enemy.SetEventBus(_eventBus);
            _enemies.Add(enemy);
        }

        internal IEnumerable<Enemy> GetActiveEnemies()
        {
            var result = new List<Enemy>();
            foreach (var en in _enemies)
            {
                if (en != null && en.gameObject != null)
                    result.Add(en);
            }

            return result;
        }
    }
}
