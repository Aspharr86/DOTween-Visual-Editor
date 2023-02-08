using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localScale by Tweener. </summary>
    [DisplayOption("Transform/Transform.localScale")]
    public class LocalScaleTweener : TweenerBase<Vector3>
    {
        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => transform.localScale, x => transform.localScale = x, endValue, duration)
            .From(fromValue)
            .SetEase(animationCurve)
            .SetLoops(-1, loopType)
            .SetAutoKill(false);
        }
    }
}
