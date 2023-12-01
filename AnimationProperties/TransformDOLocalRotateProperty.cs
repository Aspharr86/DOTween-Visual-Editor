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
            var tweener = target.DOLocalRotate(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
