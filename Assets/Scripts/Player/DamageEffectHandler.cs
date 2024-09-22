using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class DamageEffectHandler : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _duration = 0.1f;
        [SerializeField] private int _flashCount = 10;
        [SerializeField] private float _power = 2000;
        public bool IsActive { get; private set; }

        public async UniTask OnDamageTaken()
        {
            IsActive = true;
            
            ApplyKnockback();
            
            await PlayFlashEffect();

            IsActive = false;
        }
        
        private void ApplyKnockback()
        {
            var direction = Random.Range(0, 2) == 0 ? -1f : 1f;
            _rigidbody2D.AddForce(Vector2.right * direction * _power);
        }
        
        private async UniTask PlayFlashEffect()
        {
            for (int i = 0; i < _flashCount; i++)
            {
                await _spriteRenderer.DOColor(Color.black, _duration).AsyncWaitForCompletion();
                await _spriteRenderer.DOColor(Color.yellow, _duration).AsyncWaitForCompletion();
            }

            await _spriteRenderer.DOColor(Color.white, _duration).AsyncWaitForCompletion();
        }
    }

}