using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    /// <summary> Change Image.color.a by Tweener. </summary>
    [DisplayOption("Image/Image.color.a")]
    public class ImageColorAlphaAnimationProperty : TweenerAnimationPropertyBase<float>
    {
        private Image image;

        public override void GetTweenedComponent()
        {
            image = tweenedGameObject.transform.GetComponent<Image>();
        }

        public override void SetTweener()
        {
            // Use DOVirtual.DelayedCall to prevent DOColor from fighting with DOFade.
            //
            // Reference: https://qiita.com/BEATnonanka/items/fd0e8fbfc63992b865cb
            // DOFade
            // DOColor系と同じくtargetのcolorを変更する為、競合します。
            // その場合は「Fadeの処理順を後にする」「targetを別にする」などの工夫が必要になります。
            DOVirtual.DelayedCall(0f, () =>
            {
                tweener?.Kill();
                tweener = isFromTween ?
                DOTween.ToAlpha(() => image.color, x => image.color = x, endValue, duration)
                .From(fromValue)
                .SetDelay(delay)
                .SetEase(animationCurve)
                .SetLoops(isLoop ? -1 : 1, loopType)
                .SetAutoKill(false) :
                DOTween.ToAlpha(() => image.color, x => image.color = x, endValue, duration)
                .SetDelay(delay)
                .SetEase(animationCurve)
                .SetLoops(isLoop ? -1 : 1, loopType)
                .SetAutoKill(false);
            });
        }
    }
}
