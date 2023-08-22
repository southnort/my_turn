using UnityEngine;


namespace Game.Turn
{
    internal sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Finish");
            Finish();
        }
    }
}
