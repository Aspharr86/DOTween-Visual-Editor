using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change SpriteRenderer.color by Tweener. </summary>
    [DisplayOption("SpriteRenderer/SpriteRenderer.color")]
    public class SpriteRendererDOColorProperty : TweenerAnimationPropertyBase<Color, SpriteRenderer>
    {
        public override Tweener Clone(SpriteRenderer target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (isFromTween) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
