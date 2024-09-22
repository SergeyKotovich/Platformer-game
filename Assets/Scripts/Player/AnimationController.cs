using UnityEngine;

namespace Player
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int _walk = Animator.StringToHash("walk");
        private static readonly int _jump = Animator.StringToHash("jump");


        public void ShowWalk(bool walk)
        {
            _animator.SetBool(_walk, walk);
        }

        public void ShowJump()
        {
            _animator.SetTrigger(_jump);
        }
    }
}