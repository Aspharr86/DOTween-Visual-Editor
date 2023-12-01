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
            var tweener = target.DOScaleX(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
