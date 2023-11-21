using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale.x by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale.x")]
    public class TransformDOScaleXTweener : TweenerBase<float, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            return target.DOScaleX(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
