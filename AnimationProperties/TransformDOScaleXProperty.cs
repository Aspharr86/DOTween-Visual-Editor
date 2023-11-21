using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale.x by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale.x")]
    public class TransformDOScaleXProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            return isFromTween ?
            target.DOScaleX(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOScaleX(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
