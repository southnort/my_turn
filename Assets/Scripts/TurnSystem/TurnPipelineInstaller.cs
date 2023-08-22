using Game.DI;
using VContainer;
using VContainer.Unity;

namespace Game.Turn
{
    internal sealed class TurnPipelineInstaller : IInitializable
    {
        private readonly TurnPipeline _pipeline;
        private readonly IObjectResolver _objectResolver;


        public TurnPipelineInstaller(TurnPipeline pipeline, IObjectResolver resolver)
        {
            _pipeline = pipeline;
            _objectResolver = resolver;
        }

        void IInitializable.Initialize()
        {
            _pipeline.AddTask(new StartTurnTask());
            _pipeline.AddTask(_objectResolver.CreateInstance<PlayerTurnTask>());
            _pipeline.AddTask(_objectResolver.CreateInstance<EnemySystemTask>());
            _pipeline.AddTask(_objectResolver.CreateInstance<EnemiesControllerTurnTask>());
            _pipeline.AddTask(new FinishTurnTask());
        }
    }
}
