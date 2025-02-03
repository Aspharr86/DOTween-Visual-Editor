using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [DisplayOption("ScrollRect/DOVerticalNormalizedPos")]
    public class ScrollRectDOVerticalNormalizedPosTweener : TweenerBase<float, ScrollRect>
    {
        private ScrollRect scrollRect;
        public override ScrollRect SelfTarget => scrollRect ??= transform.GetComponent<ScrollRect>();

        public override Tweener Clone(ScrollRect target)
        {
            // To use FROM Tween
            var tweener = target.DOVerticalNormalizedPos(endValue, duration) as TweenerCore<float, float, FloatOptions>;
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
