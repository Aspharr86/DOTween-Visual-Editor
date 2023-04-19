using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.z by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.z")]
    public class LocalPositionZAnimationProperty : TweenerAnimationPropertyBase<float>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(0f, 0f, endValue), duration)
            .From(new Vector3(0f, 0f, fromValue))
            .SetOptions(AxisConstraint.Z)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(0f, 0f, endValue), duration)
            .SetOptions(AxisConstraint.Z)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
