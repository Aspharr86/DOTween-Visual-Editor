using UnityEngine;
using DG.Tweening;
using TMPro;

namespace DOTweenUtilities
{
    /// <summary> Change TextMeshProUGUI.color.a by Tweener. </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    [DisplayOption("TextMeshProUGUI/TextMeshProUGUI.color.a")]
    public class TextMeshProUGUIDOFadeTweener : TweenerBase<float, TextMeshProUGUI>
    {
        private TextMeshProUGUI textMeshProUGUI;
        public override TextMeshProUGUI Target => textMeshProUGUI ?? (textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>());

        // Use DOVirtual.DelayedCall to prevent DOColor from fighting with DOFade.
        //
        // Reference: https://qiita.com/BEATnonanka/items/fd0e8fbfc63992b865cb
        // DOFade
        // DOColor系と同じくtargetのcolorを変更する為、競合します。
        // その場合は「Fadeの処理順を後にする」「targetを別にする」などの工夫が必要になります。
        //
        // source: https://github.com/Demigiant/dotween
        public override void SetTweener()
        {
            DOVirtual.DelayedCall(0f, DelayedSetTweener);
        }

        private void DelayedSetTweener()
        {
            tweener?.Kill();
            tweener = Clone(Target);
        }

        public override Tweener Clone(TextMeshProUGUI target)
        {
            return target.DOFade(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
