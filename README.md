# DOTween Visual Editor

* Set up and preview [DOTween](http://dotween.demigiant.com/index.php) on Inspector in Play mode in Unity.

* Easy to extend for supporting more cases.

## Uses

* `TweenerFactory`

  ![image](https://user-images.githubusercontent.com/82156567/217474437-25b421b7-e604-4017-9544-57387932a381.png)

  Provide a menu to select tweener.

  Click Remove Factory button to remove itself when being unnecessary.

* `TweenerAnimator`

  ![image](https://user-images.githubusercontent.com/82156567/217477257-22a4b4c1-a225-47c7-aa5a-3cc785e025bc.png)

  Provide a menu to select animation property or event.

  Click Play or Stop button to control all animation properties and events on the GameObject attached `TweenerAnimator` and its sub GameObjects.

Both of their menus can get all corresponding sub classes automatically.

## Core components

* `TweenerBase<T>`

  Added on GameObject which to tween to do simple animation.

* `TweenerAnimationProperty<T>`

  Added on any GameObject as an animation property, and controlled by `TweenerAnimator`(optional).

* `UnityEventInvokeAnimationEvent`

  Added on any GameObject as an animation event, and controlled by `TweenerAnimator`(optional).

All of them can preview by clicking Play or Stop button.

## Concept

* `TweenerBase<T>`

  As a looping state

* `TweenerAnimationProperty<T>`

  As a transition to state x from any state

* `UnityEventInvokeAnimationEvent`

  As an animation event

## Custom Extensions

* `TweenerBase<T>`

1. Inherit `TweenerBase<>`

2. Override `Awake()` and `SetTweener()`

3. Add `DisplayOptionAttribute`

Example:

![image](https://user-images.githubusercontent.com/82156567/217475760-01ff50c4-ded1-445c-9dbc-978f77293e06.png)

```C#
/// <summary> Change Image.color by Tweener. </summary>
[RequireComponent(typeof(Image))]
[DisplayOption("Image/Image.color")]
public class ImageColorTweener : TweenerBase<Color>
{
    private Image image;

    private protected override void Awake()
    {
        image = GetComponent<Image>();
    }

    public override void SetTweener()
    {
        tweener?.Kill();
        tweener = DOTween.To(() => image.color, x => image.color = x, endValue, duration)
        .From(fromValue)
        .SetEase(animationCurve)
        .SetLoops(-1, loopType)
        .SetAutoKill(false);
    }
}
```

* `TweenerAnimationPropertyBase<T>`

1. Inherit `TweenerAnimationPropertyBase<>`

2. Override `GetTweenedComponent()` and `SetTweener()`

3. Add `DisplayOptionAttribute`

Example:

![image](https://user-images.githubusercontent.com/82156567/217476327-e30f1b3c-55a3-42c9-a8ee-3a12eb58a80c.png)

```C#
/// <summary> Change RectTransform.sizeDelta by Tweener. </summary>
[DisplayOption("RectTransform/RectTransform.sizeDelta")]
public class RectTransformSizeDeltaAnimationProperty : TweenerAnimationPropertyBase<Vector2>
{
    private RectTransform rectTransform;

    public override void GetTweenedComponent()
    {
        rectTransform = tweenedGameObject.transform.GetComponent<RectTransform>();
    }

    public override void SetTweener()
    {
        tweener?.Kill();
        tweener = isFromTween ?
        DOTween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, endValue, duration)
        .From(fromValue)
        .SetDelay(delay)
        .SetEase(animationCurve)
        .SetLoops(isLoop ? -1 : 1, loopType)
        .SetAutoKill(false) :
        DOTween.To(() => rectTransform.sizeDelta, x => rectTransform.sizeDelta = x, endValue, duration)
        .SetDelay(delay)
        .SetEase(animationCurve)
        .SetLoops(isLoop ? -1 : 1, loopType)
        .SetAutoKill(false);
    }
}
```

## License

[MIT License](https://github.com/Aspharr86/DOTween-Visual-Editor/blob/main/LICENSE)
