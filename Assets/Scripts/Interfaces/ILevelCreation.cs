using System.Collections.Generic;
using UnityEngine.Events;

public interface ILevelCreation
{    
    public int GetNumberOfLevels();
    public void CreateLevel(int number, List<Card> cardsToExclude, UnityAction<Card> cardChooseDispatcher);
    public List<Card> GetLevelCards();    
}
