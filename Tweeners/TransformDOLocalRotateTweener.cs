using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localRotation by Tweener. </summary>
    [DisplayOption("Transform/Transform.localRotation")]
    public class TransformDOLocalRotateTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            return target.DOLocalRotate(endValue, duration, RotateMode.FastBeyond360)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
