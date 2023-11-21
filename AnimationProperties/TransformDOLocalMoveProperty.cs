using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition")]
    public class TransformDOLocalMoveProperty : TweenerAnimationPropertyBase<Vector3, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            return isFromTween ?
            target.DOLocalMove(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOLocalMove(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
