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
            var tweener = target.DOLocalMove(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
