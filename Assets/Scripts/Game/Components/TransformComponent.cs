using UnityEngine;


namespace Game
{
    internal class TransformComponent
    {
        public Transform Transform { get; }

        public TransformComponent(Transform transform)
        {
            Transform = transform;
        }
    }
}
