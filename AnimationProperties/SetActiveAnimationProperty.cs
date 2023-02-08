using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Call GameObject.SetActive() by Tweener. </summary>
    [DisplayOption("GameObject/GameObject.SetActive()")]
    public class SetActiveAnimationProperty : TweenerAnimationPropertyBase<bool>
    {
        private float value;

        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = isFromTween ?
            DOTween.To(() => value, x => value = x, 1f, duration)
            .OnUpdate(() =>
            {
                if (value == 0f) tweenedGameObject.SetActive(fromValue);
                if (value == 1f) tweenedGameObject.SetActive(endValue);
            })
            .From(0f)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false) :
            DOTween.To(() => value, x => value = x, 1f, duration)
            .OnUpdate(() =>
            {
                if (value == 0f) tweenedGameObject.SetActive(!endValue);
                if (value == 1f) tweenedGameObject.SetActive(endValue);
            })
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(isLoop ? -1 : 1, loopType)
            .SetAutoKill(false);
        }
    }
}
