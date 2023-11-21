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
            return target.DOFade(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
