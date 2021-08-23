using System.Collections.Generic;

public interface ILevelCreation
{
    public int GetNumberOfLevels();
    public void CreateLevel(int number);
    public IReadOnlyCollection<Card> GetLevelCards();    
}
