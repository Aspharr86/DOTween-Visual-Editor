namespace DOTweenUtilities
{
    /// <summary> Used by TweenerAnimator as an animation property or event. </summary>
    interface ITweenerComponent
    {
        void GetTweenedComponent();
        void SetTweener();
        void Play();
        void Stop();
    }
}
