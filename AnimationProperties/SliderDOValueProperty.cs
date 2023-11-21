using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Slider.value by Tweener. </summary>
    [DisplayOption("Slider/Slider.value")]
    public class SliderDOValueProperty : TweenerAnimationPropertyBase<float, Slider>
    {
        public override Tweener Clone(Slider target)
        {
            return isFromTween ?
            target.DOValue(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOValue(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
