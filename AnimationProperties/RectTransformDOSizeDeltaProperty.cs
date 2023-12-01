using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.sizeDelta by Tweener. </summary>
    [DisplayOption("RectTransform/RectTransform.sizeDelta")]
    public class RectTransformDOSizeDeltaProperty : TweenerAnimationPropertyBase<Vector2, RectTransform>
    {
        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOSizeDelta(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
