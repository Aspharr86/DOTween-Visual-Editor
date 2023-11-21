# DOTween Visual Editor

* Set up, preview, and use [DOTween](http://dotween.demigiant.com/index.php) on Inspector in Play mode in Unity.

* Easy to extend for supporting more cases.

## Uses

* `TweenerFactory`

  ![image](https://user-images.githubusercontent.com/82156567/217474437-25b421b7-e604-4017-9544-57387932a381.png)

  Provide a menu to select tweener.

  A tweener has parameters as follow:
  
  ![image](https://github.com/Aspharr86/DOTween-Visual-Editor/assets/82156567/c8dd7e74-c812-4e46-9d77-4f61000c8d0a)

  Click [Remove Factory] button to remove itself when being unnecessary.

* `TweenerAnimator`

  ![image](https://user-images.githubusercontent.com/82156567/217477257-22a4b4c1-a225-47c7-aa5a-3cc785e025bc.png)

  Provide a menu to select animation property or event.

  A property has parameters as follow:

  ![image](https://github.com/Aspharr86/DOTween-Visual-Editor/assets/82156567/535c47df-899a-4319-9ad8-dee633ce54a2)

  Click [Play] or [Stop] button to control all animation properties and events on the GameObject attached `TweenerAnimator` and its sub GameObjects.

## Core components

* `TweenerBase<T, U>`

  Added on GameObject which to tween to do simple animation.

* `TweenerAnimationProperty<T, U>`

  Added on any GameObject as an animation property, and can be controlled by `TweenerAnimator`(optional).

* `UnityEventInvokeAnimationEvent`

  Added on any GameObject as an animation event, and can be controlled by `TweenerAnimator`(optional).

All of them can preview by clicking [Play] or [Stop] button in Play mode.

## Concept

* `TweenerBase<T, U>`

  As a looping state

* `TweenerAnimationProperty<T, U>`

  As a transition to state x from any state

* `UnityEventInvokeAnimationEvent`

  As an animation event

## Custom Extensions

* `TweenerBase<T, U>`

1. Inherit `TweenerBase<T, U>`, where T is tweened value type, and U is tweened `UnityEngine.Object` type

2. Override `Clone(U target)`

3. Add `DisplayOptionAttribute`, so it will be an option in dropdown of `TweenerFactory` or `TweenerAnimator`

Example:

![image](https://user-images.githubusercontent.com/82156567/217475760-01ff50c4-ded1-445c-9dbc-978f77293e06.png)

```C#
/// <summary> Change Image.color by Tweener. </summary>
[RequireComponent(typeof(Image))]
[DisplayOption("Image/Image.color")]
public class ImageColorTweener : TweenerBase<Color>
{
  private Image image;
  public override Image Target => image ?? (image = transform.GetComponent<Image>());

  public override Tweener Clone(Image target)
  {
    return target.DOColor(endValue, duration)
    .From(fromValue)
    .SetDelay(delay)
    .SetEase(animationCurve)
    .SetLoops(loops, loopType)
    .SetAutoKill(false);
  }
}
```

* `TweenerAnimationPropertyBase<T, U>`

1. Inherit `TweenerAnimationPropertyBase<T, U>`, where T is tweened value type, and U is tweened `UnityEngine.Object` type

2. Override `Clone(U target)`

3. Add `DisplayOptionAttribute`, so it will be an option in dropdown of `TweenerFactory` or `TweenerAnimator`

Example:

![image](https://user-images.githubusercontent.com/82156567/217476327-e30f1b3c-55a3-42c9-a8ee-3a12eb58a80c.png)

```C#
/// <summary> Change RectTransform.anchoredPosition by Tweener. </summary>
[DisplayOption("RectTransform/RectTransform.anchoredPosition")]
public class RectTransformDOAnchorPosProperty : TweenerAnimationPropertyBase<Vector2, RectTransform>
{
    public override Tweener Clone(RectTransform target)
    {
        return isFromTween ?
        target.DOAnchorPos(endValue, duration)
        .From(fromValue)
        .SetDelay(delay)
        .SetEase(animationCurve)
        .SetLoops(loops, loopType)
        .SetAutoKill(false) :
        target.DOAnchorPos(endValue, duration)
        .SetDelay(delay)
        .SetEase(animationCurve)
        .SetLoops(loops, loopType)
        .SetAutoKill(false);
    }
}
```

## License

[MIT License](https://github.com/Aspharr86/DOTween-Visual-Editor/blob/main/LICENSE)
