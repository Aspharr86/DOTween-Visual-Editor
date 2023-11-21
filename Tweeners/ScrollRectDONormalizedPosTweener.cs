using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace DOTweenUtilities
{
    /// <summary> Change ScrollRect.normalizedPosition by Tweener. </summary>
    [RequireComponent(typeof(ScrollRect))]
    [DisplayOption("ScrollRect/ScrollRect.normalizedPosition")]
    public class ScrollRectDONormalizedPosTweener : TweenerBase<Vector2, ScrollRect>
    {
        private ScrollRect scrollRect;
        public override ScrollRect Target => scrollRect ?? (scrollRect = transform.GetComponent<ScrollRect>());

        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            return (target.DONormalizedPos(endValue, duration) as TweenerCore<Vector2, Vector2, VectorOptions>)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
