namespace DOTweenUtilities
{
    /// <summary> Used by TweenerAnimator as an animation property or event. </summary>
    interface ITweenerComponent
    {
        void SetTweener();
        bool IsPlaying { get; }
        void Play();
        void Restart();
        void Pause();
        void Stop();
    }
}
