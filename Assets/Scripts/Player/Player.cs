using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private PlayerTriggerHandler _triggerHandler;
        [SerializeField] private ElectricShockEffect _electricShockEffect;

        [Inject]
        public void Construct(SoundsManager soundsManager)
        {
         //   _movementController.Initialize(soundsManager);
          //  _triggerHandler.OnLightningHitEvent += OnLightningHit;
        }

        private void Awake()
        {
            _triggerHandler.OnLightningHitEvent += OnLightningHit;
        }

        private void OnLightningHit()
        {
            Debug.Log("OnLightningHit");
            _electricShockEffect.StartFlashEffect().Forget();
        }

        private void OnDestroy()
        {
            _triggerHandler.OnLightningHitEvent -= OnLightningHit;
        }
    }
}