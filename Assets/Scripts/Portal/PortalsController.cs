using System.Collections.Generic;
using Events;
using MessagePipe;
using UnityEngine;
using VContainer;

public class PortalsController : MonoBehaviour
{
    [SerializeField] private List<Portal> _listPortals;

    [Inject]
    public void Construct(IPublisher<PlayerTeleported> playerTeleportedPublisher)
    {
        foreach (var listPortal in _listPortals)
        {
            listPortal.Initialize(playerTeleportedPublisher);
        }
    }
}