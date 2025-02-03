using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("RectTransform/DOAnchorPosX")]
    public class RectTransformDOAnchorPosXTweener : TweenerBase<float, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform SelfTarget => rectTransform ??= transform.GetComponent<RectTransform>();

        [SerializeField] private bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPosX(endValue, duration, snapping);
            // For consistency
            if (TweenType == TweenType.FROM) tweener.From(new Vector2(fromValue, target.anchoredPosition.y));
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
