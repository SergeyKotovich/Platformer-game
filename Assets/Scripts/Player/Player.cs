using System;
using Cysharp.Threading.Tasks;
using Events;
using MessagePipe;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Player : MonoBehaviour, ITeleport
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private TriggerHandler _triggerHandler;
        [SerializeField] private DamageEffectHandler _damageHandler;

        private int _delayAfterTeleport;
        private IDisposable _subscriptions;

        public bool CanBeTeleported { get; private set; } = true;

        [Inject]
        public void Construct(ISubscriber<PlayerSteppedOnSpring> playerSteppedOnSpringSubscriber,
            ISubscriber<PlayerTeleported> playerTeleportedSubscriber, PlayerConfigs playerConfigs)
        {
            _movementController.Initialize(playerConfigs);
            _delayAfterTeleport = playerConfigs.DelayAfterTeleport;
            _triggerHandler.DamageTaken += OnHit;
            _subscriptions = DisposableBag.Create(playerSteppedOnSpringSubscriber.Subscribe(_ => StrongJump()),
                playerTeleportedSubscriber.Subscribe(_ => ResetTeleportCooldown().Forget()));
        }

        private async UniTask ResetTeleportCooldown()
        {
            CanBeTeleported = false;

            await UniTask.Delay(_delayAfterTeleport);
            CanBeTeleported = true;
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