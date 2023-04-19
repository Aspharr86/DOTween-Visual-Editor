using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition")]
    public class LocalPositionTweener : TweenerBase<Vector3>
    {
        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => transform.localPosition, x => transform.localPosition = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
