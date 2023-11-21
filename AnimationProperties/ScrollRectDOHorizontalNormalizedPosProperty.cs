using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.horizontalNormalizedPosition by Tweener. </summary>
    [DisplayOption("ScrollRect/ScrollRect.horizontalNormalizedPosition")]
    public class ScrollRectDOHorizontalNormalizedPosProperty : TweenerAnimationPropertyBase<float, ScrollRect>
    {
        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            return isFromTween ?
            (target.DOHorizontalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            (target.DOHorizontalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
