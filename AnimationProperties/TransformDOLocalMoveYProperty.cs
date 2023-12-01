using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.y by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.y")]
    public class TransformDOLocalMoveYProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveY(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
