using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.x by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.x")]
    public class LocalPositionXAnimationProperty : TweenerAnimationPropertyBase<float>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(endValue, 0f, 0f), duration)
            .From(new Vector3(fromValue, 0f, 0f))
            .SetOptions(AxisConstraint.X)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(endValue, 0f, 0f), duration)
            .SetOptions(AxisConstraint.X)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
