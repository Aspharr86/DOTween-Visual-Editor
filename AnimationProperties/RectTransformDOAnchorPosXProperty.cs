using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition.x by Tweener. </summary>
    [DisplayOption("RectTransform/RectTransform.anchoredPosition.x")]
    public class RectTransformDOAnchorPosXProperty : TweenerAnimationPropertyBase<float, RectTransform>
    {
        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPosX(endValue, duration);
            if (isFromTween) tweener.From(new Vector2(fromValue, target.anchoredPosition.y));
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
