using UnityEngine;

namespace Game.Turn
{
    internal sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Start");
            Finish();
        }
    }
}
