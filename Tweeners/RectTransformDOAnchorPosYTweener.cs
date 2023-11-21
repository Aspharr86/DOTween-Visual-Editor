using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition.y by Tweener. </summary>
    [RequireComponent(typeof(RectTransform))]
    [DisplayOption("RectTransform/RectTransform.anchoredPosition.y")]
    public class RectTransformDOAnchorPosYTweener : TweenerBase<float, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform Target => rectTransform ?? (rectTransform = transform.GetComponent<RectTransform>());

        public override Tweener Clone(RectTransform target)
        {
            return target.DOAnchorPosY(endValue, duration)
            .From(new Vector2(rectTransform.anchoredPosition.x, fromValue))
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
