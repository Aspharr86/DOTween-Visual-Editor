using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("RectTransform/DOAnchorPos")]
    public class RectTransformDOAnchorPosTweener : TweenerBase<Vector2, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform SelfTarget => rectTransform ??= transform.GetComponent<RectTransform>();

        [SerializeField] private bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPos(endValue, duration, snapping);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
