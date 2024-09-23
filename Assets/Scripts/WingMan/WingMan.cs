using UnityEngine;
using UnityEngine.AI;
using VContainer;

public class WingMan : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Bounds _followArea; 
    private Player.Player _player;

    [Inject]
    public void Construct(Player.Player player)
    {
        _player = player;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        if (_followArea.Contains(_player.transform.position))
        {
            var target = _player.transform.position;
            target.y += 2f; 
            _navMeshAgent.destination = target;
        }
        else
        {
            _navMeshAgent.ResetPath();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_followArea.center, _followArea.size);
    }
}
