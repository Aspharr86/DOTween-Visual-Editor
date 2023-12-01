using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale")]
    public class TransformDOScaleTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScale(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
