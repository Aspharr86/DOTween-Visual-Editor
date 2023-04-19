using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.y by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.y")]
    public class LocalPositionYAnimationProperty : TweenerAnimationPropertyBase<float>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(0f, endValue, 0f), duration)
            .From(new Vector3(0f, fromValue, 0f))
            .SetOptions(AxisConstraint.Y)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => tweenedGameObject.transform.localPosition, x => tweenedGameObject.transform.localPosition = x, new Vector3(0f, endValue, 0f), duration)
            .SetOptions(AxisConstraint.Y)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
