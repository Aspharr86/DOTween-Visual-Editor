using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale.z by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale.z")]
    public class TransformDOScaleZProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleZ(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
