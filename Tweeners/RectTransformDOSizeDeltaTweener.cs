using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.sizeDelta by Tweener. </summary>
    [RequireComponent(typeof(RectTransform))]
    [DisplayOption("RectTransform/RectTransform.sizeDelta")]
    public class RectTransformDOSizeDeltaTweener : TweenerBase<Vector2, RectTransform>
    {
        private RectTransform rectTransform;
        public override RectTransform Target => rectTransform ?? (rectTransform = transform.GetComponent<RectTransform>());

        public override Tweener Clone(RectTransform target)
        {
            var tweener = target.DOSizeDelta(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
