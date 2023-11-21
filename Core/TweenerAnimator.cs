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

        public bool IsPlaying
        {
            get
            {
                for (int i = 0; i < tweenerAnimationProperties.Length; i++)
                    if (tweenerAnimationProperties[i].IsPlaying)
                        return true;
                return false;
            }
        }

        public void Play()
        {
            for (int i = 0; i < tweenerAnimationProperties.Length; i++)
            {
                tweenerAnimationProperties[i].SetTweener();
                tweenerAnimationProperties[i].Play();
            }
        }

        public void Restart()
        {
            for (int i = 0; i < tweenerAnimationProperties.Length; i++)
            {
                tweenerAnimationProperties[i].Restart();
            }
        }

        public void Pause()
        {
            for (int i = 0; i < tweenerAnimationProperties.Length; i++)
            {
                tweenerAnimationProperties[i].Pause();
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
