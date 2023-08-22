using UnityEngine;
using VContainer;

namespace Game.Turn
{
    internal sealed class TurnRunner : MonoBehaviour
    {
        private TurnPipeline _pipeline;

        [Inject]
        private void Construct(TurnPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        private void OnEnable()
        {
            _pipeline.Finished += OnTurnPipelineFinished;
        }

        private void OnDisable()
        {
            _pipeline.Finished -= OnTurnPipelineFinished;
        }

        public void Run()
        {
            _pipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            Run();
        }
    }
}
