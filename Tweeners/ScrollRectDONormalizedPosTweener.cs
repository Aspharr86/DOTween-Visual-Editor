using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [DisplayOption("ScrollRect/DONormalizedPos")]
    public class ScrollRectDONormalizedPosTweener : TweenerBase<Vector2, ScrollRect>
    {
        private ScrollRect scrollRect;
        public override ScrollRect SelfTarget => scrollRect ??= transform.GetComponent<ScrollRect>();

        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            var tweener = target.DONormalizedPos(endValue, duration) as TweenerCore<Vector2, Vector2, VectorOptions>;
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
