using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Slider.value by Tweener. </summary>
    [RequireComponent(typeof(Slider))]
    [DisplayOption("Slider/Slider.value")]
    public class SliderDOValueTweener : TweenerBase<float, Slider>
    {
        private Slider slider;
        public override Slider Target => slider ?? (slider = transform.GetComponent<Slider>());

        public override Tweener Clone(Slider target)
        {
            return target.DOValue(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
