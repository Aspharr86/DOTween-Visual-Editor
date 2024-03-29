using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.horizontalNormalizedPosition by Tweener. </summary>
    [RequireComponent(typeof(ScrollRect))]
    [DisplayOption("ScrollRect/ScrollRect.horizontalNormalizedPosition")]
    public class ScrollRectDOHorizontalNormalizedPosTweener : TweenerBase<float, ScrollRect>
    {
        private ScrollRect scrollRect;
        public override ScrollRect Target => scrollRect ?? (scrollRect = transform.GetComponent<ScrollRect>());

        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            var tweener = target.DOHorizontalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>;
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
