using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.normalizedPosition by Tweener. </summary>
    [DisplayOption("ScrollRect/ScrollRect.normalizedPosition")]
    public class ScrollRectDONormalizedPosProperty : TweenerAnimationPropertyBase<Vector2, ScrollRect>
    {
        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            return isFromTween ?
            (target.DONormalizedPos(endValue, duration) as TweenerCore<Vector2, Vector2, VectorOptions>)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            (target.DONormalizedPos(endValue, duration) as TweenerCore<Vector2, Vector2, VectorOptions>)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
