using System.Collections.Generic;
using UnityEngine.Events;

/// <summary>
/// Интерфейс создания уровня
/// </summary>
public interface ILevelCreation
{    
    public int GetNumberOfLevels();
    public void CreateLevel(int number, List<Card> cardsToExclude, UnityAction<CellController> cardChooseDispatcher);
    public List<Card> GetLevelCards();    
}
