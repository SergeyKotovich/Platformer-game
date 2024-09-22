using System;
using UnityEngine;

namespace Player
{
    public class TriggerHandler : MonoBehaviour
    {
        public event Action DamageTaken;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(GlobalConstants.LIGHTING) || other.CompareTag(GlobalConstants.ANGRYBALL))
            {
                DamageTaken?.Invoke();
            }
        }
    }
}