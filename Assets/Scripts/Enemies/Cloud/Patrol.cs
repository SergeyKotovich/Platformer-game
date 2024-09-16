using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Vector3 target;

    private void Start()
    {
        target = pointA.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == pointA.position)
            {
                target = pointB.position;
                _spriteRenderer.flipX = true;
            }
            else
            {
                target = pointA.position;
                _spriteRenderer.flipX = false;
            }
        }
    }
    
}