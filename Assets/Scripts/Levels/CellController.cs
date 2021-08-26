using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

/// <summary>
/// ”правление €чейкой, содержащей карточку
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class CellController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _cardSpriteRenderer;

    private SpriteRenderer _backgroundSpriteRenderer;
    private Card _card;

    public UnityEvent<CellController> OnCardChoose = new UnityEvent<CellController>();

    private enum ColorOption
    {
        pink = 0,
        yellow = 1,
        blue = 2,
        orange = 3
    }

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
        SetBackgroundColor();
    }

    private void SetBackgroundColor()
    {
        ColorOption colorOption = GetColorOption();

        Color color = Color.white;

        switch (colorOption)
        {
            case ColorOption.blue:
                color = new Color(100f / 255f, 215f / 255f, 200f / 255f);
                break;
            case ColorOption.orange:
                color = new Color(255f / 255f, 180f / 255f, 100f / 255f);
                break;
            case ColorOption.pink:
                color = new Color(240f / 255f, 185f / 255f, 240f / 255f);
                break;
            case ColorOption.yellow:
                color = new Color(255f / 255f, 240f / 255f, 130f / 255f);
                break;
        }

        _backgroundSpriteRenderer.color = color;
    }

    private ColorOption GetColorOption()
    {
        return (ColorOption)Enum.GetValues(typeof(ColorOption)).GetValue(UnityEngine.Random.Range(0, 4));
    }

    public void ChooseCard()
    {
        OnCardChoose.Invoke(this);
    }

    public void CellBounce()
    {
        transform.DOPunchScale(new Vector3(0.2f, 0.2f), 1f, 5, 0.5f);
    }

    public void ContentBounce()
    {
        _cardSpriteRenderer.transform.DOPunchScale(new Vector3(0.2f, 0.2f), 1f, 5, 0.5f);
    }

    public void CellEaseInBounce()
    {
        transform.DOPunchPosition(new Vector3(0.2f, 0, 0), 1f, 5);
    }    
}
