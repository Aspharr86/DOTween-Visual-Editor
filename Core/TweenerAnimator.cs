using UnityEngine;

namespace DOTweenUtilities
{
    public class TweenerAnimator : MonoBehaviour
    {
        private ITweenerComponent[] tweenerAnimationProperties;

        private void Awake()
        {
            GetTweenerComponents();
        }

        public void GetTweenerComponents()
        {
            tweenerAnimationProperties = GetComponentsInChildren<ITweenerComponent>();
        }

        public void Play()
        {
            for (int i = 0; i < tweenerAnimationProperties.Length; i++)
            {
                tweenerAnimationProperties[i].GetTweenedComponent();
                tweenerAnimationProperties[i].SetTweener();
                tweenerAnimationProperties[i].Play();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < tweenerAnimationProperties.Length; i++)
            {
                tweenerAnimationProperties[i].Stop();
            }
        }
    }
}
