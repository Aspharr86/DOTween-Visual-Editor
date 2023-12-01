using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change CanvasGroup.alpha by Tweener. </summary>
    [RequireComponent(typeof(CanvasGroup))]
    [DisplayOption("CanvasGroup/CanvasGroup.alpha")]
    public class CanvasGroupDOFadeTweener : TweenerBase<float, CanvasGroup>
    {
        private CanvasGroup canvasGroup;
        public override CanvasGroup Target => canvasGroup ?? (canvasGroup = transform.GetComponent<CanvasGroup>());

        public override Tweener Clone(CanvasGroup target)
        {
            var tweener = target.DOFade(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
