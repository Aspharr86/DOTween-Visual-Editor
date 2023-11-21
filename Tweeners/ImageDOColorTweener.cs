using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color by Tweener. </summary>
    [RequireComponent(typeof(Image))]
    [DisplayOption("Image/Image.color")]
    public class ImageDOColorTweener : TweenerBase<Color, Image>
    {
        private Image image;
        public override Image Target => image ?? (image = transform.GetComponent<Image>());

        public override Tweener Clone(Image target)
        {
            return target.DOColor(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
