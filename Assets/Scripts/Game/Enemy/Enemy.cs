using UnityEngine;

namespace Game
{
    internal sealed class Enemy : EntityBase
    {
        [SerializeField] private MeleeAttackComponent attackComponent;

        protected override void Initialize()
        {
            base.Initialize();
            Add(attackComponent);
        }
    }
}
