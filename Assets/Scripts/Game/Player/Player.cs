using UnityEngine;

namespace Game
{
    internal sealed class Player : EntityBase
    {
        [SerializeField] private Gun shooting;

        protected override void Initialize()
        {
            base.Initialize();
            Add(shooting);
        }
    }
}
