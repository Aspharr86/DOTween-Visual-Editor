using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale.z by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale.z")]
    public class TransformDOScaleZTweener : TweenerBase<float, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleZ(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
