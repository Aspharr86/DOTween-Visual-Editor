using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Call GameObject.SetActive() by Tweener. </summary>
    [DisplayOption("GameObject/GameObject.SetActive()")]
    public class SetActiveTweener : TweenerBase<bool>
    {
        private float value;

        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => value, x => value = x, 1f, duration)
            .OnUpdate(() =>
            {
                if (value == 0f) gameObject.SetActive(fromValue);
                if (value == 1f) gameObject.SetActive(endValue);
            })
            .From(0f)
            .SetEase(animationCurve)
            .SetLoops(-1, loopType)
            .SetAutoKill(false);
        }
    }
}
