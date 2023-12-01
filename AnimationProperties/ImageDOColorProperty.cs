using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color by Tweener. </summary>
    [DisplayOption("Image/Image.color")]
    public class ImageDOColorProperty : TweenerAnimationPropertyBase<Color, Image>
    {
        public override Tweener Clone(Image target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
