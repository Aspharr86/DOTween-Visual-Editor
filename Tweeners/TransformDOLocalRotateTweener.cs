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
            var tweener = target.DOLocalRotate(endValue, duration, RotateMode.FastBeyond360);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
