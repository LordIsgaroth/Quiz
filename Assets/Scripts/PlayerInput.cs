using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 _currentMousePosition;

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {        
        if (Input.GetMouseButtonUp(0))
        {
            _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(_currentMousePosition, Vector2.zero);

            if (raycastHit.transform != null) ProcessRaycastHit(raycastHit);
        }
    }

    private void ProcessRaycastHit(RaycastHit2D raycastHit)
    {
        CardController cardController;

        if(raycastHit.transform.TryGetComponent(out cardController))
        {
            cardController.ChooseCard();
        }
    }
}
