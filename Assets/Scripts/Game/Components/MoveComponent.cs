using System;
using UnityEngine;
using DG.Tweening;

namespace Game
{
    [Serializable]
    internal sealed class MoveComponent
    {
        private Transform _transform;

        public MoveComponent(Transform transform)
        {
            _transform = transform;
        }

        internal void MoveTo(Vector3 desto, Action callback = null)
        {
            var middlePos = (desto - _transform.position) / 2;
            middlePos.y += 1;

            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(_transform.DOMove(_transform.position + middlePos, 0.2f))
                .Append(_transform.DOMove(desto, 0.2f))
                .OnComplete(() => callback.Invoke());
        }
    }
}
