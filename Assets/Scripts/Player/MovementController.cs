using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController2D _characterController;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private SoundsManager _soundsManager;

        private bool _isJumping;
        private float _horizontalMove;
        private float _speed;
        private float _massForSuperJump;
        private float _standardMass;
        private int _delayAfterSuperJump;

        public void Initialize(PlayerConfigs playerConfigs)
        {
            _speed = playerConfigs.Speed;
            _massForSuperJump = playerConfigs.MassForSuperJump;
            _standardMass = playerConfigs.StandardMass;
            _delayAfterSuperJump = playerConfigs.DelayAfterSuperJump;
        }

        private void Update()
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
                _animationController.ShowJump();
            }
        }

        private void FixedUpdate()
        {
            _characterController.Move(_horizontalMove * Time.fixedDeltaTime, false, _isJumping);
            _animationController.ShowWalk(_horizontalMove != 0);

            _isJumping = false;
        }

        public void EnableSuperJump()
        {
            _isJumping = true;
            _rigidbody2D.mass = _massForSuperJump;
            DisableSuperJump().Forget();
        }

        private async UniTask DisableSuperJump()
        {
            await UniTask.Delay(_delayAfterSuperJump);
            _rigidbody2D.mass = _standardMass;
            _isJumping = false;
        }
    }
}