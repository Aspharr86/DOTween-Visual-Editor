using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change CanvasGroup.alpha by Tweener. </summary>
    [DisplayOption("CanvasGroup/CanvasGroup.alpha")]
    public class CanvasGroupDOFadeProperty : TweenerAnimationPropertyBase<float, CanvasGroup>
    {
        public override Tweener Clone(CanvasGroup target)
        {
            return isFromTween ?
            target.DOFade(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOFade(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
