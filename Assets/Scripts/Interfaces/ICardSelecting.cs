using System.Collections.Generic;

public interface ICardSelecting
{
    public Card SelectCard();
    public Card SelectCard(List<Card> cardsToExclude);
    public List<Card> GetAllSelectedCards();
}
