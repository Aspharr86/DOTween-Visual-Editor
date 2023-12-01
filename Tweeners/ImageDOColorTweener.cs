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
            var tweener = target.DOColor(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
