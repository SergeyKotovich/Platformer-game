using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Create PlayerConfigs", fileName = "PlayerConfigs", order = 0)]
    public class PlayerConfigs : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float MassForSuperJump { get; private set; }
        [field: SerializeField] public float StandardMass { get; private set; }
        [field: SerializeField] public int DelayAfterSuperJump { get; private set; }
        [field: SerializeField] public int DelayAfterTeleport { get; private set; }
    }
}