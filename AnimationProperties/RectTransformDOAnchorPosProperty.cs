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
            return isFromTween ?
            target.DOAnchorPos(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOAnchorPos(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
