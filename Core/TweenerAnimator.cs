using UnityEngine;

namespace DOTweenUtilities
{
    public class TweenerAnimator : MonoBehaviour
    {
        private ITweenerComponent[] _tweenerComponents;
        private ITweenerComponent[] tweenerComponents => _tweenerComponents ??= GetComponentsInChildren<ITweenerComponent>();

        public void RefreshTweenerComponents()
        {
            _tweenerComponents = GetComponentsInChildren<ITweenerComponent>();
        }

        public bool IsPlaying
        {
            get
            {
                for (int i = 0; i < tweenerComponents.Length; i++)
                    if (tweenerComponents[i].IsPlaying)
                        return true;
                return false;
            }
        }

        public void Play()
        {
            for (int i = 0; i < tweenerComponents.Length; i++)
            {
                tweenerComponents[i].SetTweener();
                tweenerComponents[i].Play();
            }
        }

        public void Restart()
        {
            for (int i = 0; i < tweenerComponents.Length; i++)
            {
                tweenerComponents[i].Restart();
            }
        }

        public void Pause()
        {
            for (int i = 0; i < tweenerComponents.Length; i++)
            {
                tweenerComponents[i].Pause();
            }
        }

        public void Stop()
        {
            for (int i = 0; i < tweenerComponents.Length; i++)
            {
                tweenerComponents[i].Stop();
            }
        }
    }
}
