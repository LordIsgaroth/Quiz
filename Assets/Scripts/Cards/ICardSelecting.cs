using System.Collections.Generic;

/// <summary>
/// Интерфейс выбора карточки
/// </summary>
public interface ICardSelecting
{    
    public Card SelectCard(List<Card> cardsToExclude);
    public List<Card> GetAllSelectedCards();
}