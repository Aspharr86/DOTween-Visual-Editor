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
