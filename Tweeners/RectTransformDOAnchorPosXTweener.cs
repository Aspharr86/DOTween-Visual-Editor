using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition.x by Tweener. </summary>
    [RequireComponent(typeof(RectTransform))]
    [DisplayOption("RectTransform/RectTransform.anchoredPosition.x")]
    public class RectTransformDOAnchorPosXTweener : TweenerBase<float, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform Target => rectTransform ?? (rectTransform = transform.GetComponent<RectTransform>());

        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPosX(endValue, duration);
            tweener.From(new Vector2(fromValue, rectTransform.anchoredPosition.y));
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
