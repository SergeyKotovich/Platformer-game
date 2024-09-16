using DG.Tweening;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform _cloudTransform; 
    [SerializeField] private Vector2 _endYPosition ; 
    [SerializeField] private float _moveDuration = 0.2f; 
    [SerializeField] private float _delayBeforeReset = 0.5f; 
    private void Awake()
    {
        StartLightningCycle();
        _spriteRenderer.enabled = true;
    }

    private void StartLightningCycle()
    {
        transform.position = _cloudTransform.position;
        
        transform.DOLocalMove(_endYPosition, _moveDuration)
            .OnComplete(() => 
            {
                _spriteRenderer.enabled = false;
                
                DOVirtual.DelayedCall(_delayBeforeReset, () =>
                {
                    transform.position = _cloudTransform.position;
                    
                    _spriteRenderer.enabled = true;
                    
                    StartLightningCycle();
                });
            });
    }
}