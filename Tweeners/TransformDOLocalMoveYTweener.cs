using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.y by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.y")]
    public class TransformDOLocalMoveYTweener : TweenerBase<float, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveY(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
