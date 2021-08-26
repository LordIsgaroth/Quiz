using System.Collections.Generic;

/// <summary>
/// ��������� ������ ��������
/// </summary>
public interface ICardSelecting
{    
    public Card SelectCard(List<Card> cardsToExclude);
    public List<Card> GetAllSelectedCards();
}