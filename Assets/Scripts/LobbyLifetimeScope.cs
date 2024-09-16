using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LobbyLifetimeScope : LifetimeScope
{
    [SerializeField] private SoundsManager _soundsManager;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_soundsManager);
    }
    
}