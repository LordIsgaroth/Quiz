using UnityEngine;

public interface IFadeControl
{
    public void FadeIn(CanvasGroup canvasGroup, float duration);
    public void FadeOut(CanvasGroup canvasGroup, float duration);
}
