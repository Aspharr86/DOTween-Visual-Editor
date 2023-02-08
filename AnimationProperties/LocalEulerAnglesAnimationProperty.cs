using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localEulerAngles by Tweener. </summary>
    [DisplayOption("Transform/Transform.localEulerAngles")]
    public class LocalEulerAnglesAnimationProperty : TweenerAnimationPropertyBase<Vector3>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => tweenedGameObject.transform.localEulerAngles, x => tweenedGameObject.transform.localEulerAngles = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => tweenedGameObject.transform.localEulerAngles, x => tweenedGameObject.transform.localEulerAngles = x, endValue, duration)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
