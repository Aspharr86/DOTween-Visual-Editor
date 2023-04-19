using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Change Transform.localPosition.y by Tweener. </summary>
    [DisplayOption("Transform/Transform.localPosition.y")]
    public class LocalPositionYTweener : TweenerBase<float>
    {
        private protected override void Awake()
        {
        }

        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = DOTween.To(() => transform.localPosition, x => transform.localPosition = x, new Vector3(0f, endValue, 0f), duration)
            .From(new Vector3(0f, fromValue, 0f))
            .SetOptions(AxisConstraint.Y)
            .SetDelay(delay)
            .SetEase(animationCurve)
            .SetLoops(loops, loopType)
            .SetAutoKill(false);
        }
    }
}
