using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("SpriteRenderer/DOColor")]
    public class SpriteRendererDOColorTweener : TweenerBase<Color, SpriteRenderer>
    {
        private SpriteRenderer spriteRenderer;
        public override SpriteRenderer SelfTarget => spriteRenderer ??= transform.GetComponent<SpriteRenderer>();

        public override Tweener Clone(SpriteRenderer target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
