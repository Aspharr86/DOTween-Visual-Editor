using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOMoveZ")]
    public class TransformDOMoveZTweener : TweenerBase<float, Transform>
    {
        public override Transform SelfTarget => transform;

        [SerializeField] private bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOMoveZ(endValue, duration, snapping);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
