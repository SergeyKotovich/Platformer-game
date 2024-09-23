using Events;
using MessagePipe;
using Player;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform _targetPortal;
    [SerializeField] private float _teleportOffset = 0.5f;
    private IPublisher<PlayerTeleported> _playerTeleportedPublisher;

    public void Initialize(IPublisher<PlayerTeleported> playerTeleportedPublisher)
    {
        _playerTeleportedPublisher = playerTeleportedPublisher;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GlobalConstants.PLAYER))
        {
            var playerTeleportStatus = other.GetComponent<ITeleport>();

            if (playerTeleportStatus is { CanBeTeleported: true })
            {
                Teleport(other);
            }
        }
    }

    private void Teleport(Collider2D playerCollider)
    {
        _playerTeleportedPublisher.Publish(new PlayerTeleported());

        var offsetPosition = _targetPortal.position + Vector3.up * _teleportOffset;
        playerCollider.transform.position = offsetPosition;
    }
}