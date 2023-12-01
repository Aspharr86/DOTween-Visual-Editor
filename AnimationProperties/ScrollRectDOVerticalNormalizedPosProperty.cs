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
            var tweener = target.DOVerticalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>;
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
