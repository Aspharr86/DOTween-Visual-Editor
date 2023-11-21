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
            return isFromTween ?
            target.DOAnchorPosX(endValue, duration)
            .From(new Vector2(fromValue, target.anchoredPosition.y))
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOAnchorPosX(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
