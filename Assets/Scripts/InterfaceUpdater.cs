using UnityEngine;
using UnityEngine.UI;

public class InterfaceUpdater : MonoBehaviour
{
    [SerializeField] private Text _goalText;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _goalFadeInDuration;

    public void SetGoalText(string goalText)
    {
        _goalText.text = goalText;
    }

    public void GoalTextFadeIn()
    {
        IFadeControl fadeController = new FadeController();
        fadeController.FadeIn(_canvasGroup, _goalFadeInDuration);
    }
}
