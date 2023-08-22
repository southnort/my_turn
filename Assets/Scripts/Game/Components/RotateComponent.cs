using System;
using UnityEngine;
using DG.Tweening;


namespace Game
{
    [Serializable]
    internal sealed class RotateComponent
    {
        private Transform _transform;

        public RotateComponent(Transform transform)
        {
            _transform = transform;
        }


        internal void RotateTo(Vector2Int targetRotation, Action callback = null)
        {
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(_transform.DORotate(targetRotation.ToDirectionVector(), 0.3f))
                .AppendCallback(() => callback.Invoke());
        }
    }
}
