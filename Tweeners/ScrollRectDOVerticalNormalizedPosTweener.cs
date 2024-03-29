using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.verticalNormalizedPosition by Tweener. </summary>
    [RequireComponent(typeof(ScrollRect))]
    [DisplayOption("ScrollRect/ScrollRect.verticalNormalizedPosition")]
    public class ScrollRectDOVerticalNormalizedPosTweener : TweenerBase<float, ScrollRect>
    {
        private ScrollRect scrollRect;
        public override ScrollRect Target => scrollRect ?? (scrollRect = transform.GetComponent<ScrollRect>());

        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            var tweener = target.DOVerticalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>;
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
