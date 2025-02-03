using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [DisplayOption("Image/DOColor")]
    public class ImageDOColorTweener : TweenerBase<Color, Image>
    {
        private Image image;
        public override Image SelfTarget => image ??= transform.GetComponent<Image>();

        public override Tweener Clone(Image target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
