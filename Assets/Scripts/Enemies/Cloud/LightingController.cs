using DG.Tweening;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    [SerializeField] private Transform _cloudTransform; 
    [SerializeField] private Vector2 _endYPosition ; 
    [SerializeField] private float _moveDuration = 0.2f; 
    [SerializeField] private float _delayBeforeReset = 0.5f; 
    private void Awake()
    {
        StartLightningCycle();
        gameObject.SetActive(true); 
    }

    private void StartLightningCycle()
    {
        transform.position = _cloudTransform.position;
        
        transform.DOLocalMove(_endYPosition, _moveDuration)
            .OnComplete(() => 
            {
                gameObject.SetActive(false);
                
                DOVirtual.DelayedCall(_delayBeforeReset, () =>
                {
                    transform.position = _cloudTransform.position;
                    
                    gameObject.SetActive(true);
                    
                    StartLightningCycle();
                });
            });
    }
}