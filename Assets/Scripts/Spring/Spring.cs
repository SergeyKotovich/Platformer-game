using Events;
using JetBrains.Annotations;
using MessagePipe;
using Player;
using UnityEngine;
using VContainer;

public class Spring : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private static readonly int _springActivated = Animator.StringToHash("springActivated");
    private IPublisher<PlayerSteppedOnSpring> _playerSteppedOnSpringPublisher;

    public void Initialize(IPublisher<PlayerSteppedOnSpring> playerSteppedOnSpringPublisher)
    {
        _playerSteppedOnSpringPublisher = playerSteppedOnSpringPublisher;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(GlobalConstants.PLAYER))
        {
            _animator.SetTrigger(_springActivated);
        }
    }
    
    [UsedImplicitly]
    private void EnableSuperJump()
    {
        _playerSteppedOnSpringPublisher.Publish(new PlayerSteppedOnSpring());
    }
}