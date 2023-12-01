using UnityEngine;
using DG.Tweening;
using TMPro;

namespace DOTweenUtilities
{
    /// <summary> Change TextMeshProUGUI.color by Tweener. </summary>
    [DisplayOption("TextMeshProUGUI/TextMeshProUGUI.color")]
    public class TextMeshProUGUIDOColorProperty : TweenerAnimationPropertyBase<Color, TextMeshProUGUI>
    {
        public override Tweener Clone(TextMeshProUGUI target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
