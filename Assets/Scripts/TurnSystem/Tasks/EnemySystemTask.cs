namespace Game.Turn
{
    internal sealed class EnemySystemTask : Task
    {
        private readonly EnemySystem _enemySystem;

        public EnemySystemTask(EnemySystem system)
        {
            _enemySystem = system;
        }

        protected override void OnRun()
        {
            _enemySystem.SpawnRandomEnemy();
            Finish();
        }
    }
}
