using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [DisplayOption("Slider/DOValue")]
    public class SliderDOValueTweener : TweenerBase<float, Slider>
    {
        private Slider slider;
        public override Slider SelfTarget => slider ??= transform.GetComponent<Slider>();

        public override Tweener Clone(Slider target)
        {
            var tweener = target.DOValue(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
