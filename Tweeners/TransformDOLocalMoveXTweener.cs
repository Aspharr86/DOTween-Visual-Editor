using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.x by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.x")]
    public class TransformDOLocalMoveXTweener : TweenerBase<float, Transform>
    {
        public override Transform Target => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveX(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
