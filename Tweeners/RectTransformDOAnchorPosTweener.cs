using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.anchoredPosition by Tweener. </summary>
    [RequireComponent(typeof(RectTransform))]
    [DisplayOption("RectTransform/RectTransform.anchoredPosition")]
    public class RectTransformDOAnchorPosTweener : TweenerBase<Vector2, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform Target => rectTransform ?? (rectTransform = transform.GetComponent<RectTransform>());

        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOAnchorPos(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
