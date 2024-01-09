using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.rotation by Tweener. </summary>
    [DisplayOption("Transform/Transform.rotation")]
    public class TransformDORotateTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DORotate(endValue, duration, RotateMode.FastBeyond360);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
