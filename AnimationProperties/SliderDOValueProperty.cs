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
            var tweener = target.DOValue(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
