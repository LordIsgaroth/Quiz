using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUniqueCardSelector : ICardSelecting
{
    private List<Card> _selectedCards = new List<Card>();
    private CardBundle _cardBundle;

    public RandomUniqueCardSelector(CardBundle cardBundle)
    {
        _cardBundle = cardBundle;
    }

    public Card SelectCard()
    {
        if (_selectedCards.Count >= _cardBundle.CardData.Length) throw new System.Exception("Not enough cards to choose");

        Card selectedCard = null;

        while (selectedCard == null)
        {
            int randomIndex = Random.Range(0, _cardBundle.CardData.Length);

            Card randomCard = _cardBundle.CardData[randomIndex];

            if (!_selectedCards.Contains(randomCard))
            {
               selectedCard = randomCard;
                _selectedCards.Add(selectedCard);
            }
        }

        return selectedCard;
    }

    public IReadOnlyCollection<Card> GetAllSelectedCards()
    {
        return _selectedCards.AsReadOnly();
    }
}
