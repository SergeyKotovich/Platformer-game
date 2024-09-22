using Events;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Player.Player _player;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_player).AsSelf().AsImplementedInterfaces();

        RegisterMessagePipe(builder);
    }

    private void RegisterMessagePipe(IContainerBuilder builder)
    {
        var options = builder.RegisterMessagePipe();

        builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        
        builder.RegisterMessageBroker<PlayerSteppedOnSpring>(options);
    }
}