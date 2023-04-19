using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localEulerAngles by Tweener. </summary>
    [DisplayOption("Transform/Transform.localEulerAngles")]
    public class LocalEulerAnglesTweener : TweenerBase<Vector3>
    {
        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => transform.localEulerAngles, x => transform.localEulerAngles = x, endValue, duration)
            .From(fromValue)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
