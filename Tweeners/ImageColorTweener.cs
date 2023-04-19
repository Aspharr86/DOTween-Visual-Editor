using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color by Tweener. </summary>
    [RequireComponent(typeof(Image))]
    [DisplayOption("Image/Image.color")]
    public class ImageColorTweener : TweenerBase<Color>
    {
        private Image image;

        private protected override void Awake()
        {
            image = GetComponent<Image>();
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => image.color, x => image.color = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
