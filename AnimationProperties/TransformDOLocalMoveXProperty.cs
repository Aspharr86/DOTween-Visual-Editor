using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.x by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.x")]
    public class TransformDOLocalMoveXProperty : TweenerAnimationPropertyBase<float, Transform>
    {
        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveX(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
