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
            return isFromTween ?
            target.DOAnchorPosY(endValue, duration)
            .From(new Vector2(target.anchoredPosition.x, fromValue))
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOAnchorPosY(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
