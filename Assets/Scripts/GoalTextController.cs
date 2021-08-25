using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GoalTextController : MonoBehaviour
{
    [SerializeField] private Text _goalText;    
    [SerializeField] private float _goalFadeInDuration;

    private CanvasGroup _canvasGroup;
    private IFadeControl _fadeController;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _fadeController = new FadeController();
    }

    public void SetGoalText(string goalText)
    {
        _goalText.text = goalText;
    }

    public void GoalTextFadeIn()
    {       
        _fadeController.FadeIn(_canvasGroup, _goalFadeInDuration);
    }
}
