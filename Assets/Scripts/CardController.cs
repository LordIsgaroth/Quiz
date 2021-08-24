
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class CardController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cardSpriteRenderer;

    private SpriteRenderer _backgroundSpriteRenderer;
    private Card _card;

    public UnityEvent<Card> OnCardChoose = new UnityEvent<Card>();

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
        OnCardChoose.Invoke(_card);
    }
}
