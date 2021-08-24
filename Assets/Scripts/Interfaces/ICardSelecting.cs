using System.Collections.Generic;

public interface ICardSelecting
{
    public Card SelectCard();
    public List<Card> GetAllSelectedCards();
}
