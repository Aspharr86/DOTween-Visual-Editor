using System;

namespace DOTweenUtilities
{
    /// <summary> As a dropdown option displayed on Inspector. </summary>
    /// <remarks> Used by TweenerFactoryEditor and TweenerAnimatorEditor. </remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class DisplayOptionAttribute : Attribute
    {
        /// <summary> The dropdown option name. </summary>
        public string Name { get; private set; }

        public DisplayOptionAttribute(string name)
        {
            this.Name = name;
        }
    }
}
