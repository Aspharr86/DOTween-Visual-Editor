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
            var tweener = target.DOColor(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
