using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale.y by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale.y")]
    public class TransformDOScaleYProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleY(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
