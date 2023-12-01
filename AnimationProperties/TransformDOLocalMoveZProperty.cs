using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.z by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.z")]
    public class TransformDOLocalMoveZProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveZ(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
