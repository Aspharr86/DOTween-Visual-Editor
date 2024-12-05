using UnityEngine;

namespace DOTweenUtilities
{
    [RequireComponent(typeof(MeshRenderer))]
    [DisplayOption("MeshRenderer/material/DOFade")]
    public class MeshRendererMaterialDOFadeTweener : RendererMaterialDOFadeTweener<MeshRenderer>
    {
    }
}
