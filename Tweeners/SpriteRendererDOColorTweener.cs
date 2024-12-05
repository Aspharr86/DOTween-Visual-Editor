using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    [DisplayOption("SpriteRenderer/DOColor")]
    public class SpriteRendererDOColorTweener : TweenerBase<Color, SpriteRenderer>
    {
        private SpriteRenderer spriteRenderer;
        public override SpriteRenderer Target => spriteRenderer ??= transform.GetComponent<SpriteRenderer>();

        public override Tweener Clone(SpriteRenderer target)
        {
            var tweener = target.DOColor(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
