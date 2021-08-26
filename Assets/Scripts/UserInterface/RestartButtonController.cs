using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���������� ������� ������������ ����
/// </summary>
public class RestartButtonController : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public void SetVisibility(bool isVisible)
    {
        _restartButton.gameObject.SetActive(isVisible);
    }
}