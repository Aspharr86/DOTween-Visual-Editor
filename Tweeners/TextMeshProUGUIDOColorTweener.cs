using UnityEngine;
using DG.Tweening;
using TMPro;

namespace DOTweenUtilities
{
    /// <summary> Change TextMeshProUGUI.color by Tweener. </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    [DisplayOption("TextMeshProUGUI/TextMeshProUGUI.color")]
    public class TextMeshProUGUIDOColorTweener : TweenerBase<Color, TextMeshProUGUI>
    {
        private TextMeshProUGUI textMeshProUGUI;
        public override TextMeshProUGUI Target => textMeshProUGUI ?? (textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>());

        public override Tweener Clone(TextMeshProUGUI target)
        {
            return target.DOColor(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
