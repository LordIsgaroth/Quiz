using UnityEngine;
using DG.Tweening;

/// <summary>
/// Управление FadeIn/FadeOut эффектами элементов интерфейса
/// </summary>
public class FadeController : IFadeControl
{
    public void FadeIn(CanvasGroup canvasGroup, float duration)
    {
        Fade(canvasGroup, 1f, duration);
    }

    public void FadeOut(CanvasGroup canvasGroup, float duration)
    {
        Fade(canvasGroup, 0f, duration);
    }

    private void Fade(CanvasGroup canvasGroup, float endValue, float duration)
    {
        canvasGroup.DOFade(endValue, 3f);
    }    
}