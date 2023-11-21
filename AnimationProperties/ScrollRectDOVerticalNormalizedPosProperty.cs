using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.verticalNormalizedPosition by Tweener. </summary>
    [DisplayOption("ScrollRect/ScrollRect.verticalNormalizedPosition")]
    public class ScrollRectDOVerticalNormalizedPosProperty : TweenerAnimationPropertyBase<float, ScrollRect>
    {
        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            return isFromTween ?
            (target.DOVerticalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            (target.DOVerticalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
