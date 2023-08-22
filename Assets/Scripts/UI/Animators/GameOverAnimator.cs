using DG.Tweening;
using TMPro;
using UnityEngine;
using Yrr.UI.Animators;


namespace Game.UI
{
    internal sealed class GameOverAnimator : TweenAnimator
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI tmp;
        [SerializeField] private TextMeshProUGUI buttonTmp;


        protected override Sequence GetSequence()
        {
            ResetToDefault();

            DOTween.Kill(this);
            var seq = DOTween.Sequence(this).SetUpdate(true)
               .Append(DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, 1f, 0.5f))
               .Append(DOTween.To(() => tmp.color, x => tmp.color = x, Color.red, 0.5f))
               .Join(tmp.transform.DOScale(2, 7f))               
               .Join(DOTween.To(() => buttonTmp.color, x => buttonTmp.color = x, Color.white, 7f))
               ;

            return seq;
        }

        protected override void ResetToDefault()
        {
            canvasGroup.alpha = 0;
            tmp.color = new Color(1, 0, 0, 0);
            tmp.transform.localScale = Vector3.one;
            buttonTmp.color = new Color(0, 0, 0, 0);
        }
    }
}
