using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition by Tweener. </summary>
    [DisplayOption("RectTransform/RectTransform.anchoredPosition")]
    public class RectTransformDOAnchorPosProperty : TweenerAnimationPropertyBase<Vector2, RectTransform>
    {
        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPos(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
