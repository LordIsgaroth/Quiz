using UnityEngine;
using UnityEngine.UI;

public class InterfaceUpdater : MonoBehaviour
{
    [SerializeField] private Text _goalText;

    public void SetGoalText(string goalText)
    {
        _goalText.text = goalText;
    }
}
