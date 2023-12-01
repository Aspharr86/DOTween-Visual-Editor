using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change CanvasGroup.alpha by Tweener. </summary>
    [DisplayOption("CanvasGroup/CanvasGroup.alpha")]
    public class CanvasGroupDOFadeProperty : TweenerAnimationPropertyBase<float, CanvasGroup>
    {
        public override Tweener Clone(CanvasGroup target)
        {
            var tweener = target.DOFade(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
