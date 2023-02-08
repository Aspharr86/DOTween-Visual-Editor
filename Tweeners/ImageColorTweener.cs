using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [RequireComponent(typeof(Image))]
    [DisplayOption("Image/Image.color")]
    /// <summary> Change Image.color by Tweener. </summary>
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
            .SetEase(animationCurve)
            .SetLoops(-1, loopType)
            .SetAutoKill(false);
        }
    }
}
