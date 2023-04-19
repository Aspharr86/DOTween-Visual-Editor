using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.z by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.z")]
    public class LocalPositionZTweener : TweenerBase<float>
    {
        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => transform.localPosition, x => transform.localPosition = x, new Vector3(0f, 0f, endValue), duration)
            .From(new Vector3(0f, 0f, fromValue))
            .SetOptions(AxisConstraint.Z)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
