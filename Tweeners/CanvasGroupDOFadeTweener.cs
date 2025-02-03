using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("CanvasGroup/DOFade")]
    public class CanvasGroupDOFadeTweener : TweenerBase<float, CanvasGroup>
    {
        private CanvasGroup canvasGroup;
        public override CanvasGroup SelfTarget => canvasGroup ??= transform.GetComponent<CanvasGroup>();

        public override Tweener Clone(CanvasGroup target)
        {
            var tweener = target.DOFade(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
