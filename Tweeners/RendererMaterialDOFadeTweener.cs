using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public class RendererMaterialDOFadeTweener<T> : TweenerBase<float, T> where T : Renderer
    {
        private new T renderer;
        public override T SelfTarget => renderer ??= transform.GetComponent<T>();

        [SerializeField] private string shaderPropertyName;
        public string ShaderPropertyName { get => shaderPropertyName; set => shaderPropertyName = value; }

        // Use DOVirtual.DelayedCall to prevent DOColor from fighting with DOFade.
        //
        // Reference: https://qiita.com/BEATnonanka/items/fd0e8fbfc63992b865cb
        // DOFade
        // DOColor系と同じくtargetのcolorを変更する為、競合します。
        // その場合は「Fadeの処理順を後にする」「targetを別にする」などの工夫が必要になります。
        //
        // source: https://github.com/Demigiant/dotween
        public override void SetTweener()
        {
            DOVirtual.DelayedCall(0f, DelayedSetTweener);
        }

        private void DelayedSetTweener()
        {
            tweener?.Kill();
            tweener = Clone(Target);
        }

        public override Tweener Clone(T target)
        {
            var tweener = (shaderPropertyName == string.Empty) ?
                target.material.DOFade(endValue, duration) : // Material.color
                target.material.DOFade(endValue, shaderPropertyName, duration); // Material.SetColor()
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
