using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [RequireComponent(typeof(RectTransform))]
    [DisplayOption("RectTransform/RectTransform.sizeDelta")]
    /// <summary> Change RectTransform.sizeDelta by Tweener. </summary>
    public class RectTransformSizeDeltaTweener : TweenerBase<Vector2>
    {
        private RectTransform rectTransform;

        private protected override void Awake()
        {
            rectTransform = transform.GetComponent<RectTransform>();
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, endValue, duration)
            .From(fromValue)
            .SetEase(animationCurve)
            .SetLoops(-1, loopType)
            .SetAutoKill(false);
        }
    }
}
