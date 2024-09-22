using System;
using Cysharp.Threading.Tasks;
using Events;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private TriggerHandler _triggerHandler;
        [SerializeField] private DamageEffectHandler  _damageHandler;
        private IDisposable _subscriptions;

        [Inject]
        public void Construct(ISubscriber<PlayerSteppedOnSpring> playerSteppedOnSpringSubscriber)
        {
         //   _movementController.Initialize(soundsManager);
            _triggerHandler.DamageTaken += OnHit;
            _subscriptions = playerSteppedOnSpringSubscriber.Subscribe(_ => StrongJump());
        }
        
        private void OnHit()
        {
            if (!_damageHandler.IsActive)
            {
                _damageHandler.OnDamageTaken().Forget();
            }
        }

        private void StrongJump()
        {
            _movementController.EnableSuperJump();
        }

        private void OnDestroy()
        {
            _triggerHandler.DamageTaken -= OnHit;
            _subscriptions.Dispose();
        }
    }
}