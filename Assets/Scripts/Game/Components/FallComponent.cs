using DG.Tweening;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class FallComponent
    {
        private Transform _transform;

        public FallComponent(Transform transform)
        {
            _transform = transform;
        }

        internal void FallTo(Vector3 desto, Action callback = null)
        {
            var middlePos = (desto - _transform.position) / 2;
            middlePos.y += 1;

            DOTween.Kill(this);
            var seq = DOTween.Sequence(this).SetUpdate(true)
                .Append(_transform.DOMove(_transform.position + middlePos, 0.5f))
                .Append(_transform.DOMove(desto + Vector3.down, 0.1f))
                .Append(_transform.DOMove(desto + Vector3.down * 50f, 4.5f));


            if (callback != null)
                seq.AppendCallback(callback.Invoke);
        }
    }
}
