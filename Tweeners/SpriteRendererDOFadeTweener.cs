using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("SpriteRenderer/DOFade")]
    public class SpriteRendererDOFadeTweener : TweenerBase<float, SpriteRenderer>
    {
        private SpriteRenderer spriteRenderer;
        public override SpriteRenderer SelfTarget => spriteRenderer ??= transform.GetComponent<SpriteRenderer>();

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

        public override Tweener Clone(SpriteRenderer target)
        {
            var tweener = target.DOFade(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
