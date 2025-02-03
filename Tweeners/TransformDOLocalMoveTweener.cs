using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOLocalMove")]
    public class TransformDOLocalMoveTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform SelfTarget => transform;

        [SerializeField] private bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalMove(endValue, duration, snapping);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
