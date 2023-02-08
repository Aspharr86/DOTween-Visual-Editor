using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change RectTransform.sizeDelta by Tweener. </summary>
    [DisplayOption("RectTransform/RectTransform.sizeDelta")]
    public class RectTransformSizeDeltaAnimationProperty : TweenerAnimationPropertyBase<Vector2>
    {
        private RectTransform rectTransform;

        public override void GetTweenedComponent()
        {
            rectTransform = tweenedGameObject.transform.GetComponent<RectTransform>();
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
