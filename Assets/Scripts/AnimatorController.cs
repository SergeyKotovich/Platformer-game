using UnityEngine;

namespace Player
{
    public class AnimatorController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private static readonly int _walk = Animator.StringToHash("walk");

        public void ShowWalk(bool walk)
        {
            _animator.SetBool(_walk, walk);
        }
    }
}