using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController2D _characterController;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private AnimatorController _animatorController;

        private bool _isJumping;
        private float _horizontalMove;
        private SoundsManager _soundsManager;

        private void Update()
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isJumping = true;
              //  _soundsManager.PlaySoundJump();
            }
        }

        private void FixedUpdate()
        {
            _characterController.Move(_horizontalMove * Time.fixedDeltaTime, false, _isJumping);
            _animatorController.ShowWalk(_horizontalMove != 0);
            
            _isJumping = false;
        }

        public void Initialize(SoundsManager soundsManager)
        {
            _soundsManager = soundsManager;
        }
    }
}
