using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color.a by Tweener. </summary>
    [DisplayOption("Image/Image.color.a")]
    public class ImageDOFadeProperty : TweenerAnimationPropertyBase<float, Image>
    {
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

        public override Tweener Clone(Image target)
        {
            return isFromTween ?
            target.DOFade(endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false) :
            target.DOFade(endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}