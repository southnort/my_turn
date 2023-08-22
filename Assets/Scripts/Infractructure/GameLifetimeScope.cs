using Game;
using Game.Events;
using Game.Turn;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yrr.UI;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private UIManager uiManager;

    protected override void Configure(IContainerBuilder builder)
    {
        RegisterServices(builder);
        ConfigureTurn(builder);
    }

    private void RegisterServices(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameGrid>();
        builder.RegisterComponent(uiManager);
        builder.Register<EventBus>(Lifetime.Singleton);
        builder.Register<ApplyDirectionHandler>(Lifetime.Singleton);
        builder.Register<ExplosionHandler>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<PlayerProvider>();
        builder.RegisterComponentInHierarchy<KeyboardInput>();
        builder.RegisterComponentInHierarchy<EnemySystem>();
        builder.RegisterComponentInHierarchy<EnemiesController>();
        builder.RegisterComponentInHierarchy<TurnStartedObserver>();
        builder.RegisterEntryPoint<PlayerDieObserver>();
        builder.RegisterComponentInHierarchy<BarrelsSpawner>();
    }

    private void ConfigureTurn(IContainerBuilder builder)
    {
        builder.Register<TurnPipeline>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<TurnRunner>();
        builder.RegisterEntryPoint<TurnPipelineInstaller>();
    }
}
