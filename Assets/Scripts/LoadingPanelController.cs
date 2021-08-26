using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(CanvasGroup))]
public class LoadingPanelController : MonoBehaviour
{    
    [SerializeField] private float _fadeDuration;

    private Image _image;
    private CanvasGroup _canvasGroup;
    private IFadeControl _fadeController;

    private void Start()
    {
        _image = GetComponent<Image>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _fadeController = new FadeController();
    }

    public void EndGameLoading()
    {
        _image.color = Color.black;
        _fadeController.FadeIn(_canvasGroup, _fadeDuration);
    }

    public void StartGameLoading()
    {
        _image.color = Color.white;
        _fadeController.FadeOut(_canvasGroup, _fadeDuration);
    }
}
