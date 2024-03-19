using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public static class TweenerUtilities
    {
        public static Tweener SetTweenerParameters(this Tweener tweener, float delay, AnimationCurve animationCurve, int loops, LoopType loopType, string iD)
        {
            tweener.SetDelay(delay).SetEase(animationCurve).SetLoops(loops, loopType);
            if (!string.IsNullOrEmpty(iD)) tweener.SetId(iD);
            tweener.SetAutoKill(false);

            return tweener;
        }

        // Reference:
        // https://stackoverflow.com/questions/37775480/issubclassof-does-not-work-for-a-child-whose-parent-is-generic-unless-generic
        public static bool IsSubclassOfGeneric(Type current, Type genericBase)
        {
            while ((current = current.BaseType) != null)
            {
                if (current.IsGenericType && current.GetGenericTypeDefinition() == genericBase)
                    return true;
            }
            return false;
        }
    }
}
