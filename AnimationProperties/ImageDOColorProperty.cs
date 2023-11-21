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
            return isFromTween ?
            target.DOColor(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOColor(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
