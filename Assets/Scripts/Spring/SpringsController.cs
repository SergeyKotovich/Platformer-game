using System.Collections.Generic;
using Events;
using MessagePipe;
using UnityEngine;
using VContainer;

public class SpringsController : MonoBehaviour
{
    [SerializeField] private List<Spring> _listSprings;

    [Inject]
    public void Construct(IPublisher<PlayerSteppedOnSpring> playerSteppedOnSpringPublisher)
    {
        foreach (var listSpring in _listSprings)
        {
            listSpring.Initialize(playerSteppedOnSpringPublisher);
        }
    }
}