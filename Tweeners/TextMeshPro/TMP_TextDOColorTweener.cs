using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DOTweenUtilities
{
    public class TMP_TextDOColorTweener<T> : TweenerBase<Color, T> where T : TMP_Text
    {
        private T tMP_Text;
        public override T SelfTarget => tMP_Text ?? (tMP_Text = transform.GetComponent<T>());

        public override Tweener Clone(T target)
        {
            var tweener = target.DOColor(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
