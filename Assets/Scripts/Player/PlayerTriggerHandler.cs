using System;
using UnityEngine;

namespace Player
{
    public class PlayerTriggerHandler : MonoBehaviour
    {
        public event Action OnLightningHitEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(GlobalConstants.LIGHTING))
            {
                Debug.Log("Lighting");
                OnLightningHitEvent?.Invoke();
            }
        }
    }
}