using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition.y by Tweener. </summary>
    [DisplayOption("RectTransform/RectTransform.anchoredPosition.y")]
    public class RectTransformDOAnchorPosYProperty : TweenerAnimationPropertyBase<float, RectTransform>
    {
        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPosY(endValue, duration);
            if (isFromTween) tweener.From(new Vector2(target.anchoredPosition.x, fromValue));
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
