using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelCreation
{
    public int GetNumberOfLevels();
    public void CreateLevel(int number);
    public IReadOnlyCollection<Card> GetLevelCards();    
}
