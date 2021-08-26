using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

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
        ChooseBackgroundColor();        
    }

    private void ChooseBackgroundColor()
    {
        ColorOption colorOption = GetColorOption();

        Color color = Color.white;

        switch (colorOption)
        {
            case ColorOption.blue:
                color = new Color(70.0f / 100.0f, 170.0f / 100.0f, 160.0f / 100.0f);
                break;
            case ColorOption.orange:
                color = new Color(230.0f / 100.0f, 175.0f / 100.0f, 120.0f / 100.0f);
                break;
            case ColorOption.pink:
                color = new Color(70.0f / 100.0f, 170.0f / 100.0f, 160.0f / 100.0f);
                break;
            case ColorOption.yellow:
                color = new Color(70.0f / 100.0f, 170.0f / 100.0f, 160.0f / 100.0f);
                break;
        }

        _backgroundSpriteRenderer.color = new Color(230.0f, 175.0f, 120.0f);
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
