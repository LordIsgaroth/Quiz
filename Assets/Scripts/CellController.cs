using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class CellController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cardSpriteRenderer;

    private SpriteRenderer _backgroundSpriteRenderer;
    private Card _card;

    public UnityEvent<CellController> OnCardChoose = new UnityEvent<CellController>();

    public Card Card
    {
        get => _card;

        set
        {
            _card = value;
            _cardSpriteRenderer.sprite = _card.Sprite;
        } 
    }

    private void Start()
    {
        _backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
        ChooseBackgroundColor();        
    }

    private void ChooseBackgroundColor()
    {
        _backgroundSpriteRenderer.color = new Color(70.0f / 100.0f, 170.0f / 100.0f, 160.0f / 100.0f);
    }

    public void ChooseCard()
    {
        OnCardChoose.Invoke(this);
    }

    public void Bounce()
    {
        transform.DOPunchScale(new Vector3(0.2f, 0.2f), 1f, 5, 0.5f);            
    }

    public void EaseInBounce()
    {
        transform.DOPunchPosition(new Vector3(0.2f, 0, 0), 1f, 5);
    }    
}
