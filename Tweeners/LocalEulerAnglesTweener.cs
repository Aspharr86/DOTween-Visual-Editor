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
            .SetEase(animationCurve)
            .SetLoops(-1, loopType)
            .SetAutoKill(false);
        }
    }
}
