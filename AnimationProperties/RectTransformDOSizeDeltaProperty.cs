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
            return isFromTween ?
            target.DOSizeDelta(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOSizeDelta(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
