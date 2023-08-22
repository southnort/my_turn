using System.Linq;
using UnityEngine;


namespace Game.Turn
{
    internal sealed class EnemiesControllerTurnTask : Task
    {
        private readonly EnemySystem _enemySystem;
        private readonly EnemiesController _enemiesController;

        public EnemiesControllerTurnTask(EnemySystem enemySystem, EnemiesController enemiesController)
        {
            _enemySystem = enemySystem;
            _enemiesController = enemiesController;
        }

        protected override void OnRun()
        {
            _enemiesController.HandleEnemies(_enemySystem.GetActiveEnemies(), Finish);
        }
    }
}
