using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localRotation by Tweener. </summary>
    [DisplayOption("Transform/Transform.localRotation")]
    public class TransformDOLocalRotateProperty : TweenerAnimationPropertyBase<Vector3, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            return isFromTween ?
            target.DOLocalRotate(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOLocalRotate(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
