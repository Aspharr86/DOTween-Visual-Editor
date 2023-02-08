using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale")]
    public class LocalScaleAnimationProperty : TweenerAnimationPropertyBase<Vector3>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => tweenedGameObject.transform.localScale, x => tweenedGameObject.transform.localScale = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => tweenedGameObject.transform.localScale, x => tweenedGameObject.transform.localScale = x, endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
