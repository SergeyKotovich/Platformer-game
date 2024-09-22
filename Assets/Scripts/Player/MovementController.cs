using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController2D _characterController;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private bool _isJumping;
        private float _horizontalMove;
        private SoundsManager _soundsManager;
        private const float _massForSuperJump = 0.7f;
        private const float _standardMass = 1f;
        private const int _delay = 500;

        private void Update()
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
                _animationController.ShowJump();
              //  _soundsManager.PlaySoundJump();
            }
        }

        public void EnableSuperJump()
        {
            _isJumping = true;
            _rigidbody2D.mass = _massForSuperJump;
            DisableSuperJump().Forget();
        }

        private async UniTask DisableSuperJump()
        {
            await UniTask.Delay(_delay);
            _rigidbody2D.mass = _standardMass;
            _isJumping = false;
        }

        private void FixedUpdate()
        {
            _characterController.Move(_horizontalMove * Time.fixedDeltaTime, false, _isJumping);
            _animationController.ShowWalk(_horizontalMove != 0);
            
            _isJumping = false;
        }

        public void Initialize(SoundsManager soundsManager)
        {
            _soundsManager = soundsManager;
        }
    }
}
