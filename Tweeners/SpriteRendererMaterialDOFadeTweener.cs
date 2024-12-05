using UnityEngine;

namespace DOTweenUtilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    [DisplayOption("SpriteRenderer/material/DOFade")]
    public class SpriteRendererMaterialDOFadeTweener : RendererMaterialDOFadeTweener<SpriteRenderer>
    {
    }
}
