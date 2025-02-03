using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOLocalMoveZ")]
    public class TransformDOLocalMoveZTweener : TweenerBase<float, Transform>
    {
        public override Transform SelfTarget => transform;

        [SerializeField] private bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMoveZ(endValue, duration, snapping);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
