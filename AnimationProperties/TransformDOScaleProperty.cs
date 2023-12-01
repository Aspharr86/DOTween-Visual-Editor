using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale")]
    public class TransformDOScaleProperty : TweenerAnimationPropertyBase<Vector3, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScale(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
