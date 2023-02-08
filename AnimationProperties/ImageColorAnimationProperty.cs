using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color by Tweener. </summary>
    [DisplayOption("Image/Image.color")]
    public class ImageColorAnimationProperty : TweenerAnimationPropertyBase<Color>
    {
        private Image image;

        public override void GetTweenedComponent()
        {
            image = tweenedGameObject.transform.GetComponent<Image>();
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => image.color, x => image.color = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => image.color, x => image.color = x, endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
