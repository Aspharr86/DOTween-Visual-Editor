using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change SpriteRenderer.color by Tweener. </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    [DisplayOption("SpriteRenderer/SpriteRenderer.color")]
    public class SpriteRendererDOColorTweener : TweenerBase<Color, SpriteRenderer>
    {
        private SpriteRenderer spriteRenderer;
        public override SpriteRenderer Target => spriteRenderer ?? (spriteRenderer = transform.GetComponent<SpriteRenderer>());

        public override Tweener Clone(SpriteRenderer target)
        {
            var tweener = target.DOColor(endValue, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
