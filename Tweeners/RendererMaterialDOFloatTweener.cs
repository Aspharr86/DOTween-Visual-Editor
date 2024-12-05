using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public class RendererMaterialDOFloatTweener<T> : TweenerBase<float, T> where T : Renderer
    {
        private new T renderer;
        public override T Target => renderer ??= transform.GetComponent<T>();

        [SerializeField] private string shaderPropertyName;
        public string ShaderPropertyName { get => shaderPropertyName; set => shaderPropertyName = value; }

        public override Tweener Clone(T target)
        {
            var tweener = target.material.DOFloat(endValue, shaderPropertyName, duration);
            tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
